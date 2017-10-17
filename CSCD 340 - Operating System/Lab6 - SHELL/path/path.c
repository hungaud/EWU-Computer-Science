#include "path.h"

extern char ** pathList;
extern char * defaultPath;

Path * path() {
	//Path * temp = (Path *)calloc(1, sizeof(Path));
	//temp->location = NULL;
	//return temp;
	return NULL;
}

void cleanTypePath(char ** paths, int count) {
    if(paths == NULL) {
       printf("CleanTypePath list was null");
       exit(-99);
    }
	int i;
	for(i = 0; i < count; i++) {
		free(paths[i]);
		paths[i] = NULL;
	}
	free(paths);
	paths = NULL;

}

int buildDefaultPath(char temp[1000]) {
	char * save, *temp2;
	temp2 = strtok_r(temp, "PATH=$PATH", &save);
	printf(" %s  \n", temp2);
	// to get the paths after PATH=$PATH:"
	defaultPath = (char *)calloc(strlen(temp2 + 1)+1, sizeof(char));

	strcpy(defaultPath, temp2 + 1);
	strip(defaultPath);

	int count = makeargs(defaultPath, &pathList, ":");

	return count;
}


void printPaths(char ** paths, int count) {
    if(paths == NULL) {
    	printf("print type paths was Null");
		//exit(-99);
	}
	int i;
	for(i = 0; i < count; i++) {
		printf(" %s \n", paths[i]);

	}
   
}

















