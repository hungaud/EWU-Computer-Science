#include "lab14.h"
#include "./utils/utils.h"

char * readString()
{
   /* You may not change this code */
   char s[MAX]; // MAX is set to 100
   printf("Enter a string: ");
   fgets(s, MAX, stdin);
   strip(s);
   
   
   /* You will need to add your own code below
   And change the return value */
   
   while(strlen(s) == 0 || s[0] == ' ') {
      printf("Invalid String, String length is either 0 or starts with a space!\n");
      printf("Please try again!\n");
      printf("Enter a string: ");
      fgets(s, MAX, stdin);
      strip(s);
   }
   
   char * temp = (char *) calloc(strlen(s) + 1, sizeof(char));
   strcpy(temp, s);
   return temp;
   
}// end readString



char * cleanUp(char * str) {
   free(str);
   str = NULL;
}
char** clean(int argc, char **argv) {
   int i;
   for(i = 0; i < argc; i++) {
      free(argv[i]);
      argv[i] = NULL;
   }
   free(argv);
   argv = NULL;
}
void printargs(int argc, char **argv) {
   int i,j;
   for(i = 0; i < argc; i++) {
      for (j = 0; j < strlen(argv[i]); j++) {
         printf("%c", argv[i][j]);
      }
      printf("\n");
   }
}


char ** makeargs(char *s, int * argc) {
   int tokenCount = 0;
   int i;
   char * temp = (char *) calloc(strlen(s) + 1, sizeof(char));
   strcpy(temp, s);
   
   char * token = strtok(temp, " "); 
   while(token != NULL) {
      token = strtok(NULL, " ");
      tokenCount++;
   }
   
   char ** argv = (char**) calloc(tokenCount, sizeof(char *));   
   strcpy(temp, s);
   token = strtok(temp, " ");
   strip(token);
   argv[0] = (char *) calloc(strlen(token) + 1, sizeof(char));
   strcpy(argv[0], token);
   
   for(i = 1; i < tokenCount; i++) {
      token = strtok(NULL, " ");
      strip(token);
      argv[i] = (char *) calloc(strlen(token) + 1, sizeof(char));
      strcpy(argv[i], token);
   }
   *argc = tokenCount;
   cleanUp(temp);
   return argv;
}
