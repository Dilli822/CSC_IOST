def parse():
    # Parsing Table (m)
    m = [
        ["tb", "", "", "tb", "", ""],
        ["", "+tb", "", "", "n", "n"],
        ["fc", "", "", "fc", "", ""],
        ["", "n", "*fc", "", "n", "n"],
        ["i", "", "", "(e)", "", ""]
    ]

    # Size array (size)
    size = [
        [2, 0, 0, 2, 0, 0],
        [0, 3, 0, 0, 1, 1],
        [2, 0, 0, 2, 0, 0],
        [0, 1, 3, 0, 1, 1],
        [1, 0, 0, 3, 0, 0]
    ]

    # Input string and stack initialization
    s = input("Enter the input string: ") + "$"
    n = len(s)
    stack = ['$','e']
    i = 1
    j = 0

    print("\nStack\tInput")

    while stack[i] != '$' and s[j] != '$':
        print()

        if stack[i] == s[j]:
            i -= 1
            j += 1
        else:
            # Determine the current non-terminal and terminal symbols
            if stack[i] == 'e':
                str1 = 0
            elif stack[i] == 'b':
                str1 = 1
            elif stack[i] == 't':
                str1 = 2
            elif stack[i] == 'c':
                str1 = 3
            elif stack[i] == 'f':
                str1 = 4

            if s[j] == 'i':
                str2 = 0
            elif s[j] == '+':
                str2 = 1
            elif s[j] == '*':
                str2 = 2
            elif s[j] == '(':
                str2 = 3
            elif s[j] == ')':
                str2 = 4
            elif s[j] == '$':
                str2 = 5

            if m[str1][str2] == '':
                print("\nERROR")
                return
            elif m[str1][str2] == 'n':
                i -= 1
            elif m[str1][str2] == 'i':
                stack[i] = 'i'
            else:
                for k in range(size[str1][str2] - 1, -1, -1):
                    stack.insert(i, m[str1][str2][k])
                    i += 1
                i -= 1

            # Print the current state of the stack and input
            print("".join(stack[:i+1]), "\t", s[j:])

    print("\nSUCCESS")

# Call the parser function
parse()
