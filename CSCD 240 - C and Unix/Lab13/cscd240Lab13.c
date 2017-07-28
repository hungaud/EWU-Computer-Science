#include "./utils/fileUtils.h"
#include "lab13.h"

int main(int argc, char **argv)
{
	int n, choice;
	FILE * fout = NULL;
	int ** pascal = NULL;

	if(argc == 1)
	{
		n = readTotal();
		fout = openOutputFile();
	}// end if

	else if(argc == 2)
	{
		n = retrieveTotal(argv[1]);
		fout = openOutputFile();
	}// end else if

	else
	{
		n = retrieveTotal(argv[1]);
		fout = openOutputFileArgs(argv[2]);
	}// end else

	
	pascal = createTriangle(n);

	
	do
	{
		choice = menu();

		if(choice == 1)
			printTriangle(stdout, pascal, n);

		else if(choice == 2)
			printTriangle(fout, pascal, n);

		else if(choice == 3)
		{
			cleanUp(pascal, n);
			pascal = NULL;

			n = readTotal();
			pascal = createTriangle(n);
		}// end else if

	}while(choice != 4);

	cleanUp(pascal, n);
	pascal = NULL;

	fclose(fout);

	return 0;
}

