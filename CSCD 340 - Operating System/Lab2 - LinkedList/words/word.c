#include "word.h"

void cleanTypeWord(void * ptr) {
   Word * temp = (Word *)ptr;
   int i;
   int n = temp->len;
   for(i = 0; i < n; i++) {
      free(temp[i].ltrs);
   }
   temp->len = 0;
   free(temp);
   temp = NULL;
}


void * buildTypeWord(FILE * fin) {
   if(fin == NULL) {
      printf("\nfile passed in is null\n");
      exit(-1);
   }
   char temp[100];
   Word * tempWord = (Word *)calloc(1, sizeof(Word));
   int length;
   fscanf(fin, "%s ", temp);
   strip(temp);
   length = strlen(temp);
   tempWord->ltrs = (char *)calloc(length + 1, sizeof(char));
   strcpy(tempWord->ltrs, temp);
   tempWord->len = length;
   return (void *)tempWord;
}

void printTypeWord(void * passedIn) {
   Word * temp = (Word *) passedIn;
   int length = strlen(temp->ltrs);
   printf("%s, ", temp->ltrs);
}


void * buildTypeWord_Prompt(FILE * in) {
   if(in == NULL) {
      printf("\nthe in passed in is null\n");
      exit(-1);
   }
   char temp[100];
   Word * tempWord = (Word *)calloc(1, sizeof(Word));
   int length;
   printf("Word: ");
   fgets(temp, MAX, stdin);
   strip(temp);
   length = strlen(temp);
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


