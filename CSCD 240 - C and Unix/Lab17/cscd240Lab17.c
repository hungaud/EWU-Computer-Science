#include "lab17.h"
#include "./utils/fileUtils.h"

int main()
{
    FILE * fin = NULL;
    int total, choice;
    Address * array = NULL;

    fin = openInputFile();

    array = fillArray(&total, fin);

    fclose(fin);
    fin = NULL;

    do
    {
	choice = menu();
	switch(choice)
	{
		case 1:	selectionSort(array, total, compareStreet);
			printArray(array, total);
			break;

		case 2: selectionSort(array, total, compareCity);
			printArray(array, total);
			break;

		case 3: selectionSort(array, total, compareStateCityZip);
	                printArray(array, total);
			break;

		case 4:	selectionSort(array, total, compareZip);
            		printArray(array, total);
			break;

		case 5:	printf("all done\n");

	}// end switch

    }while(choice != 5);

    cleanUp(array, total);
    array = NULL;

    return 0;

}// end main
