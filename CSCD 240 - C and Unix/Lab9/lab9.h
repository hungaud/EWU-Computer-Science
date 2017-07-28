#ifndef LAB9_H
#define LAB9_H


#include <stdio.h>
#include <stdlib.h>

#define SOL_MAX 16
#define SQUARE_MAX 10

int getSolutions();
int getDays();
void fillArray(int[], int);
void fillSquare(int[][SQUARE_MAX], int);
void runSolution(int[][SQUARE_MAX], int[]);
void displaySolution(int[], int);
void displayMatrix(int[][SQUARE_MAX], int);


#endif // LAB9_H
