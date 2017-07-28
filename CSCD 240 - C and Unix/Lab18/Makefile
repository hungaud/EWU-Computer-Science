lab18:	cscd240Lab18.c ./linkedList/linkedList.o ./listUtils/listUtils.o ./utils/myUtils.o ./utils/fileUtils.o ./words/words.o
	gcc -o lab18 cscd240Lab18.c ./linkedList/linkedList.o ./listUtils/listUtils.o ./utils/myUtils.o ./utils/fileUtils.o ./utils/utils.o ./words/words.o
   
   
linkedlist.o:	./linkedList/linkedList.c ./linkedList/linkedList.h ./linkedList/requiredIncludes.h
	gcc -c ./linkedList/linkedList.c
      
listUtils.o:	./listUtils/listUtils.c ./listUtils/listUtils.h
	gcc -c ./listUtils/listUtils.c
   
myUtils.o:	./utils/myUtils.c ./utils/myUtils.h
	gcc -c ./utils/myUtils.c
   
fileUtils.o:	./utils/fileUtils.c ./utils/fileUtils.h
	gcc -c ./utils/fileUtils.c

words.o:	./words/words.c ./words/words.h
	gcc -c ./words/words.c


clean:
	rm ./linkedList/*.o
	rm ./listUtils/listUtils.o
	rm ./utils/myUtils.o
	rm ./utils/fileUtils.o
	rm ./words/words.o
	rm lab18
   
