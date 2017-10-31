CC=gcc

lab6:	cscd340Lab6.c ./tokenize/makeArgs.o ./utils/myUtils.o ./process/process.o ./pipes/pipes.o ./path/path.o ./history/history.o ./linkedlist/linkedList.o ./linkedlist/listUtils.o ./cd/cd.o ./alias/alias.o ./redirect/redirect.o
	gcc -g cscd340Lab6.c ./tokenize/makeArgs.o ./utils/myUtils.o ./process/process.o ./pipes/pipes.o ./path/path.o ./history/history.o ./linkedlist/linkedList.o ./linkedlist/listUtils.o ./cd/cd.o ./alias/alias.o ./redirect/redirect.o -o lab6

makeArgs.o:	./tokenize/makeArgs.c ./tokenize/makeArgs.h
	gcc -g -c ./tokenize/makeArgs.c

myUtils.o:	./utils/myUtils.o ./utils/myUtils.h
	gcc -g -c ./utils/myUtils.c

process.o:	./process/process.c ./process/process.h
	gcc -g -c ./process/process.c	

pipes.o:	./pipes/pipes.c ./pipes/pipes.h
	gcc -g -c ./pipes/pipes.c

path.o:	./path/path.c ./path/path.h
	gcc -g -c ./path/path.c

history.o:	./history/history.c ./history/history.h
	gcc -g -c ./history/history.c

listUtils.o:	./linkedlist/listUtils.c listUtils.h
	gcc -g -c ./linkedlist/listUtils.c

linkedList.o:	./linkedlist/linkedList.h ./linkedlist/linkedList.c ./linkedlist/requiredIncludes.h
	gcc -g -c ./linkedlist/linkedList.c

cd.o:	./cd/cd.c ./cd/cd.h
	gcc -g -c ./cd/cd.c

alias.o:	./alias/alias.c ./alias/alias.h
	gcc -g -c ./alias/alias.c

redirect.o:	./redirect/redirect.c ./redirect/redirect.h
	gcc -g -c ./redirect/redirect.c

clean:
	rm ./pipes/pipes.o	
	rm ./utils/myUtils.o
	rm ./process/process.o
	rm ./tokenize/makeArgs.o
	rm ./path/path.o
	rm ./history/history.o
	rm ./linkedlist/linkedList.o
	rm ./linkedlist/listUtils.o
	rm ./cd/cd.o
	rm ./alias/alias.o
	rm ./redirect/redirect.o
	rm lab6

