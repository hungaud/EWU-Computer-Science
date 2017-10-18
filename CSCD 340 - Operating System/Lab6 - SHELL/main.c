#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#include "./pipes/pipes.h"
#include "./utils/myUtils.h"
#include "./process/process.h"
#include "./tokenize/makeArgs.h"
//#include "./path/path.h"
#include "./linkedlist/linkedList.h"
#include "./linkedlist/listUtils.h"
#include "./history/history.h"
#include "./alias/alias.h"
#include "./redirect/redirect.h"




//char * temp;

void lab5Main();
void setPaths();
void setAlias();
char * checkAlias(char [100] );
void setCD();
void buildTypeHistory(char *);
void printHistory();
void cd(char *);
void readFIle();
void printHistoryFile();

// global variable for Reading FIle
FILE * file;


// global variable for PATH
//char ** pathList = NULL;
char * paths;
int pathCount = 0;
char pathString[1000] = "PATH=$PATH:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin:/usr/games:/usr/local/games:/snap/bin";


// global variable for HISTORY
int historySize = 100;
int historyFileSize = 1000;
int histNum = 1;
LinkedList * historyList;

// global variable for ALIAS
LinkedList * aliasList;

// global variable for CD
char currentDir[100];

int main()
{
	int i;

	historyList = linkedList();
	aliasList = linkedList();
	getcwd(currentDir, sizeof(currentDir));
	
	file = fopen(".msshrc", "r");
	if(file) {
		readFIle();
		fclose(file);
	} 

	
	char * paths = (char *)calloc(strlen(pathString) + 1, sizeof(char));
	putenv(pathString);

	free(paths);

	lab5Main();
	printHistoryFile();
	

	clearList(historyList, cleanTypeHistory);
	free(historyList);
	clearList(aliasList, cleanTypeAlias);
	free(aliasList);
	

  return 0;
}// end main

void readFIle() {
	char buffer[1000], * save, * token;
	int value = 0;
	int i;
	for(i = 0; i < 2; i++) {	
		fgets(buffer, 100, file);
		strip(buffer);
		token = strtok_r(buffer, "=", &save);
		if(strcmp(token, "HISTCOUNT") == 0) {
			token = strtok_r(NULL, "=", &save);
			historySize = atoi(token);
		} else {
			token = strtok_r(NULL, "=", &save);
			historyFileSize = atoi(token);
		}
	}
	setAlias();
}


void setPaths(char temp[1000]) {
	strcpy(pathString, temp);
	//pathCount = buildDefaultPath(temp);
}

void setAlias() {
	char buffer[1000];
	fgets(buffer, 1000, file);
	strip(buffer);
	while(!feof(file)) {
		if(buffer[0] == 'A') {
			buildTypeAlias(buffer);
		} else if(buffer[0] == 'P') {
			setPaths(buffer);
		}
		fgets(buffer, 1000, file);
		strip(buffer);
	}
	printList(aliasList, printTypeAlias);
}

char * checkAlias(char s[100]) {
	int i;
	char shortcut[100];
	Node * nn = aliasList->head->next;
	for(i = 0; i < aliasList->size; i++) {
		strcpy(shortcut, getShortcut(nn->data));
		if(strcmp(s, shortcut) == 0 ) {
			return getCmd(nn->data);
		} else {
			nn = nn->next;
		}	
	}
	return NULL;
}





void setCD (char s[100], char argPath[100]) {
	if(strcmp(s, "cd") != 0) {					
		cd(argPath);
		getcwd(currentDir, sizeof(currentDir));
	} else {
		printf("attempt to change cd but error in input \n");
	}
}


void lab5Main () {
	int argc, pipeCount, redirectCount, inFD, outFD;	
	char **argv = NULL, s[1000];
  	int preCount = 0, postCount = 0;
  	char ** prePipe = NULL, ** postPipe = NULL;
  	char ** preRedirect = NULL, ** postRedirect = NULL;
  	char temp[1000];
 	printf("command?: %s$ ", currentDir);
	fgets(s, MAX, stdin);
	strip(s);

	
	//build history list 
	buildTypeHistory(s);
	histNum++;

 	while(strcmp(s, "exit") != 0)
  	{
		if(strcmp(s, "") != 0) {
			if(checkAlias(s) != NULL){
				strcpy(s, checkAlias(s));
			}
			pipeCount = containsPipe(s);
			redirectCount = containsRedirect(s);
			if(redirectCount > 0 ) {
				printf(" %d redirect was found\n", redirectCount);
				/*preRedirect = parsePreRedirect(s, &preCount, &inFD, &outFD);
				postRedirect = parsePostRedirect(s, &postCount, &inFD, &outFD);
				redirectIt(s, preRedirect, postRedirect, inFD, outFD);
				clean(preCount, preRedirect);
		    	clean(postCount, postRedirect); */
			}
			if(pipeCount > 0)
			{
				prePipe = parsePrePipe(s, &preCount);
				postPipe = parsePostPipe(s, &postCount);
				pipeIt(prePipe, postPipe);
				clean(preCount, prePipe);
		    	clean(postCount, postPipe);
			}// end if pipeCount	  
			else if (strcmp(s, "history") == 0 || strcmp(s, "!!") == 0) { 
				printHistory();
			} //else if (strcmp(first, "!") == 0) {
				//printf(" !123 \n"); 
			//}
			else if (strstr(s, "PATH=$PATH:") != NULL) {
				paths = (char *)calloc(strlen(s) + 1, sizeof(char));
				strcpy(paths, s);
				strcpy(pathString, paths);
				putenv(paths);
				free(paths);
			}
			else if (strcmp(s, "$PATH") == 0) {
				printf("%s \n", pathString);
			}
			else
			{	
				argc = makeargs(s, &argv, " ");
				if(strcmp(argv[0], "cd") == 0) {
					setCD(s, argv[1]);
				} else if (strcmp(argv[0], "alias") == 0) {
					char * ali;
					char * saved;
					ali = strtok_r(argv[1], "=", &saved);
					printf("%s what ali is \n", ali);
					Node * node = buildNode_Type(aliasWithShort(ali));
					if(checkContains(aliasList, node, compareAlias)) {
						removeItem(aliasList, node, cleanTypeAlias, compareAlias);
						buildTypeAlias(s);
					} else {
						buildTypeAlias(s);
						cleanTypeAlias(node->data);					
						free(node);
					}

					printList(aliasList, printTypeAlias);
				} else if (strcmp(argv[0], "unalias") == 0) {
					Node * node = buildNode_Type(aliasWithShort(argv[1]));
					if(checkContains(aliasList, node, compareAlias)) {
						removeItem(aliasList, node, cleanTypeAlias, compareAlias);
					} else {
						cleanTypeAlias(node->data);					
						free(node);
					}
					printList(aliasList, printTypeAlias);
					
		  		} else if (argc != -1) {
		  			forkIt(argv);
				}
		  
		  		clean(argc, argv);
		  		argv = NULL;
			}
	}
 	printf("command?: %s$ ", currentDir);
	fgets(s, MAX, stdin);
	strip(s);

	strcpy(temp, ((History *)(getLast(historyList)->data))->command);
	if(strcmp(s, "!!") == 0) {
		strcpy(s, temp);
	}
	if(strcmp(s, temp) != 0) {
		buildTypeHistory(s);
		histNum++;
	}

	
  }// end while
	//printList(historyList, printTypeHistory);
	
}


void printHistory() {
	if(historySize < historyList->size) {
		int diff = historyList->size - historySize;
		printNumList(historyList, printTypeHistory, diff);
	} else {
		printList(historyList, printTypeHistory);
	}
}


void printHistoryFile() {
	remove(".mssh_history");
	FILE * fp = fopen(".mssh_history", "w");
	
	if(historySize < historyList->size) {
		int diff = historyList->size - historySize;
		printNumListFile(historyList, printTypeHistoryFile, diff, fp);
	} else {
		printListFile(historyList, printTypeHistoryFile, fp);
	}
	fclose(fp);
}




