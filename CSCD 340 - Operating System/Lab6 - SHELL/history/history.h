#ifndef HISTORY_H_
#define HISTORY_H_

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../utils/myUtils.h"
#include "../linkedlist/linkedList.h"
#include "../linkedlist/listUtils.h"

struct history {
	char * command;
	int num;
};

typedef struct history History;

History * history();
void cleanTypeHistory(void * ptr);
void buildTypeHistory(char * s);
void printTypeHistoryFile(void * passedIn, FILE * fp);
void printTypeHistory(void * passedIn);
int compareHistory(const void * p1, const void * p2);

#endif






