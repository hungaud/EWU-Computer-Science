#ifndef PROCESS_H
#define PROCESS_H

#include <string.h>
#include <stdio.h>
#include <stdlib.h>

void forkIt(char ** argv);

void forkItFileOut(char ** argv, int directTo);
void forkItFileIn(char ** argv, int directTo);



#endif
