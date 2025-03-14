#include <stdio.h>
#include <ctype.h>

void FIRST(char[], char);
void addToResultSet(char[], char);

int numOfProductions;
char productionSet[10][10];

int main()
{
    int i;
    char choice;
    char result[20];
    char c;

    printf("How many number of productions? : ");
    scanf("%d", &numOfProductions);
    getchar(); // to consume the newline character after scanf

    for(i = 0; i < numOfProductions; i++) // Read production string e.g.: E=TA
    {
        printf("Enter production Number %d: ", i + 1);
        fgets(productionSet[i], sizeof(productionSet[i]), stdin);
    }

    do
    {
        printf("\nFind the FIRST of: ");
        scanf("%c", &c);
        getchar(); // to consume the newline character after scanf
        FIRST(result, c); // Compute FIRST; Get Answer in 'result' array
        printf("\nFIRST(%c) = { ", c);
        for(i = 0; result[i] != '\0'; i++)
            printf("%c", result[i]);
        printf("}\n");
        printf("Press 'y' to continue: ");
        scanf("%c", &choice);
        getchar(); // to consume the newline character after scanf
    } while(choice == 'y' || choice == 'Y');

    return 0;
}

void FIRST(char *Result, char c)
{
    int i, j, k;
    char subResult[20];
    int foundEpsilon = 0;

    // Initialize the result array
    Result[0] = '\0';

    // If X is terminal, FIRST(X) = {X}
    if (!isupper(c)) {
        addToResultSet(Result, c);
        return;
    }

    // If X is a non-terminal, then read each production
    for (i = 0; i < numOfProductions; i++) {
        // Find production with X as LHS
        if (productionSet[i][0] == c) {
            j = 2; // Start with the right-hand side of the production

            while (productionSet[i][j] != '\0') {
                foundEpsilon = 0;
                FIRST(subResult, productionSet[i][j]); // Get FIRST of current symbol

                // Add the symbols of subResult to Result
                for (k = 0; subResult[k] != '\0'; k++)
                    addToResultSet(Result, subResult[k]);

                // Check for epsilon ($)
                for (k = 0; subResult[k] != '\0'; k++) {
                    if (subResult[k] == '$') {
                        foundEpsilon = 1;
                        break;
                    }
                }

                if (!foundEpsilon) break;
                j++; // Move to the next symbol
            }
        }
    }
}

void addToResultSet(char Result[], char val)
{
    int k;
    // Check if the value is already in the result set
    for (k = 0; Result[k] != '\0'; k++) {
        if (Result[k] == val)
            return;
    }
    // If not, add the value to the result
    Result[k] = val;
    Result[k + 1] = '\0';
}
// S=L=R
// S=R
// L=*R
// L=a
// R=L

// How many number of productions? : 5
// Enter production Number 1: S=L=R
// Enter production Number 2: S=R
// Enter production Number 3: L=*R
// Enter production Number 4: L=a
// Enter production Number 5: R=L

// Find the FIRST of: S

// FIRST(S) = { *a}
// Press 'y' to continue: y

// Find the FIRST of: L

// FIRST(L) = { *a}
// Press 'y' to continue: y

// Find the FIRST of: *R

// FIRST(*) = { *}
// Press 'y' to continue: y

// How many number of productions? : 3
// Enter production Number 1: S=AB
// Enter production Number 2: A=a
// Enter production Number 3: B=b

// Find the FIRST of: S

// FIRST(S) = { a}
// Press 'y' to continue: y

// Find the FIRST of: A

// FIRST(A) = { a}
// Press 'y' to continue: y

// Find the FIRST of: B

// FIRST(B) = { b}
// Press 'y' to continue: 