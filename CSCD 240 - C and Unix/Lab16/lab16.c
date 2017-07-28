#include "lab16.h"


int fillArray(struct Stock array[], FILE * fin) {
   int n = 0;
   char read[100];
   int num;
	fscanf(fin, "%d", &num);

   while(!feof(fin)){
      fgets(read, 100, fin);
      strip(read);
      strncpy(array[n].symbol, read, strlen(read) + 1);
      
      fgets(read, 100, fin);
      strip(read);
      strncpy(array[n].name, read, strlen(read) + 1);
     
      fscanf(fin, "%lf\n", &array[n].price);
      n++;
   }
   return n;
}

int menu() {
   int choice;
   printf("========== MENU ==========");
   printf("\n1) Print the array sorted by Symbol");
   printf("\n2) Print the array sroted by Company's Name");
   printf("\n3) Print the array sorted by Current Price");
   printf("\n4) Quit\n");
   scanf("%d", &choice); 
   while(choice > 4 || choice < 1) {
      printf("Invalid choice, must pick 1 - 4\n");
      scanf(" %d", &choice);
   }
   return choice;
}

int compareSymbols(const void * one, const void * two) {
  struct Stock * stock1 = (struct Stock*) one;
  struct Stock * stock2 = (struct Stock*) two;
   
   return strcmp(stock1->symbol, stock2->symbol);
   
   
}

int compareNames(const void * one, const void * two) {
   struct Stock * stock1 = (struct Stock*) one;
   struct Stock * stock2 = (struct Stock*) two;
   
   return strcmp(stock1->name, stock2->name);
   
}

int comparePrices(const void * one, const void * two) {
   int n;
   struct Stock * stock1 = (struct Stock*) one;
   struct Stock * stock2 = (struct Stock*) two;
   if(stock1->price < stock2->price) {
      n = -1;
   } else if(stock1->price > stock2->price) {
      n = 1;
   } else {
      n = 0;
   }
   
   return n;
}

void printArray(struct Stock array[], int total) {
   int i;
   for(i = 0; i < total; i++) {
      printf("%s - %s - %f \n", array[i].name, array[i].symbol, array[i].price);
   }
}


