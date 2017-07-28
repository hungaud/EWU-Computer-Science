#include "lab11.h"

int main()
{
    int * array = NULL;
    int length, choice, value;

    length = readInitialLength();
    array = createAndFill(length);

    do
    {
        choice = menu();

        switch(choice)
        {
            case 1: printSortedArray(array, length);
                    break;

            case 2: array = addItem(&length, array);
                    break;

            case 3: value = readValue();
                    printIfFound(value, array, length);
        }
    }while(choice != 4);

    cleanUp(array);
    array = NULL;

    return 0;
}// end main
