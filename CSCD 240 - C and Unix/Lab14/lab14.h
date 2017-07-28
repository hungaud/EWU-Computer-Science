#ifndef LAB14_H
#define LAB14_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 100

char * cleanUp(char * str);
char** clean(int argc, char **argv);
void printargs(int argc, char **argv);
char ** makeargs(char *s, int * argc);
char * readString();

#endif
