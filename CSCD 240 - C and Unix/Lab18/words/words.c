#include "words.h"

void printWord(void * passedIn) {
   Words * temp = (Words *) passedIn;
   int length = strlen(temp->word);
   printf("%s - %d, ", temp->word, length);
}

void * buildWord(FILE * fin) {
   if(fin == NULL) {
      printf("\nfile passed in is null\n");
      exit(-1);
   }
   char temp[100];
   Words * tempWord = (Words *)calloc(1, sizeof(Words));
   int length;
   fscanf(fin, "%s", temp);
   strip(temp);
   length = strlen(temp);
   tempWord->word = (char *)calloc(length + 1, sizeof(char));
   strcpy(tempWord->word, temp);
   tempWord->length = length;
   return (void *)tempWord;
}


void * buildWord_Prompt(FILE * in) {
   if(in == NULL) {
      printf("\nthe in passed in is null\n");
      exit(-1);
   }
   char temp[100];
   Words * tempWord = (Words *)calloc(1, sizeof(Words));
   int length;
   printf("Word: ");
   fscanf(in, "%s", temp);
   strip(temp);
   length = strlen(temp);
   tempWord->word = (char *)calloc(length + 1, sizeof(char));
   strcpy(tempWord->word, temp);
   tempWord->length = length;
   return (void *)tempWord;

}


int compareTwoWords(const void * p1, const void * p2) {
   if(p1 == NULL || p2 == NULL) {
      printf("\nOne of the words being compared to is null\n");
      exit(-1);
   }   
   Words * first = (Words *) p1;
   Words * second = (Words *) p2;
   return strcmp(first->word, second->word);
}

void cleanWord(void * obj) {
   Words * temp = (Words *)obj;
   free(temp->word);
   temp->length = 0;
   free(temp);
}

