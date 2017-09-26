#include "listUtils.h"

Node * buildNode(FILE * in, void *(*buildData)(FILE * in) ) {
   Node * nn = (Node *)buildData(in);
   return nn;
}

Node * buildNode_Type(void * passedIn) {
   Node * nn = (Node *)calloc(1, sizeof(Node));
   nn->data = passedIn;
   return nn;
}

            //printf("%s---- %s \n", min->data, search->data);

void sort(LinkedList * theList, int (*compare)(const void *, const void *)) {
   Node * start = theList->head->next;
   Node * search, * min;
   void * temp = NULL;
   if(theList->size > 1) {
      while(start != NULL) {
	     min = start;
		 search = start->next;

         while(search != NULL) {
            if(compare(&search->data, &min->data) < 0) {
               min = search;
            }
            search = search->next;
         }
         temp = min->data;
		 min->data = start->data;
         start->data = temp;
         start = start->next;
      }
   }
}

void buildListTotal(LinkedList * myList,int total, FILE * fin, void * (*buildData)(FILE * in)) {
   if(myList == NULL || total == 0) {
      printf("\nList is null or the total is 0 \n");
      exit(-1);
   }
   int i;
   for(i = 0; i < total; i++) {
      Node * nn = buildData(fin);
      addFirst(myList, nn);
   }
}
