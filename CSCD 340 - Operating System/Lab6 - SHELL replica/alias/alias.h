#ifndef ALIAS_H_
#define ALIAS_H_

#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <unistd.h>
#include <unistd.h>
#include "../utils/myUtils.h"
#include "../linkedlist/linkedList.h"
#include "../linkedlist/listUtils.h"

struct alias {

	char * shortcut;
	char * cmd;

};

typedef struct alias Alias;

Alias * alias();
Alias * aliasWithShort(char s[100]);

void cleanTypeAlias(void * ptr);

void buildTypeAlias(char * s);

void printTypeAlias(void * passedIn);
char * getShortcut(void * passedIn);
char * getCmd(void * passedIn);

int compareAlias(const void * p1, const void * p2);

#endif

