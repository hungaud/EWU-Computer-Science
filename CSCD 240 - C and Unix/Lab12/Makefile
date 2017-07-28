DIR=./utils/

lab12:	cscd240Lab12.c ${DIR}fileUtils.o ${DIR}arrayUtils.o lab12.o
	gcc cscd240Lab12.c lab12.o ${DIR}utils.o ${DIR}fileUtils.o ${DIR}arrayUtils.o -o lab12 -lm

fileUtils.o:	${DIR}fileUtils.c ${DIR}fileUtils.h
	gcc -c ${DIR}fileUtils.c

arrayUtils.o:	${DIR}arrayUtils.o ${DIR}arrayUtils.h
	gcc -c ${DIR}arrayUtils.c

lab12.o:	lab12.h lab12.c
	gcc -c lab12.c

clean:
	rm ${DIR}fileUtils.o
	rm ${DIR}arrayUtils.o
	rm lab12.o
	rm lab12
  
