#ifndef LAB10_H
#define LAB10_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 100

int playAgain();
void instructions();
void readName(char *);
void readWord(char *);
int playGame(char *, char *, int);
void printResults(int, char *, char *);
int isLetterInWord(char, char *, char *, int);

#endif
