#ifndef REDIRECT_H
#define REDIRECT_H

#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <unistd.h>
#include <unistd.h>
#include <sys/wait.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include "../tokenize/makeArgs.h"
#include "../process/process.h"
#include "../utils/myUtils.h"


int containsRedirect(char * s);
int containsIn(char * s);
int containsOut(char * s);

char ** parsePreRedirect(char *s, int * preCount, int * inFD, int * outFD);
char ** parsePostRedirect(char *s, int * postCount, int * inFD, int * outFD);

void redirectIt(char * s, char ** preRedirect, char ** postRedirect, int in, int out);

#endif
