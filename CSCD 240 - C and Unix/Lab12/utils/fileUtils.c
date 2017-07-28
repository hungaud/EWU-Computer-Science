#include "fileUtils.h"
#include"utils.h"
#include<stdio.h>
#include<stdlib.h>
#include<string.h>

FILE * openInputFile() {
   FILE * fin = NULL;
   char temp[MAX];
   do {
      printf("Input file to read: ");
      fgets(temp, MAX, stdin);
      strip(temp);
      fin = fopen(temp, "r");      
   } while(fin == NULL);
   return fin;
}

FILE * openOutputFile() {
   FILE * fout = NULL;
   char temp[MAX];
   printf("Output file: ");
   fgets(temp, MAX, stdin);
   strip(temp);
   fout = fopen(temp, "w");
   if(fout == NULL) {
      perror("There was an error opening output File");
      exit(-1);
   }
   return fout;
}