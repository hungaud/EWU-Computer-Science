DIR=./utils/

lab13:	cscd240Lab13.c lab13.o ${DIR}fileUtils.o
	gcc cscd240Lab13.c lab13.o ${DIR}utils.o ${DIR}fileUtils.o -o lab13

fileUtils.o:	${DIR}fileUtils.c ${DIR}fileUtils.h
	gcc -c ${DIR}fileUtils.c 

lab13.o:	lab13.h lab13.c
	gcc -c lab13.c

clean:
	rm ${DIR}fileUtils.o
	rm lab13.o
	rm lab13
