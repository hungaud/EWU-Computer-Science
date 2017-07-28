#include "myUtils.h"

int menu() {
   int n;
   printf("\n1) Print the list \n");
   printf("2) Add First \n");
   printf("3) Add Last \n");
   printf("4) Sort the List (ascending order) \n");
   printf("5) Delete a Word \n"); 
   printf("6) Quit \n"); 
   scanf(" %d", &n);
   if(n > 6 || n < 1) {
      printf("Please choose a valid input\n");
      scanf(" %d", &n);
   }
   return n;
}

int countRecords(FILE * fin, int per) {
   char temp[100];
   int count = 0;
   while(fgets(temp, 100, fin) != NULL) {
      count++;
   }
   rewind(fin);
   return count;
}
