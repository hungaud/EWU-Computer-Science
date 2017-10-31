#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>
#include <stdint.h> 
#include "./utils/myUtils.h"
#include "./utils/fileUtil.h"

struct pte {
	int frames;
	int present;
};
typedef struct pte PTE;

struct pf {
	int mappedTo;
};
typedef struct pf PF;


int main() {
	int sizeVAS, sizePAS, size, numberFrames;
	int i, key = 0, fileTotal = 0;
	uint32_t va, pa;

	
// NOTES: scan set up to get VAS, size of page and frame, and PAS
	FILE * file = fopen("setup.txt", "r");
	fscanf(file, "%d", &sizeVAS);
	fscanf(file, "%d", &size);
	fscanf(file, "%d", &sizePAS);
	printf("%d %d %d \n", sizeVAS, size, sizePAS);
	fclose(file);
	
// NOTES: get the length of the file input so we can read file then create array for PTE and PF
	FILE * file2 = openInputFile_Prompt();
	fileTotal = countRecords(file2, 1);
	PTE * pte = (PTE *)calloc(sizeVAS, sizeof(PTE));
	PF * pf = (PF *)calloc(sizePAS, sizeof(PF));
	numberFrames = sizePAS/ size;

	for(i = 0; i < fileTotal; i++) {
		int pageNumber;
		int sizeInBits = log(size)/log(2);
		 
		fscanf(file2, "%i", &va);
		pageNumber = (va >> sizeInBits);
		//printf("page Number: %d \n", temp);

// NOTES: If page is mapped, then get the page frame at frame number n then update page numer
//		 else mape new key % 256 in this case. incase pf is filled up.
		if(pte[pageNumber].present == 1) {
			pf[pte[pageNumber].frames].mappedTo = pageNumber;
		} else {
			pte[pageNumber].present = 1;
			pte[pageNumber].frames = key % numberFrames;
			pf[pte[pageNumber].frames].mappedTo = pageNumber;
			key++;
		}
		pa =  pte[pageNumber].frames * size + (va & ((1 << sizeInBits)-1));
		printf("Virtual Address: %d \n", va);
		printf("Page Number: %d \n", pageNumber);
		printf("Page Frame Number: %d \n", pte[pageNumber].frames);
		printf("Physical Address: %d \n", pa);
		printf("=========================\n");
		//printf("VAS: %d  frame: %d pageNUmber: %d \n", temp, pte[pageNumber].frames, pageNumber);
	}
	free(pte);
	free(pf);
	//printf("%d \n", fileTotal);
	fclose(file2);
	return 0;

}



