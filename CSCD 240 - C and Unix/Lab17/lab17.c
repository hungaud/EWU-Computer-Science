#include "lab17.h"



int menu() {
   int n;
   printf("========== MENU ==========");
   printf("\n1) Print the array sorted by Street");
   printf("\n2) Print the array sroted by City");
   printf("\n3) Print the array sorted by State then City then by Zip");
   printf("\n4) Print the array sorted by Zip");
   printf("\n5) Quit\n");
   scanf("%d", &n);
   while(n < 1 || n > 5) {
      printf("Invalid choice, Please choose between 1-5\n");
      scanf("%d", &n);
   }
   return n;
}

Address * fillArray(int * total, FILE * fin) {
   char temp[100];
   Address * array;
   Address tempAdd;
   int count = 0;
   int length;
   int i;
   while(fgets(temp, 100, fin) != NULL) {
      count++;
   }
   rewind(fin);
   *total = (count + 1)/4;

   
   array = (Address *) calloc(*total, sizeof(Address));
   for(i = 0; i < count; i++) {
      fgets(temp, 100, fin);
      strip(temp);
      length = strlen(temp) + 1;
      if((i % 4) == 0) {
         tempAdd.street = calloc(length, sizeof(char));
         strcpy(tempAdd.street, temp);
      } else if((i % 4) == 1) {
         tempAdd.city = calloc(length, sizeof(char));
         strcpy(tempAdd.city, temp);
      } else if ((i % 4) == 2) {
         tempAdd.state = calloc(length, sizeof(char));
         strcpy(tempAdd.state, temp);
      } else if ((i % 4) == 3) {
         tempAdd.zip = atoi(temp);
      }
      array[i/4] = tempAdd;
   }
   return array;
}





void printArray(Address * array, int total) {
   int i;
   for(i = 0; i < total; i++) {
      printf("%s\n", array[i].street);
      printf("%s %s %d\n", array[i].city, array[i].state, array[i].zip);
   }
}

void cleanUp(Address * array, int total) {
   int i;
   for(i = 0; i < total; i++){
     free(array[i].state);
     free(array[i].city);
     free(array[i].street);
    }
   free(array);
}




int compareStreet(const void * one, const void * two) {
   struct address * addressOne = (struct address *) one;
   struct address * addressTwo = (struct address *) two;
   return strcmp(addressOne->street, addressTwo->street);
   
}

int compareCity(const void * one, const void * two) {
   struct address * addressOne = (struct address *) one;
   struct address * addressTwo = (struct address *) two;
   return strcmp(addressOne->city, addressTwo->city);
   
}


int compareStateCityZip(const void * one, const void * two) {
   int n;
   struct address * addressOne = (struct address *) one;
   struct address * addressTwo = (struct address *) two;
   n = strcmp(addressOne->state, addressTwo->state);
   if(n == 0) {
      n = compareCity(one, two);
      if(n == 0) {
         n = compareZip(one, two);
      }
   }   
   return n;
}


int compareZip(const void * one, const void * two) {
   int n;
   struct address * addressOne = (struct address *) one;
   struct address * addressTwo = (struct address *) two;
   if(addressOne->zip < addressTwo->zip) {
      n = -1;
   } else if (addressOne->zip > addressTwo->zip) {
      n = 1;
   } else {
      n = 0;
   }
   return n;
}


void selectionSort(Address * array, int total, int (*f)(const void * one, const void * two)) {
   Address temp;
   int start, search, min;
   for(start = 0; start < total - 1; start++) {
      min = start;
      for(search = start + 1; search < total; search++) {
         if((*f)(&array[search], &array[min]) < 0) {
            min = search;
         }
      }
      temp = array[min];
      array[min] = array[start];
      array[start] = temp;
   }
}


