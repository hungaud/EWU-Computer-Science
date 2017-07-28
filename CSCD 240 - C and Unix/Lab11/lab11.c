// Hung Auduong
// CSCD 240
// Lab 11
//


#include "lab11.h"
#include <stdio.h>
#include <stdlib.h>
#include "string.h"


//post: reads in the inital length of the array 
int readInitialLength() {
   int n;
   printf("Length of Array :");
   scanf("%d", &n);
   while(n < 1) {
      printf("Invalid input, Length must be greater than 0, Please try again \n");
      scanf("%d", &n);
   }
   return n;
}

//post: creates the array based on the length with elements.
int * createAndFill(int num) {
   int * array = (int *) calloc(num, sizeof(int));
   int x;
   for(x = 0; x < num; x++) {
      array[x] = x * 10 + 1;
   }
   return array;
}

//post: allows the user to choose 4 options what to do with the array
int menu() {
   int n;
   do {
      printf("Menu, choose one of the following \n");
      printf("1: printSortedArray \n");
      printf("2: addItem \n");
      printf("3: readValue \n");
      printf("4: quit \n");
      scanf("%d", &n);
   } while (n < 1 || n > 4);
   return n;
}

//post: prints out the elements in the array in sorted order from
//       least to greatest
void printSortedArray(int *array, int length) {
   int i, j, temp, swap;
   for(i = 0; i < length - 1; i++) {
      temp = i;
      for(j = i + 1; j < length; j++) {
         if(array[temp] > array[j]) {
            temp = j;
         }
      }
      if(temp != i) {
         swap = array[i];
         array[i] = array[temp];
         array[temp] = swap;
      }
   }
   for(i = 0; i < length; i++) {
      printf("%d ", array[i]);
   }
   printf("\n");
}

//post: add the number 42 to the dynamic array
int * addItem(int *length, int *array) {
   int tempNum = * length;
   tempNum += 1;
   int * temp = (int *) calloc(tempNum, sizeof(int));
   int i;
   for(i = 0; i < * length; i++) {
      temp[i] = array[i];
   }
   temp[i] = 42;
   *length = tempNum;
   cleanUp(array);
   return temp;
}

//post: reads in a number that the user wish to search in the array
int readValue() {
   int n;
   printf("Value: ");
   scanf("%d", &n);
   return n;
}

//post: will search the array for the value that the user inputs.
//      if it is found, then itll print out the value and the 
//      index it is found in the arary
void printIfFound(int value, int * array, int length) {
   int count = 0;
   while(value != array[count] && count < length) {
      count++;
   }
   if(value == array[count]) {
      printf("%d was found at index %d \n", value, count);
   }
}

//post: cleans the array 
void cleanUp(int * array) {
   free(array);
   array = NULL;
}

