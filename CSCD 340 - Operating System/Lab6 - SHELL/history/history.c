#include "history.h"

extern LinkedList * historyList;
extern int histNum;

History * history() {
	History * temp = (History *)calloc(1, sizeof(History));
	temp->num = 0;
	temp->command = NULL;
	return temp;
}

void cleanTypeHistory(void * ptr) {
   if(ptr == NULL) {
      printf("CLean type ptr was null");
      exit(-99);
   }
   History * temp = (History *)ptr;
   free(temp->command);
   temp->command = NULL;
   temp->num = 0;
   free(temp);
}

void buildTypeHistory(char * s) {
	History * hist = history();
	hist->command = (char *)calloc(strlen(s) + 1, sizeof(char));
	strcpy(hist->command, s);
	hist->num = histNum;
	
	Node * nn = buildNode_Type(hist);
	addLast(historyList, nn);	
}




void printTypeHistory(void * passedIn) {
	if(passedIn == NULL) {
		printf("print type passedin was Null");
	    exit(-99);
    }
    History * temp = (History *) passedIn;
    printf("%d.)	%s \n", temp->num, temp->command);
}

void printTypeHistoryFile(void * passedIn, FILE * fp) {
	if(passedIn == NULL) {
		printf("print type passedin was Null");
	    exit(-99);
    }
    History * temp = (History *) passedIn;
    fprintf(fp, "%d.)	%s \n", temp->num, temp->command);
}

int compareHistory(const void * p1, const void * p2) {
	return 0;
}


