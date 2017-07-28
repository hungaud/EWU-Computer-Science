#include "linkedList.h"

LinkedList * linkedList() {
   LinkedList * myLinkedList = (LinkedList *)calloc(1, sizeof(LinkedList));
   myLinkedList->size = 0;
   
   return myLinkedList;}

void addLast(LinkedList * theList, Node * nn) {
   if(nn == NULL) {
      printf("\nThe new node being passed is null\n");
      exit(-1);
   }
   if(theList == NULL) {
      printf("\nThe linked list is null\n");
      exit(-1);
   }
   if(theList->head == NULL) {
      addFirst(theList, nn);
   } else {
      Node * curr = theList->head;
      while(curr->next != NULL) {
         curr = curr->next;
      }
      curr->next = nn;
      nn->next = NULL;
      theList->size = theList->size + 1;
   }
}

void addFirst(LinkedList * theList, Node * nn) {
   if(theList->head == NULL) {
      theList->head = nn;
      nn->next = NULL;
   } else {
      nn->next = theList->head;
      theList->head = nn;
   }
   theList->size = theList->size + 1;
}

void removeItem(LinkedList * theList, Node * nn, void (*removeData)(void *), int (*compare)(const void *, const void *)) {
   Node * curr = theList->head;
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
   if(theList->head == NULL) {
      printf("The the list is empty\n");
   } else {
      Node * curr = theList->head;
      for(i = 0; i < theList->size; i++) {
         convertData(&curr->data);
         curr = curr->next;
      }
      printf("\n");
   }
}
