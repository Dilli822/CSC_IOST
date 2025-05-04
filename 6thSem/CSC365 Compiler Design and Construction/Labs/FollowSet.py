import sys

productions = {}
firsts = {}
follows = {}

def add_to_set(result_set, value):
    """Adds value to result set if not already present."""
    if value not in result_set:
        result_set.add(value)

def compute_first(symbol):
    """Computes the FIRST set of a given symbol."""
    if symbol in firsts:
        return firsts[symbol]

    first_set = set()
    
    # If the symbol is a terminal, add it to FIRST
    if not symbol.isupper():
        first_set.add(symbol)
    else:
        for production in productions.get(symbol, []):
            if production == "#":  # '#' represents epsilon (empty string)
                first_set.add("#")
            else:
                for char in production:
                    char_first = compute_first(char)
                    first_set.update(char_first - {"#"})

                    if "#" not in char_first:
                        break
                else:
                    first_set.add("#")  # If all characters can be epsilon

    firsts[symbol] = first_set
    return first_set

def compute_follow(symbol):
    """Computes the FOLLOW set of a given symbol."""
    if symbol in follows:
        return follows[symbol]

    follow_set = set()
    
    # Start symbol always has '$' in FOLLOW
    if symbol == start_symbol:
        follow_set.add("$")

    for lhs, rhs_list in productions.items():
        for rhs in rhs_list:
            for i, char in enumerate(rhs):
                if char == symbol:
                    following_chars = rhs[i+1:]
                    
                    if following_chars:
                        first_next = compute_first(following_chars[0])
                        follow_set.update(first_next - {"#"})
                        
                        if "#" in first_next:
                            follow_set.update(compute_follow(lhs))
                    else:
                        if lhs != symbol:  # Avoid infinite recursion
                            follow_set.update(compute_follow(lhs))
    
    follows[symbol] = follow_set
    return follow_set

# Input grammar
n = int(input("Enter the number of productions: "))
print("Enter productions in the form A=xyz (use # for epsilon):")

for _ in range(n):
    lhs, rhs = input().split("=")
    productions.setdefault(lhs, []).append(rhs)

# Choosing the first production's LHS as the start symbol
start_symbol = list(productions.keys())[0]

# Compute FIRST sets
for non_terminal in productions:
    compute_first(non_terminal)

# Compute FOLLOW sets
for non_terminal in productions:
    compute_follow(non_terminal)

# Interactive FOLLOW computation
while True:
    symbol = input("Find FOLLOW of --> ")
    if symbol not in productions:
        print(f"'{symbol}' is not a non-terminal!")
        continue

    print(f"FOLLOW({symbol}) = {follows[symbol]}")
    
    choice = input("Do you want to continue? (Press 1 to continue, any other key to exit): ")
    if choice != '1':
        break
