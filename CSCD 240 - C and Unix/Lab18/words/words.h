#ifndef WORDS_H
#define WORDS_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>


struct words
{
   char * word;
   int length;
};

typedef struct words Words;

void printWord(void * passedIn);
void * buildWord(FILE *);
void * buildWord_Prompt(FILE *);
int compareTwoWords(const void * p1, const void * p2);
void cleanWord(void *);


#endif // WORDS_H
