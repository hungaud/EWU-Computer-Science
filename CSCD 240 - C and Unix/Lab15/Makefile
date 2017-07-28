lab15: cscd240Lab15.c ./utils/fileUtils.o lab15.o 
	gcc -o lab15 cscd240Lab15.c ./utils/fileUtils.o ./utils/utils.o lab15.o

lab15.o:	lab15.c lab15.h
	gcc -c lab15.c

fileUtils.o:	./utils/fileUtils.c ./utils/fileUtils.h
	gcc -c ./utils/fileUtils.c

clean:
	rm ./utils/fileUtils.o
	rm lab15.o
	rm lab15

