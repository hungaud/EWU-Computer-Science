// Hung Auduong
// CSCD 240 
// Lab 9


#include "lab9.h"

// post: gets the number of solution that will be ran.
int getSolutions() {
   int solution;
   scanf("%d", &solution);
   return solution;
}

// post: gets the number of generation that each solution will go through
int getDays() {
   int days;
   scanf("%d", &days);
   return days;
}

// post: fill in the solution number
void fillArray(int solArray[], int total) {
   int i;
   for(i = 0; i < total; i++) {
      int num;
      scanf("%d", &num);
      solArray[i] = num;
   }
}

// post: fills in the matrix of the petrie dish.
void fillSquare(int array[][SQUARE_MAX], int total) {
   int i, j;
   for(i = 0; i < total; i++) {
      for(j = 0; j < total; j++) {
         int cellNumber;
         scanf("%d", &cellNumber);
         array[i][j] = cellNumber;
      }
   }
}

// post: runs the solution of what will happen for the current generation.
void runSolution(int array[][SQUARE_MAX], int solArray[] ) {
   int i, j, solNumber;
   int row, col;
   int tempArray[10][10];
   for(row = 0; row < SQUARE_MAX; row++) {
      for(col = 0; col < SQUARE_MAX; col++) {
         tempArray[row][col] = array[row][col];
      }
   }
   for(i = 0; i < SQUARE_MAX; i++) {
      for(j = 0; j < SQUARE_MAX; j++) {
         solNumber = array[i][j];
         if(j != 0) {
            solNumber += array[i][j-1];
         }
         if(j != 9) {
            solNumber += array[i][j+1];     
         }
         if(i != 0) {
            solNumber += array[i-1][j];
         }
         if(i != 9) {
            solNumber += array[i+1][j];
         }
         tempArray[i][j] += solArray[solNumber];         
         
         if(tempArray[i][j] > 3) {
            tempArray[i][j] = 3;
         } else if(tempArray[i][j] < 0) {
            tempArray[i][j] = 0;
         }      
      }
   }
   for(row = 0; row < SQUARE_MAX; row++) {
      for(col = 0; col < SQUARE_MAX; col++) {
         array[row][col] = tempArray[row][col];
      }
   } 
}

// post: display the solution array
void displaySolution(int solArray[], int total) {
   int i;
   for(i = 0; i < total; i++) {
      printf("%d ", solArray[i]);
   }
}

// post: display the matrix of the petrie dish. with symbols representing if
//       the bacteria grew or not.
void displayMatrix(int array[][SQUARE_MAX], int total) {
   int i, j;
   char symbol;
   for(i = 0; i < 10; i++) {
      for(j = 0; j < 10; j++) {
         if(array[i][j] == 0) {
            printf(".");
         } else if(array[i][j] == 1) {
            printf("!");
         } else if(array[i][j] == 2) {
            printf("X");
         } else if(array[i][j] == 3) {
            printf("#");
         }
      }
      printf(" \n");
   }
}