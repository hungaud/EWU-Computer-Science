#include "makeArgs.h"


void clean(int argc, char **argv) {
    int i;
    for(i = 0; i < argc; i++) {
        free(argv[i]);
        argv[i] = NULL;
    } 
    free(argv);
}// end clean

void printargs(int argc, char **argv) {
	int x;
	for(x = 0; x < argc; x++)
		printf("%s\n", argv[x]);

}// end printargs

int makeargs(char *s, char *** argv, const char * delimeter) {
    char copy [100];
    int count = 0, i;
    char * save;
    strcpy(copy, s);
    char * token = strtok_r(copy, delimeter, &save);
    strip(token);
    while(token != NULL) {
        count++;
        token = strtok_r(NULL, delimeter, &save);
    }
    if(count == 0) { 
        return -1;
    }
    strcpy(copy, s);
    *argv = (char **)calloc(count+ 1, sizeof(char *));
    token = strtok_r(copy, delimeter, &save);
    strip(token);
    (*argv)[0] = (char *)calloc(strlen(token) + 1, sizeof(char));
    strcpy((*argv)[0], token);
    for(i = 1; i < count; i++) {
        token = strtok_r(NULL, delimeter, &save);
        strip(token);
        (*argv)[i] = (char *)calloc(strlen(token) + 1, sizeof(char));
        strcpy((*argv)[i], token);
    }
    return count;
}// end makeArgs







