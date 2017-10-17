#include "pipes.h"
#include "../tokenize/makeArgs.h"

int containsPipe(char *s) {
	int i, pipe = 0;
	for(i = 0; i < strlen(s); i++) {
		if(s[i] == '|') {
			pipe++;
		}
	}
	if(pipe == 1) {
		printf("There is %d pipe \n", pipe);
	} else {
		printf("There are %d pipes \n", pipe);
	}
	return pipe;
}

char ** parsePrePipe(char *s, int * preCount) {
	char ** pre = NULL;
	char * temp = (char *)calloc(strlen(s) + 1, sizeof(char));
	strcpy(temp, s);
	char * save;
	char * token = strtok_r(temp, "|", &save);
	strip(token);
	* preCount = makeargs(token, &pre, " ");
	printf("pre pipe command: %s \n", token);
	free(temp);
	temp = NULL;
	return pre;
}

char ** parsePostPipe(char *s, int * postCount) {
	char ** post = NULL;
	char * temp = (char *)calloc(strlen(s) + 1, sizeof(char));
	strcpy(temp, s);
	char * save;
	//printf("token: %s \n", temp);
	char * token = strtok_r(temp, "|", &save);
	token = strtok_r(NULL, "|", &save);
	strip(token);
	* postCount = makeargs(token, &post, " ");	
	printf("post pipe command: %s \n", token + 1);
	free(temp);
	temp = NULL;
	return post;
}

void pipeIt(char ** prePipe, char ** postPipe) {
	pid_t pid, pid2;
	int fd[2], res, status;
	pid = fork();
	if(pid == 0) {
		res = pipe(fd);
		if (res < 0) {
			printf("Pipe Failure\n");
			exit(-1);
		}
		pid2 = fork();
		if(pid2 == 0) {
			close(fd[0]);
			close(1);
			dup(fd[1]);
			close(fd[1]);
			res = execvp(prePipe[0], prePipe);
			if (res == -1) {
				exit(-1);
			}
		} else {
			waitpid(pid2, &status, 0);
			if (status != 0) {
				printf("Command not found: %s\n", prePipe[0]);
				exit(-1);
			}
			close(fd[1]);
			close(0);
			dup(fd[0]);
			close(fd[0]);
			res = execvp(postPipe[0], postPipe);
			if (res == -1) {
				printf("Command not found: %s \n", postPipe[0]);
				exit(-1);
			}
		}
	} else {
		waitpid(pid, &status, 0);
	}
	/*int fd[2], res, status;
	pid_t pid2;
	pipe(fd);
	if(fork() == 0) {
		close(fd[0]);
		close(1);
		dup(fd[1]);
		close(fd[1]);
		execvp(prePipe[0], prePipe);
	} else {
		close(fd[1]);
		close(0);
		dup(fd[0]);
		close(fd[0]);
		res = execvp(postPipe[0], postPipe);
	}*/
}



