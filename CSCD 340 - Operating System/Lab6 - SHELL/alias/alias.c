#include "alias.h"

extern LinkedList * aliasList;

Alias * alias() {
	Alias * temp = (Alias *)calloc(1, sizeof(Alias));
	temp->shortcut = NULL;
	temp->cmd = NULL;
	return temp;
}

Alias * aliasWithShort(char s[100]) {
	Alias * temp = (Alias *)calloc(1, sizeof(Alias));
	temp->shortcut = (char *)calloc(strlen(s) + 1, sizeof(char));
	strcpy(temp->shortcut, s);
	temp->cmd = NULL;
	return temp;
}


void cleanTypeAlias(void * ptr) {
	if(ptr == NULL) {
      printf("CLean type Alias ptr was null");
      exit(-99);
	}
    Alias * temp = (Alias *)ptr;
    free(temp->cmd);
    temp->cmd = NULL;
    free(temp->shortcut);
    temp->shortcut = NULL;
	free(temp);
	
}

void buildTypeAlias(char * s) {
	if(s == NULL) {
		printf("Attempted to build alias, but string passed in is NULL \n");
		exit(-99);
	}
	printf(" %s hereherehere \n", s);
	char temp[100], * token, * save;
	strcpy(temp, s);
	Alias * al = alias();
	token = strtok(temp, " ");
	token = strtok(NULL, "=");
	
	al->shortcut = (char *)calloc(strlen(token) + 1, sizeof(char));
	strcpy(al->shortcut, token);
	strcpy(temp, s);
	token = strtok_r(temp, "\"", &save);
	token = strtok_r(NULL, "\"", &save);

	al->cmd = (char *)calloc(strlen(token) + 1, sizeof(char));
	strcpy(al->cmd, token);
	//printf("%s === %s\n", al->shortcut, al->cmd);
	Node * nn = buildNode_Type(al);
	addLast(aliasList, nn);	
}

void printTypeAlias(void * passedIn) {
	if(passedIn == NULL) {
		printf("print type Alias passedin was Null");
	    exit(-99);
    }
    Alias * temp = (Alias *) passedIn;
    printf("shortcut: %s	command: %s \n", temp->shortcut, temp->cmd);
}


char * getShortcut(void * passedIn) {
	if(passedIn == NULL) {
		printf("getShortcut type Alias passedin was Null");
	    exit(-99);
    }
	Alias * temp = (Alias *) passedIn;
	return temp->shortcut;
}

char * getCmd(void * passedIn) {
	if(passedIn == NULL) {
		printf("getShortcut type Alias passedin was Null");
	    exit(-99);
    }
	Alias * temp = (Alias *) passedIn;
	return temp->cmd;
}




int compareAlias(const void * p1, const void * p2) {
    if(p1 == NULL) {
       printf("\nOne of the words being compared to is null (1)\n");
       exit(-1);
    } 
    if(p2 == NULL) {
       printf("\nOne of the words being compared to is null (2)\n");
       exit(-1);
    }   
	Alias * first = (Alias*) p1;
	Alias * second = (Alias*) p2;

   return strcmp(first->shortcut, second->shortcut);
}


