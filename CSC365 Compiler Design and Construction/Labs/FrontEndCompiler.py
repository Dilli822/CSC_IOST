import re

# Token definitions (Fixed Multi-Character Operators)
TOKEN_SPEC = [
    ('COMPARE', r'(<=|>=|==|!=)'),
    ('ASSIGN', r'='),
    ('OPERATOR', r'[+\-*/<>]'),
    ('KEYWORD', r'\b(int|float|if|else|while|return)\b'),
    ('IDENTIFIER', r'[a-zA-Z_]\w*'),
    ('NUMBER', r'\d+(\.\d+)?'),
    ('SEPARATOR', r'[(){},;]'),
    ('WHITESPACE', r'\s+'),
    ('UNKNOWN', r'.')
]

TOKEN_REGEX = '|'.join(f'(?P<{name}>{pattern})' for name, pattern in TOKEN_SPEC)

def tokenize(source_code):
    tokens = []
    for match in re.finditer(TOKEN_REGEX, source_code):
        token_type = match.lastgroup
        token_value = match.group(token_type)
        if token_type != 'WHITESPACE':
            tokens.append((token_type, token_value))
    return tokens

# Parser (Fixed Declarations and Assignments)
class Parser:
    def __init__(self, tokens):
        self.tokens = tokens
        self.pos = 0

    def match(self, expected_type):
        if self.pos < len(self.tokens) and self.tokens[self.pos][0] == expected_type:
            self.pos += 1
            return True
        return False

    def parse_declaration(self):
        """Handles declarations like int x = 10;"""
        if self.match('KEYWORD') and self.match('IDENTIFIER'):
            if self.match('ASSIGN'):
                return self.parse_expression() and self.match('SEPARATOR')
            return self.match('SEPARATOR')
        return False

    def parse_expression(self):
        """Handles expressions like x + y"""
        if self.match('IDENTIFIER') or self.match('NUMBER'):
            while self.match('OPERATOR'):
                if not (self.match('IDENTIFIER') or self.match('NUMBER')):
                    return False  # Expect an identifier or number after operator
            return True
        return False

    def parse_assignment(self):
        """Handles assignments like x = 10;"""
        if self.match('IDENTIFIER') and self.match('ASSIGN') and self.parse_expression():
            return self.match('SEPARATOR')
        return False

    def parse(self):
        while self.pos < len(self.tokens):
            if not (self.parse_declaration() or self.parse_assignment()):
                return False
        return True

# Intermediate Code Generator (Fixed Variable Assignments)
class IntermediateCodeGenerator:
    def __init__(self):
        self.temp_count = 0
        self.code = []

    def new_temp(self):
        self.temp_count += 1
        return f"t{self.temp_count}"

    def generate_tac(self, tokens):
        tac = []
        i = 0
        while i < len(tokens):
            if tokens[i][0] == 'IDENTIFIER' and i + 2 < len(tokens) and tokens[i + 1][0] == 'ASSIGN':
                var = tokens[i][1]
                val = tokens[i + 2][1]

                temp_var = self.new_temp()
                tac.append(f"{temp_var} = {val}")
                tac.append(f"{var} = {temp_var}")
                i += 3
            else:
                i += 1
        return tac

# Main Execution
def main():
    source_code = """
    int x = 10;
    float y = 5;
    Z = x + y;
    """

    print("\n### Lexical Analysis (Tokens) ###")
    tokens = tokenize(source_code)
    for token in tokens:
        print(token)

    print("\n### Syntax Analysis ###")
    parser = Parser(tokens)
    if parser.parse():
        print("Syntax is Valid")
    else:
        print("Syntax Error")
        return

    print("\n### Intermediate Code Generation (Three-Address Code) ###")
    icg = IntermediateCodeGenerator()
    tac = icg.generate_tac(tokens)
    for line in tac:
        print(line)

main()
