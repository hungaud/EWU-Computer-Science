#include "redirect.h"



int containsRedirect(char * s) {
	int i;
	int in = containsIn(s);
	int out = containsOut(s);
	if(in >= 1 && out >= 1) {
		return -1;
	} else if (in == 1 || out == 1) {
		return 1;
	}
	return 0;
}

int containsIn(char * s) {
	int i, count = 0;
	for(i = 0; i < strlen(s); i++) { 
		if(s[i] == '<') {
			count++;
		}
	}
	return count;
}

int containsOut(char * s) {
	int i, count = 0;
	for(i = 0; i < strlen(s); i++) { 
		if(s[i] == '>') {
			count++;
		}
	}
	return count;
}


char ** parsePreRedirect(char *s, int * preCount, int * inFD, int * outFD) {
	char ** pre = NULL;
	char * temp = (char *)calloc(strlen(s) + 1, sizeof(char));
	strcpy(temp, s);
	char * save, *token;
	if(containsIn(s)) {
		token = strtok_r(temp, "<", &save);
		strip(token);
		int fd = open(token, O_RDONLY);
		* inFD = fd;
	} else {
		token = strtok_r(temp, ">", &save);
		strip(token);
		int fd = open(token, O_WRONLY | O_TRUNC | O_CREAT, S_IRUSR | S_IRGRP | S_IWGRP | S_IWUSR, 0777);
		*outFD = fd;
	}
	* preCount = makeargs(token, &pre, " ");
	printf("pre redirect command: %s \n", token);
	free(temp);
	temp = NULL;
	return pre;
}

char ** parsePostRedirect(char *s, int * postCount, int * inFD, int * outFD) {
	char ** post = NULL;
	char * temp = (char *)calloc(strlen(s) + 1, sizeof(char));
	strcpy(temp, s);
	char * save, * token;
	//printf("token: %s \n", temp);
	if(containsIn(s)) {
		token = strtok_r(temp, "<", &save);
		token = strtok_r(NULL, "<", &save);
		strip(token);
		int fd = open(token, O_RDONLY);
		* inFD = fd;
	} else {
		token = strtok_r(temp, ">", &save);
		token = strtok_r(NULL, ">", &save);
		strip(token);
		int fd = open(token,  O_WRONLY | O_TRUNC | O_CREAT, S_IRUSR | S_IRGRP | S_IWGRP | S_IWUSR, 0777);
		*outFD = fd;
	}
	* postCount = makeargs(token, &post, " ");	
	printf("post redirect command: %s \n", token + 1);
	free(temp);
	temp = NULL;
	return post;
}

void redirectIt(char * s, char ** preRedirect, char ** postRedirect, int inFD, int outFD) {
	int status;
	pid_t pid = fork();
	
	if(pid != 0) {
		waitpid(pid, &status, 0);
	} else {
		if(containsIn(s)) {
			dup2(inFD, 0);
			close(inFD);
			execvp(preRedirect[0], preRedirect);
		}
		if(containsOut(s)) {
			dup2(outFD, 1);
			close(outFD);
			execvp(postRedirect[0], postRedirect);
		}


	}
}

/*
pid_t pid, pid2;
	int fd[2], res, status;
	pid = fork();
	if(pid == 0) {
		res = pipe(fd);
		if (res < 0) {
			printf("redirect Failure\n");
			exit(-1);
		}
		pid2 = fork();
		if(pid2 == 0) {
			close(fd[0]);
			close(1);
			dup(fd[1]);
			close(fd[1]);
			res = execvp(preRedirect[0], preRedirect);
			if (res == -1) {
				exit(-1);
			}
		} else {
			waitpid(pid2, &status, 0);
			if (status != 0) {
				printf("Command not found: %s\n", preRedirect[0]);
				exit(-1);
			}
			close(fd[1]);
			close(0);
			dup(fd[0]);
			close(fd[0]);
			res = execvp(postRedirect[0], postRedirect);
			if (res == -1) {
				printf("Command not found: %s \n", postRedirect[0]);
				exit(-1);
			}
		}
	} else {
		waitpid(pid, &status, 0);
	}
*/






