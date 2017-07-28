DIR=./utils/

lab16:	cscd240Lab16.c ${DIR}fileUtils.o lab16.o
	gcc cscd240Lab16.c ${DIR}fileUtils.o ${DIR}utils.o lab16.o -o lab16

lab16.o:	lab16.c lab16.h
	gcc -c lab16.c

fileUtils.o:	${DIR}fileUtils.c ${DIR}fileUtils.h
	gcc -c ${DIR}fileUtils.c

clean:
	rm ${DIR}fileUtils.o
	rm lab16.o
	rm lab16

