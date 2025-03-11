from collections import defaultdict

class Grammar:
    def __init__(self, productions, start_symbol):
        self.productions = productions
        self.start_symbol = start_symbol
        self.terminals = set()
        self.non_terminals = set()
        self.first_sets = defaultdict(set)
        self.follow_sets = defaultdict(set)

        # Augment grammar
        augmented_start = self.start_symbol + "'"
        self.productions.insert(0, (augmented_start, [self.start_symbol]))
        self.start_symbol = augmented_start

        # Identify terminals and non-terminals
        for lhs, rhs in self.productions:
            self.non_terminals.add(lhs)
            for symbol in rhs:
                if symbol.islower() or symbol in "+*()id":
                    self.terminals.add(symbol)
                else:
                    self.non_terminals.add(symbol)

        self.compute_first_sets()
        self.compute_follow_sets()

    def compute_first_sets(self):
        for terminal in self.terminals:
            self.first_sets[terminal] = {terminal}

        while True:
            updated = False
            for lhs, rhs in self.productions:
                prev_size = len(self.first_sets[lhs])
                
                for symbol in rhs:
                    self.first_sets[lhs] |= (self.first_sets[symbol] - {'ε'})
                    if 'ε' not in self.first_sets[symbol]:
                        break
                else:
                    self.first_sets[lhs].add('ε')

                if len(self.first_sets[lhs]) > prev_size:
                    updated = True
            
            if not updated:
                break

    def compute_follow_sets(self):
        self.follow_sets[self.start_symbol].add('$')

        while True:
            updated = False
            for lhs, rhs in self.productions:
                for i, symbol in enumerate(rhs):
                    if symbol in self.non_terminals:
                        prev_size = len(self.follow_sets[symbol])

                        if i + 1 < len(rhs):
                            next_symbol = rhs[i + 1]
                            self.follow_sets[symbol] |= (self.first_sets[next_symbol] - {'ε'})
                        
                        if i + 1 == len(rhs) or all('ε' in self.first_sets[s] for s in rhs[i+1:]):
                            self.follow_sets[symbol] |= self.follow_sets[lhs]

                        if len(self.follow_sets[symbol]) > prev_size:
                            updated = True
            
            if not updated:
                break

class Item:
    def __init__(self, production, dot_position, lookahead):
        self.production = (production[0], tuple(production[1]))
        self.dot_position = dot_position
        self.lookahead = lookahead

    def __eq__(self, other):
        return (self.production == other.production and 
                self.dot_position == other.dot_position and 
                self.lookahead == other.lookahead)

    def __hash__(self):
        return hash((self.production, self.dot_position, self.lookahead))

class CLRParser:
    def __init__(self, grammar):
        self.grammar = grammar
        self.action_table = {}
        self.goto_table = {}
        self.states = []
        self.build_parsing_tables()
    
    def closure(self, items):
        result = set(items)
        while True:
            new_items = set()
            for item in result:
                lhs, rhs = item.production
                if item.dot_position < len(rhs):
                    symbol_after_dot = rhs[item.dot_position]
                    if symbol_after_dot in self.grammar.non_terminals:
                        lookaheads = set()
                        if item.dot_position + 1 < len(rhs):
                            lookaheads = self.grammar.first_sets[rhs[item.dot_position + 1]] - {'ε'}
                        else:
                            lookaheads = {item.lookahead}

                        for prod in self.grammar.productions:
                            if prod[0] == symbol_after_dot:
                                for la in lookaheads:
                                    new_items.add(Item(prod, 0, la))

            if not new_items - result:
                break
            result.update(new_items)
        return result

    def goto(self, items, symbol):
        next_items = set()
        for item in items:
            lhs, rhs = item.production
            if item.dot_position < len(rhs) and rhs[item.dot_position] == symbol:
                next_items.add(Item(item.production, item.dot_position + 1, item.lookahead))
        return self.closure(next_items)

    def build_parsing_tables(self):
        start_item = Item((self.grammar.start_symbol, [self.grammar.productions[1][0]]), 0, '$')
        initial_state = self.closure({start_item})
        self.states.append(initial_state)
        
        state_queue = [initial_state]
        while state_queue:
            current_state = state_queue.pop(0)
            state_index = self.states.index(current_state)
            
            for symbol in self.grammar.terminals | self.grammar.non_terminals:
                next_state = self.goto(current_state, symbol)
                if next_state:
                    if next_state not in self.states:
                        self.states.append(next_state)
                        state_queue.append(next_state)
                    next_state_index = self.states.index(next_state)
                    if symbol in self.grammar.terminals:
                        self.action_table[(state_index, symbol)] = ('shift', next_state_index)
                    else:
                        self.goto_table[(state_index, symbol)] = next_state_index
            
            for item in current_state:
                lhs, rhs = item.production
                if item.dot_position == len(rhs):
                    if lhs == self.grammar.start_symbol and item.lookahead == '$':
                        self.action_table[(state_index, '$')] = ('accept', None)
                    else:
                        self.action_table[(state_index, item.lookahead)] = ('reduce', item.production)

    def parse(self, input_string):
        input_tokens = input_string.split() + ['$']
        stack = [0]
        index = 0
        
        while True:
            state = stack[-1]
            current_token = input_tokens[index]
            
            if (state, current_token) not in self.action_table:
                return f"Error: Unexpected token '{current_token}' at position {index}"
            
            action, value = self.action_table[(state, current_token)]
            
            if action == 'shift':
                stack.append(value)
                index += 1
            elif action == 'reduce':
                lhs, rhs = value
                for _ in range(len(rhs)):
                    stack.pop()
                prev_state = stack[-1]
                if (prev_state, lhs) in self.goto_table:
                    stack.append(self.goto_table[(prev_state, lhs)])
                else:
                    return f"Error: No GOTO state for ({prev_state}, {lhs})"
            elif action == 'accept':
                return "Input accepted!"
            else:
                return "Error: Invalid action"

# Example usage
def main():
    productions = [
        ('E', ['E', '+', 'T']),
        ('E', ['T']),
        ('T', ['T', '*', 'F']),
        ('T', ['F']),
        ('F', ['(', 'E', ')']),
        ('F', ['id'])
    ] 
    
    
    grammar = Grammar(productions, 'E')
    parser = CLRParser(grammar)
    
    test_cases = [
        "id + id * id",
        "( id + id ) * id",
        "id * id + id",
        "id + ( id * id )",
        "( id )"
    ]
    
    for test in test_cases:
        print(f"\nParsing: {test}")
        print(parser.parse(test))

if __name__ == "__main__":
    main()

# def main():
#     productions = [  
#         ('B', ['B', 'or', 'C']),
#         ('B', ['C']),
#         ('C', ['C', 'and', 'D']),
#         ('C', ['D']),
#         ('D', ['not', 'D']),
#         ('D', ['(', 'B', ')']),
#         ('D', ['true']),
#         ('D', ['false'])
#     ]

#     grammar = Grammar(productions, 'B')  # Updated start symbol to 'B'
#     parser = CLRParser(grammar)

#     test_cases = [
#         "true and false",
#         "not ( true or false )",
#         "( false and true ) or true",
#         "not not true",
#         "true or ( false and true )"
#     ]

#     for test in test_cases:
#         print(f"\nParsing: {test}")
#         print(parser.parse(test))

# if __name__ == "__main__":
#     main()


# def main():
#     productions = [
#         ('S', ['a']),
#         ('S', ['^']),
#         ('S', ['(', 'R', ')']),
#         ('T', ['T', ',', 'S']),
#         ('T', ['S']),
#         ('R', ['T'])
#     ]

#     grammar = Grammar(productions, 'S')  # Start symbol 'S'
#     parser = CLRParser(grammar)

#     test_cases = [
#         "( a , ( a , a ) )",  # Given string from the image
#         "a",
#         "( a )",
#         "a , a",
#         "( a , a )"
#     ]

#     for test in test_cases:
#         print(f"\nParsing: {test}")
#         print(parser.parse(test))

# if __name__ == "__main__":
#     main()
