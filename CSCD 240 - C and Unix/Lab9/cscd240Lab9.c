/*
   To run this file in the unix command line,
   ./lab9 < inputFile.txt > outputFile.txt
*/

#include "lab9.h"


int main()
{
    //Initialize variables
    int square[10][10];
    int solutions, days, currSol, currDay;
    int solution[16];

    //Get # of solutions and days from input
    solutions = getSolutions();
    days = getDays();
    for (currSol = 0; currSol < solutions; currSol++)
    {
        fillArray(solution, SOL_MAX);
        fillSquare(square, SQUARE_MAX);
        printf("\nSolution:\n");
        displaySolution(solution, SOL_MAX);
        //Begin running the solution
        for(currDay = 0; currDay <= days; currDay++)
        {
            printf("\nGeneration: %i\n\n", currDay);
            displayMatrix(square, SQUARE_MAX);
            runSolution(square, solution);
        }// end for

    }// end for

    return 0;

}// end main
