#ifndef LAB12_H
#define LAB12_H

#include<stdio.h>
#include<stdlib.h>
#include<math.h>

double findMean(int * numbers, int total);
double findMedian(int total, int * numbers);
double findStdDev(int * numbers, int total);
void displayResults(FILE * out, double mean, double median, double stdDev);
void cleanUp(int * array);

#endif
