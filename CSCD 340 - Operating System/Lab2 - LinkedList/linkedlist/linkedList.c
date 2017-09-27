#include "linkedList.h"

LinkedList * linkedList() {
   LinkedList * myLinkedList = (LinkedList *)calloc(1, sizeof(LinkedList));
   myLinkedList->size = 0;
   
   //myLinkedList->head = NULL; //might not need but was in notes
   myLinkedList->head = (Node*)calloc(1, sizeof(Node));
   myLinkedList->head->next = NULL;
   myLinkedList->head->prev = NULL;
   
   return myLinkedList;
}

void addLast(LinkedList * theList, Node * nn) {
   if(nn == NULL) {
      printf("\nThe new node being passed is null\n");
      exit(-99);
   }
   if(theList == NULL) {
      printf("\nThe linked list is null\n");
      exit(-99);
   }
   if(theList->head->next == NULL) {
      addFirst(theList, nn);
   } else {
      Node * curr = theList->head;
      while(curr->next != NULL) {
         curr = curr->next;
      }
      curr->next = nn;
      nn->prev = curr;
      nn->next = NULL;
      theList->size = theList->size + 1;
   }
}

void addFirst(LinkedList * theList, Node * nn) {
   if(theList == NULL || nn == NULL) {
      printf("list or node is NULL");
      exit(-99);
   }
   //printf("%s \n", nn->data);   

   if(theList->size == 0) {
      theList->head->next = nn;
      theList->head->next->prev = theList->head;
      nn = NULL;
   } else {
      nn->next = theList->head->next;
      nn->prev = theList->head;
      theList->head->next->prev = nn;

      theList->head->next = nn;
      nn = NULL;
   }

   theList->size = theList->size + 1;
   //printf("%s -- %s -- %d \n", theList->head->data, theList->head->next->data, theList->size);
}

void removeItem(LinkedList * theList, Node * nn, void (*removeData)(void *), int (*compare)(const void *, const void *)) {
   if(theList == NULL || nn == NULL) {
      printf("removing but node or list is NULL");
      exit(-99);
   }
   
   if(theList->size == 0) {
      printf("List is empty \n");
   } else {
      Node * curr = theList->head->next;
      Node * prev = NULL;
      if(compare(curr->data, nn->data) == 0) {
         theList->head->next = theList->head->next->next;
         removeData(curr->data);
         free(curr);
         curr = NULL;
         theList->size = theList->size - 1;
         
      } else {
         while(compare(curr->data, nn->data) != 0 && curr->next != NULL) {
            prev = curr;
            curr = curr->next;
         }
         if(curr == NULL && compare(curr->data, nn->data) != 0) {
            printf("Item not found \n");
         } else if (compare(curr->data, nn->data) == 0) {
            prev->next = curr->next;
	    curr->prev = prev;
            removeData(curr->data);
            theList->size = theList->size - 1;
	    free(curr);
            curr = NULL;

         }     
      }
      removeData(nn->data);
      free(nn);
      nn = NULL;
   }
}

void removeFirst(LinkedList * theList, void (*removeData)(void *)){
   if(theList == NULL) {
		printf("Attempted to removeFirst but list is empty");
      exit(-99);
	} else {
      Node * n = theList->head->next;
      Node * temp = n->next; 
      theList->head->next = temp;
      temp->prev = theList->head;
      theList->size = (theList->size)-1;
      removeData(n->data);
      free(n);
      n = NULL;
   }
}


void removeLast(LinkedList * theList, void (*removeData)(void *)) {
   if(theList == NULL || theList->head->next == NULL) {
      printf("\nThe linked list is null/empty \n");
      exit(-99);
   }
   else {
      Node * curr = theList->head->next;
      while(curr->next != NULL) {
         curr = curr->next;
      }
      curr = curr->prev;
      removeData(curr->next->data);
      theList->size = theList->size-1;
      free(curr->next);
      
      curr->next = NULL;
   }
}


void clearList(LinkedList * theList, void (*removeData)(void *)) {
   if(theList != NULL || theList->size > 0) {
      Node * curr = theList->head->next;
      int i;
      for(i = 0; i < theList->size; i++) {
         theList->head->next = theList->head->next->next;
         removeData(curr->data);
         free(curr);
         //curr->data = NULL;
         curr = theList->head->next;
      }
      theList->size = 0;
      free(theList->head->next);
      theList->head->next = NULL;
      free(curr);
      curr= NULL;
   }
    free(theList->head);
   

}


void printList(const LinkedList * theList, void (*convertData)(void *)) {
   int i;
   if(theList->head->next == NULL) {
      printf("The the list is empty\n");
   } else {
   	  printf("\n");
      Node * curr = theList->head->next;
      for(i = 0; i < theList->size; i++) {
         convertData(curr->data);
         curr = curr->next;
      }
      free(curr);
      curr = NULL;
      printf("\n");
   }
}
