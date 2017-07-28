#include "arrayUtils.h"

int readTotal(FILE * fin) {
   int total;
      fscanf(fin, "%d ", &total);
      if(!feof(fin)) {
         printf("\ntotal of array is: %d \n", total);
      } else {
         printf("\n");
      }
   return total;
}

int * fillArray(FILE * fin, int total) {
   int * array = (int *) calloc(total, sizeof(int));
   int i;
   for(i = 0; i < total; i++) {
      fscanf(fin, "%d ", &array[i]);
      printf("%d ", array[i]);
     
   }
   return array;
}