#include "lab10.h"
#include "utils.h"

int playAgain() {
   char result;
   printf("Play again?");
   scanf("%c", &result);
   
   if(result == 'y' || result == 'Y') {
      return 1;
   } else {
      return 0;
   }
}
void instructions() {
   printf("A game of Hangman \n");
   printf("player 1 will choose a word \n");
   printf("player 2 will have 7 tries to guess the word \n");
   
}

void readName(char *name) {
   printf("Please enter player's name: ");
   fgets(name, MAX, stdin);
   strip(name);
   //stripInputBuffer(stdin);
}

void readWord(char *word) {
   printf("Player 1, please enter the word to guess: ");
   fgets(word, MAX, stdin);
   strip(word);
   //stripInputBuffer(stdin);
   toLowercaseString(word);
}

int playGame(char *word, char *alphabet, int wordLength) {
   char guess[1]; // might change to string
   char correctGuess[wordLength];
   int turns = 0;
   int correct = 0;
   int validGuess = 0;
   int i;
   printf("Your word contains %d ", wordLength);
   printf("letters. \n");
   
   //prints original -
   for(i = 0; i < wordLength; i++) {
      correctGuess[i] = '-';
      printf("-");   
   }
   
   //while still have turns or correct word hasnt been guessed yet
   while(turns < 7 && correct == 0) {
      printf("\nAvailible Letters: ");
      for(i = 0; i < 27; i++) {
         printf("%c", alphabet[i]);
      }
      printf("\nEnter a Letter: ");
      fgets(guess, MAX, stdin);
      strip(guess);
      
      // iterate thru make sure player doesnt guess the 
      // same letter or even if its an actual letter
      for(i = 0; i < 27; i++) {
         if(*guess == alphabet[i]) {
            validGuess = 1;
         }
      }
      if(validGuess == 0) {
         printf("Letter either has already been guessed or is invalid");
      } else {
         validGuess = 0;
         //wrong guess
         if(isLetterInWord(guess[0], word, alphabet, wordLength) == 0) {
            turns++;
            printf("\nIncorrect guess! You have %d", (7 - turns));
            printf(" more tries! \n");
         }
         //print off the results of the word after the guess
         for(i = 0; i < wordLength; i++) {n
         
            if(word[i] == *guess) {
               correctGuess[i] = *guess;
            }
            //strip(correctGuess);
            toLowercaseString(correctGuess);
            
            printf("%c",correctGuess[i]);
         }
         printf("\n");
         //checks if the word has been fully guessed
         correct = 1;
         for(i = 0; i < wordLength; i++) {
            if(correctGuess[i] != word[i]) {
               correct = 0;
            }
         }
      }
       
   }
   
   if(correct == 1) {
      return 1;
   } else {
      return 0;
   }
   
   
}


void printResults(int winner, char *name, char *word) {

}


int isLetterInWord(char letter, char *word, char *alphabet, int wordLength) {
   int i;
   int letterInWord = 0;
   
   for(i = 0; i < wordLength; i++) {
      if(letter == word[i]) {
         letterInWord = 1;
      }
   }
   for(i = 0; i < 27; i++) {
      if(letter == alphabet[i]) {
         alphabet[i] = ' ';
      }
      
   }
   
   return letterInWord;

}