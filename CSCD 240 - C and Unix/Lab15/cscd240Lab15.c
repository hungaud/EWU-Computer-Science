#include "lab15.h"
#include "./utils/fileUtils.h"

int main()
{
   FILE * fin = NULL;
   int total, choice;
   struct Stock array[10]; // guaranteed 1 to 10 Stocks inclusive

   fin = openInputFile();

   total = fillArray(array, fin);

   fclose(fin);

   do
   {
      choice = menu();
      switch(choice)
      {
         case 1:  symbolSort(array, total);
					        printArray(array, total);
					        break;

			   case 2:  companySort(array, total);
					        printArray(array, total);
					        break;

			   case 3:  priceSort(total, array);
					        printArray(array, total);
					        break;

			   case 4:	printf("all done\n");

		}// end switch

   }while(choice != 4);

   return 0;

}// end main
