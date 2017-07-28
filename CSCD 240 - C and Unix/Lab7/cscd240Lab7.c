// Hung Auduong
// cscd 240
// Lab 7

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define FLAT_R 5
#define FLAT_C 1000
#define FLAT_I_SUB4SUB4 1000
#define FLAT_I_SUB4OVER4 2000
#define PER_GAL_R 0.0005
#define PER_GAL_C 0.00025
#define PER_GAL_I 0.00025
#define METER_MAX 999999999

int main() {
   //char name[MAX];
   char code;
   int meterBegin;
   int meterEnd;
   double gallonsUsed;
   double cost;
   
   printf("Please Enter the customer code:");
   scanf("%c", &code);
   while (fgetc(stdin) != '\n') {}
   
   printf("Please enter the begining meter reading:");
   scanf("%d", &meterBegin);
   while (fgetc(stdin) != '\n') {}
   
   printf("Please enter the ending meter reading:");
   scanf("%d", &meterEnd);
   while (fgetc(stdin) != '\n') {}
   
   if(meterBegin <= meterEnd) {
      gallonsUsed = (meterEnd - meterBegin)/10.0;
   } else {
      gallonsUsed = (METER_MAX - meterBegin + meterEnd) / 10.0;
   }
   
   //Bills
   if(code == 'r' || code == 'R') {
      cost = FLAT_R + PER_GAL_R * gallonsUsed;
   } else if (code == 'c' || code == 'C') {
      if(gallonsUsed <= 4000000) {
         cost = FLAT_C * 1.0;
      } else {
         cost = FLAT_C + PER_GAL_C * (gallonsUsed - 4000000.0);
      }
   } else {
      if(gallonsUsed <= 4000000) {
         cost = FLAT_I_SUB4SUB4;
      } else if(gallonsUsed <= 10000000) {
         cost = FLAT_I_SUB4OVER4;
      } else {
         cost = FLAT_I_SUB4OVER4 + PER_GAL_I * (gallonsUsed - 10000000);
      }
   }
   
   printf("The customer's code is: %c \n", code);
   printf("The customer's begining meter reading is: %d \n", meterBegin);
   printf("The customer's ending meter reading is: %d \n", meterEnd);
   printf("The customer used %.1lf gallons of water. \n", gallonsUsed);
   printf("The customer's bill is: $%.2lf \n", cost);

   return 0;
}