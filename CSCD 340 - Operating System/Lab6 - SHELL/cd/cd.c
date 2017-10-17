#include "cd.h"

extern char currentDir[100];

void cd(char * path) {
	char cwd[100], temp[100], *first, * second;
	int result;

	getcwd(cwd, sizeof(cwd));
	strcpy(temp, path);

	if(temp[0] != '/') {
		strcat(cwd, "/");
	}
	strcat(cwd, path);
	result = chdir(cwd);

	if(result != 0) { 
		printf("directory does not exist %s \n", path);
	}
}

	
