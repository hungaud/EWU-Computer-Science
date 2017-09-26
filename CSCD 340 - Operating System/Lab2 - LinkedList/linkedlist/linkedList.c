#include "linkedList.h"

LinkedList * linkedList() {
   LinkedList * myLinkedList = (LinkedList *)calloc(1, sizeof(LinkedList));
   myLinkedList->size = 0;
   
   myLinkedList->head = NULL; //might not need but was in notes
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
   if(theList->head->next == NULL) {
      theList->head->next = nn;
      nn->next = NULL;
      nn->prev = theList->head;
   } else {
      nn->next = theList->head->next;
      nn->prev = theList->head;
      theList->head->next = nn;
   }
   theList->size = theList->size + 1;
}

void removeItem(LinkedList * theList, Node * nn, void (*removeData)(void *), int (*compare)(const void *, const void *)) {
   if(theList->size == 0) {
      printf("List is empty \n");
   } else {
      Node * curr = theList->head->next;
      Node * prev = NULL;
      if(compare(&curr->data, &nn->data) == 0) {
         theList->head = theList->head->next;
         removeData(&curr->data);
         theList->size = theList->size - 1;
      } else {
         while(compare(&curr->data, &nn->data) != 0 && curr->next != NULL) {
            prev = curr;
            curr = curr->next;
         }
         if(curr == NULL && compare(&curr->data, &nn->data) != 0) {
            printf("Item not found \n");
         } else if (compare(&curr->data, &nn->data) == 0) {
            prev->next = curr->next;
            removeData(&curr->data);
            theList->size = theList->size - 1;

         }     
      }
      free(nn->data);
      free(nn);
   }
}

void removeFirst(LinkedList * theList, void (*removeData)(void *)){
   if(theList == NULL) {
		printf("Attempted to removeFirst but list is empty");
      exit(-99);
	} else {
      Node * n = theList->head->next;
   	theList->head->next = theList->head->next->next;
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
      removeData(&curr->next->data);
	   theList->size = theList->size-1;
      free(curr->next);
      
      curr->next = NULL;
   }
}


void clearList(LinkedList * theList, void (*removeData)(void *)) {
   Node * curr = theList->head;
   int i;
   for(i = 0; i < theList->size; i++) {
      theList->head = theList->head->next;
      removeData(&curr->data);
      curr = theList->head;
   }
   theList->size = 0;
   free(theList->head);
   free(curr);
}


void printList(const LinkedList * theList, void (*convertData)(void *)) {
   int i;
   if(theList->head->next == NULL) {
      printf("The the list is empty\n");
   } else {
   	  printf("\n");
      Node * curr = theList->head->next;
      for(i = 0; i < theList->size; i++) {
         convertData(&curr->data);
         curr = curr->next;
      }
      printf("\n\n");
   }
}
