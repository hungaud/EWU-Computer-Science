#include "lab14.h"

int main()
{
  char **argv = NULL, *str = NULL;
  int argc;

  str = readString();  // see lab14.c

  while(strcmp(str, "exit") != 0)
  {
	  argv = makeargs(str, &argc);
	  if(argv != NULL)
	  {
		printf("There are %d tokens.\nThe tokens are:\n", argc);
		printargs(argc, argv);

	  }// end if

	  argv = clean(argc, argv);
	  str = cleanUp(str);

	  str = readString();  // see lab14.c

  }// end while
	  str = cleanUp(str);

  return 0;

}// end main
