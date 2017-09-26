#include "movie.h"


/*
 Cleans up and frees all the dynamically allocated memory 
 * In this case title, actors->first, actors->last and the actors array
 *
 * Each pointer in the specific data type is set to NULL after it has been freed.
 *
 * @param passedIn - The void * passed in representing the specific movie
 *
 * @warning - The passed in void * passedIn is checked - exit(-99) if NULL
 
 */
 
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
 
}

 
void * buildTypeMovie(FILE * fin) {
   return NULL; 

}

void printTypeMovie(void * passedIn) {


}    


void * buildTypeMovie_Prompt(FILE * fin) {
   return NULL; 

}

int compareMovie(const void * p1, const void * p2) {

}
