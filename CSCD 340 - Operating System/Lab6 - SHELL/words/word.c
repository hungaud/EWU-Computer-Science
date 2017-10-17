#include "word.h"

void cleanTypeWord(void * ptr) {
   if(ptr == NULL) {
      printf("CLean type ptr was null");
      exit(-99);
   }
   Word * temp = (Word *)ptr;
   free(temp->ltrs);
   temp->ltrs = NULL;
   temp->len = 0;
   free(temp);
}


void * buildTypeWord(FILE * fin) {
   if(fin == NULL) {
      printf("\nfile passed in is null\n");
      exit(-1);
   }
   char temp[100];
   Word * tempWord = (Word *)calloc(1, sizeof(Word));

   fgets(temp, 100, fin);
   strip(temp);
   //printf("%s \n", temp);
   int length = strlen(temp);
   tempWord->ltrs = (char *)calloc(length + 1, sizeof(char));
   strcpy(tempWord->ltrs, temp);
   tempWord->len = length;
   return (void *)tempWord;
}

void printTypeWord(void * passedIn) {
   if(passedIn == NULL) {
      printf("print type passedin was Null");
      exit(-99);
   }
   Word * temp = (Word *) passedIn;
   int length = strlen(temp->ltrs);
   printf("%s - %d\n", temp->ltrs, length);
}


void * buildTypeWord_Prompt(FILE * in) {
   if(in == NULL) {
      printf("\nthe in passed in is null\n");
      exit(-1);
   }
   char temp[100];
   Word * tempWord = (Word *)calloc(1, sizeof(Word));
   printf("Word: ");
   fgets(temp, MAX, in);
   strip(temp);
   int length = strlen(temp);
   tempWord->ltrs = (char *)calloc(length + 1, sizeof(char));
   strcpy(tempWord->ltrs, temp);
   tempWord->len = length;
   printf("\n");
   return (void *)tempWord;

}


int compareWord(const void * p1, const void * p2) {
   if(p1 == NULL) {
      printf("\nOne of the words being compared to is null (1)\n");
      exit(-1);
   } 
   if(p2 == NULL) {
      printf("\nOne of the words being compared to is null (2)\n");
      exit(-1);
   }   
   Word * first = (Word *) p1;
   Word * second = (Word *) p2;
   return strcasecmp(first->ltrs, second->ltrs);
}


