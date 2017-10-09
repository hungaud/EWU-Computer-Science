#include "process.h"
#include <sys/types.h>
#include <sys/wait.h>
#include <unistd.h>

void forkIt(char ** argv) {
    int status;
    pid_t pid = fork();
    if(pid != 0) {
        waitpid(pid, &status, 0);
    } else {
        int res = execvp(argv[0], argv);

            exit(-99);
        
    }

}
