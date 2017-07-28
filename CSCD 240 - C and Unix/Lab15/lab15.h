#ifndef LAB15_H
#define LAB15_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct Stock
{
   char symbol[10];
   char name[100];
   double price;

};

int fillArray(struct Stock array[], FILE * fin);
int menu();
void symbolSort(struct Stock array[], int total);
void printArray(struct Stock array[], int total);
void companySort(struct Stock array[], int total);
void priceSort(int total, struct Stock array[]);



#endif
