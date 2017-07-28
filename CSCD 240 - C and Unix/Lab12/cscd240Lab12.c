#include "./lab12.h"
#include "./utils/utils.h"
#include "./utils/fileUtils.h"
#include "./utils/arrayUtils.h"

int main()
{
    int total = 0;
    int * numbers = NULL;
    double mean, median, stdDev;
    FILE * fin = NULL, *fout = NULL;

    fin = openInputFile();
    total = readTotal(fin);

    while(!feof(fin))
    {
            fout = openOutputFile();

            numbers = fillArray(fin,total);
            mean = findMean(numbers, total);
            median = findMedian(total, numbers);
            stdDev = findStdDev(numbers, total);
            displayResults(stdout, mean, median, stdDev);
            displayResults(fout, mean, median, stdDev);

            fclose(fout);
            cleanUp(numbers);
            numbers = NULL;

            total = readTotal(fin);
    }// end while

    fclose(fin);

    return 0;

}// end main
