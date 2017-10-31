CC=gcc

lab7: cscd340Lab7.c myUtils.o fileUtil.o ./utils/myUtils.o ./utils/fileUtil.o
	gcc -g ./utils/myUtils.o ./utils/fileUtil.o cscd340Lab7.c -o lab7 -lm

myUtils.o:	./utils/myUtils.o ./utils/myUtils.h
		gcc -g -c ./utils/myUtils.c

fileUtil.o:	./utils/fileUtil.o ./utils/fileUtil.h
		gcc -g -c ./utils/fileUtil.c

clean:
	rm lab7
	rm lab7.o
	rm ./utils/myUtils.o
	rm ./utils/fileUtil.o
