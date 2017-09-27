#include "movie.h"


 
void cleanTypeMovie(void * ptr) {
   if(ptr == NULL) {
      printf("Attempted to clean list of movies but List passed in is empty");
      exit(-99);
   }
   int i;
   Movie * temp = (Movie *) ptr;
   free(temp->title);
   for(i = 0; i < temp->totalActors; i++) {
      free(temp->actors[i].first);
      free(temp->actors[i].last);
      temp->actors[i].first = NULL;
      temp->actors[i].last = NULL;
   }
   free(temp->actors);
   temp->actors = NULL;
   temp->title = NULL;
   free(temp);
 
}

 
void * buildTypeMovie(FILE * fin) {
   if(fin == NULL) {
      printf("Attempt to build movie but file passed in was null");
      exit(-99);
   }
   char temp[100];
   int numActors, i;
   Movie * movie = (Movie *)calloc(1, sizeof(Movie));
   fgets(temp, 100, fin);
   strip(temp);

   
   movie->title = (char *)calloc(strlen(temp) + 1, sizeof(char));
   strcpy(movie->title, temp);
   
   fgets(temp, 100, fin);
   strip(temp);
   numActors = atoi(temp);

   Actor * actor = (Actor *) calloc(numActors, sizeof(Actor));
   for(i = 0; i < numActors; i++) {
      fscanf(fin, "%s", temp);
      strip(temp);
      actor[i].first = (char *) calloc(strlen(temp) + 1, sizeof(char));
      strcpy(actor[i].first, temp);
     
      fscanf(fin, "%s ", temp);
      strip(temp);
      actor[i].last = (char *) calloc(strlen(temp) + 1, sizeof(char));
      strcpy(actor[i].last, temp);
      movie->actors = actor;
   }
   movie->totalActors = numActors;
   return (void *) movie;
   
}

void printTypeMovie(void * passedIn) {
   if(passedIn == NULL) {
      printf("Attempt to build movie but passed in was null");
      exit(-99);
   }
   int i;
   Movie * movie = (Movie *) passedIn;
   printf("%s \n", movie->title);
   printf("%d \n", movie->totalActors);
   for(i = 0; i < movie->totalActors; i++) {
      printf("%s %s\n", movie->actors[i].first, movie->actors[i].last);
   }
   printf("\n");
}    


void * buildTypeMovie_Prompt(FILE * fin) {
   if(fin == NULL) {
      printf("Attempt to build movie but file passed in was null");
      exit(-99);
   }
   char temp[100];
   int numActors, i;
   Movie * movie = (Movie *)calloc(1, sizeof(Movie));
   printf("Movie: ");
   fgets(temp, 100, fin);
   strip(temp);
   movie->title = (char *)calloc(strlen(temp) + 1, sizeof(char));
   strcpy(movie->title, temp);
   
   printf("Total Actors: ");
   fgets(temp, 100, fin);
   strip(temp);
   numActors = atoi(temp);
   Actor * actor = (Actor *) calloc(numActors, sizeof(Actor));
   for(i = 0; i < numActors; i++) {
      printf("Actor's First Name: ");
      fgets(temp, 100, fin);
      strip(temp);
      actor[i].first = (char *) calloc(strlen(temp) + 1, sizeof(char));
      strcpy(actor[i].first, temp);
      
      printf("Actor's Last Name: ");
      fgets(temp, 100, fin);
      strip(temp);
      actor[i].last = (char *) calloc(strlen(temp) + 1, sizeof(char));
      strcpy(actor[i].last, temp);
      movie->actors = actor;
   }
   movie->totalActors = numActors;
   return (void *) movie;

}

int compareMovie(const void * p1, const void * p2) {
   if(p1 == NULL) {
      printf("\nOne of the words being compared to is null (1)\n");
      exit(-1);
   } 
   if(p2 == NULL) {
      printf("\nOne of the words being compared to is null (2)\n");
      exit(-1);
   } 
   Movie * first = (Movie *) p1;
   Movie * second = (Movie *) p2;
   if(strcasecmp(first->title, second->title) == 0) {
      return first->totalActors - second->totalActors;
   }
   return strcasecmp(first->title, second->title);
}







