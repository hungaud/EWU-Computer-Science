#include "lab13.h"
#include "./utils/utils.h"

int menu() {
   int n;
   printf("\n========== Menu ==========\nChoose from the following\n");
   printf("1.) print triangle normal \n2.) print triangle to file \n");
   printf("3.) create new triangle \n4.) quit \n");
   scanf("%d", &n);
   while(n < 1 || n > 4) {
      printf("Please choose a valid option");
      scanf("%d", &n);
   }
   return n;
}

int readTotal() {
   int n;
   printf("Total size of Pascal's Triangle\n");
   scanf("%d", &n);
   while(n < 0) {
      printf("Please choose a valid option (number must be greater than or equal to 0)");
      scanf("%d", &n);
   }
      stripInputBuffer(stdin);
   return n;
}

int ** createTriangle(int n) {
   int i, j;
   int left, right;
   int ** twod = (int **) calloc(n, sizeof(int*));
   for(i = 0; i < n; i++) {
      twod[i] = (int *) calloc (i + 1, sizeof(int));
      for(j = 0; j <= i; j++) {
         if(i == 0) {
            //twod[i][j] = 1;
            right = 1;
            left = 0;
         } else {
            if(j - 1 < 0) {
               left = 0;
            } else {
               left = twod[i - 1][j - 1];
            }
            if(j == i) {
               right = 0;
            } else {
               right = twod[i - 1][j];
            }
         }
         twod[i][j] = right + left;
        // printf(" %d %d", right, left);
      }
   }
   return twod;
}

int retrieveTotal(char * argv) {
   int n = atoi(argv);
   if(n < 0) {
      printf("Input number is negative. Please try again!\n");
      n = readTotal();
   }
   return n;
}

void cleanUp(int ** pascal, int n) {
   int i;
   for(i = 0; i < n; i++) {
      free(pascal[i]);
      pascal[i] = NULL;
   }
   free(pascal);
   pascal = NULL;
}

void printTriangle(FILE * fout, int ** pascal, int n) {
   int i, j;
         printf("\n");
   for(i = 0; i < n; i++) {
      for(j = 0; j <= i; j++) {
         fprintf(fout, "%d ", pascal[i][j]);
      }
      fprintf(fout, "\n");
   }
}

