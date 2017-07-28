#ifndef LAB13_H
#define LAB13_H

#include <stdio.h>
#include <stdlib.h>

int menu();
int readTotal();
int ** createTriangle(int n);
int retrieveTotal(char * argv);
void cleanUp(int ** pascal, int n);
void printTriangle(FILE * fout, int ** pascal, int n);

#endif
