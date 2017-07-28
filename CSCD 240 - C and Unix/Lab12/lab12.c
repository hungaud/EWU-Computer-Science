#include "lab12.h"


double findMean(int * numbers, int total) {
   int i;
   double n = 0;
   for(i = 0; i < total; i++) {
      n += numbers[i];
   }
   n = n / total;
   printf("\nMean: %.2f", n);
   return n;

}

double findMedian(int total, int * numbers) {
   double sum;
   int a, b;
   int i, j, temp, swap;
   for(i = 0; i < total - 1; i++) {
      temp = i;
      for(j = i + 1; j < total; j++) {
         if(numbers[temp] > numbers[j]) {
            temp = j;
         }
      }
      if(temp != i) {
         swap = numbers[i];
         numbers[i] = numbers[temp];
         numbers[temp] = swap;
      }
   }
   if(total % 2) {
      a = total / 2;
      sum = numbers[a];
   } else {
      a = total / 2;
      b = a - 1;
      sum = (numbers[a] + numbers[b]) / 2;
   }
   printf("\nMedian: %.2f", sum);
   return sum;
}

double findStdDev(int * numbers, int total) {
   int i;
   double sum = 0;
   double mean = findMean(numbers, total);
   double * deviation = (double *) calloc(total, sizeof(double));
   for(i = 0; i < total; i++) {
      deviation[i] = numbers[i] - mean;
      deviation[i] = deviation[i] * deviation[i];
      sum += deviation[i];
   }
   sum = sum / (total - 1);
   sum = sqrt(sum);
   printf("\nStandard Deviation: %f", sum);
   free(deviation);
   deviation = NULL;
   return sum;

}

void displayResults(FILE * out, double mean, double median, double stdDev) {
   fprintf(out, "The mean, median, and standard deviation are: %.2f, %.2f, %.2f \n", mean, median, stdDev);
}

void cleanUp(int * array) {
   free(array);
   array = NULL;
}

