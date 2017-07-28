#include "lab15.h"

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
   printf("\n2) Print the array sroted by Compnay's Name");
   printf("\n3) Print the array sorted by Current Price");
   printf("\n4) Quit\n");
   scanf("%d", &choice); 
   while(choice > 4 || choice < 1) {
      printf("Invalid choice, must pick 1 - 4\n");
      scanf(" %d", &choice);
   }
   return choice;
}

void symbolSort(struct Stock array[], int total) {
   int start, search, min;
   struct Stock temp;
   for(start = 0; start < total - 1; start++) {
      min = start;
      for(search = start + 1; search < total; search++) {
         if(strcmp(array[search].symbol, array[min].symbol) < 0) {
            min = search;
         }
      }
      temp = array[min];
      array[min] = array[start];
      array[start] = temp;
   }
}

void companySort(struct Stock array[], int total) {
   int start, search, min;
   struct Stock temp;
   for(start = 0; start < total - 1; start++) {
      min = start;
      for(search = start + 1; search < total; search++) {
         if(strcmp(array[search].name, array[min].name) < 0) {
            min = search;
         }
      }
      temp = array[min];
      array[min] = array[start];
      array[start] = temp;
   }
}

void priceSort(int total, struct Stock array[]) {
   int start, search, min;
   struct Stock temp;
   for(start = 0; start < total - 1; start++) {
      min = start;
      for(search = start + 1; search < total; search++) {
         if(array[search].price < array[min].price) {
            min = search;
         }
      }
      temp = array[min];
      array[min] = array[start];
      array[start] = temp;
   }
}

void printArray(struct Stock array[], int total) {
   int i;
   for(i = 0; i < total; i++) {
      printf("%s - %s - %f \n", array[i].name, array[i].symbol, array[i].price);
   }
}