#ifndef PATH_H_
#define PATH_H_

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../utils/myUtils.h"
#include "../tokenize/makeArgs.h"
#include "../linkedlist/linkedList.h"
#include "../linkedlist/listUtils.h"
#include "../tokenize/makeArgs.h"

struct path {
	char * location;
	//int size;
};

typedef struct path Path;

Path * path();
void cleanTypePath(char ** paths, int count);
int buildDefaultPath(char temp [1000]);
int buildFilePath(); 
void printPaths(char ** paths, int count);


#endif

