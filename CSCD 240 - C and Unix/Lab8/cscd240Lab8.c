// Hung Auduong
// CSCD 240
// Lab 8
//
// This C program takes the user inputs for the amount of score and the scores
// for homeworks, labs, quizzes, and exams and then calculates the students
// weighted grade (since some section weighs more than others) and the 
// final grade on a 4 point scale.


#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 100
#define TOTAL 10

void readName(char * name);
int readTotals(char *type);
void fillArray(char * type, int array[], int total);
double calcAvg(int array[], int total);
void displayAverage(char * type, double avg);
double calcWeighted(double labAvg, double LABP, double hwAvg, double HWP, double quizAvg, double QUIZP, double examAvg, double EXAMP);
double calcGrade(double weightedAvg);
void display(double weightedAvg, double finalGrade);


const double LABP = .2, HWP = .3, QUIZP = .11, EXAMP = .39;

int main()
{
    char name[MAX];
    int hwTotal, quizTotal, labsTotal, examsTotal;
    int hw[TOTAL], quizzes[TOTAL], labs[TOTAL], exams[TOTAL];
    double labAvg, hwAvg, quizAvg, examAvg, weightedAvg, finalGrade;

    readName(name);

    labsTotal = readTotals("Labs");
    fillArray("Labs", labs, labsTotal);
    labAvg = calcAvg(labs,labsTotal);
    displayAverage("Lab", labAvg);

    hwTotal = readTotals("Homeworks");
    fillArray("Homeworks", hw, hwTotal);
    hwAvg = calcAvg(hw,hwTotal);
    displayAverage("Homework", hwAvg);

    quizTotal = readTotals("Quizzes");
    fillArray("Quizzes", quizzes, quizTotal);
    quizAvg = calcAvg(quizzes, quizTotal);
    displayAverage("Quiz", quizAvg);

    examsTotal = readTotals("Exams");
    fillArray("Exams", exams, examsTotal);
    examAvg = calcAvg(exams,examsTotal);
    displayAverage("Exam", examAvg);

    weightedAvg = calcWeighted(labAvg, LABP, hwAvg, HWP, quizAvg, QUIZP, examAvg, EXAMP);
    finalGrade = calcGrade(weightedAvg);

    display(weightedAvg, finalGrade);

    return 0;
}// end main

// post: takes in the name of the students input
void readName(char * name)
{
   printf("The name is: ");
   fgets(name, MAX, stdin);
}

// post: takes in the total amount of scores that will be inputed. must be between 1 - 9
int readTotals(char *type)
{
   int x;
   int total;
   printf("Please enter the %s total ", type);
   scanf("%d", &total);
   while(total > 10 || total < 1) {\
      printf("Please enter the %s total ", type);
      scanf("%d", &total);
   }  
   return total; 
}

// post: takes the users input of scores for the specific section
void fillArray(char * type, int array[], int total)
{
   int x;
   for(x=0; x < total; x++) {
      printf("Please enter %s score ", type);
      scanf("%d", &array[x]);
      while(array[x] < 1 || array[x] > 100) {
         printf("Please enter %s score ", type);
         scanf("%d", &array[x]);
      }
   }
}

// post: calculate the average of the scores for the specific section
double calcAvg(int array[], int total)
{
   int x;
   double totalScore;
   for(x = 0; x < total; x++) {
      totalScore += array[x];
   }
   return (totalScore / total);   
}

// post: display results of the average score on the section.
void displayAverage(char * type, double avg)
{
   printf("%s The average is: %.01f\n", type, avg);
}

// post: does the calculation for the final grade with the weight of each section
double calcWeighted(double labAvg, double LABP, double hwAvg, double HWP, double quizAvg, double QUIZP, double examAvg, double EXAMP)
{
    double result;
    
    result = labAvg * LABP;
    result += hwAvg * HWP;
    result += quizAvg * QUIZP;
    result += examAvg * EXAMP;
    return result;
}

// post: calculates the final grade on a 4 point scale
double calcGrade(double weightedAvg)
{
    return 4.2-((100 - weightedAvg)/12.0);
}

// post: display the results
void display(double weightedAvg, double finalGrade)
{
   printf("Your weighted percentage is: %.01f\n", weightedAvg);
   printf("Your final grade is: %.01f\n", finalGrade);
}

