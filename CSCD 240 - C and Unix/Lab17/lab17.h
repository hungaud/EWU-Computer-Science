#ifndef LAB17_H
#define LAB17_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>


struct address
{
    char * street;
    char * city;
    char * state;
    int zip;
};

typedef struct address Address;


Address * fillArray(int * total, FILE * fin);
void printArray(Address * array, int total);
void cleanUp(Address * array, int total);

int menu();



int compareStreet(const void * one, const void * two);
int compareCity(const void * one, const void * two);
int compareStateCityZip(const void * one, const void * two);
int compareZip(const void * one, const void * two);

void selectionSort(Address * array, int total, int (*f)(const void * one, const void * two));

#endif

