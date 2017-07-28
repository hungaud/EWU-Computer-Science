// Hung Auduong
// cscd 240
// lab 10

#include "lab10.h"
#include "utils.h"

int playAgain() {
   char result[MAX];
   stripInputBuffer(stdin);
   printf("Play again? (y/n)");
   fgets(result, MAX, stdin);
   strip(result);
   if(*result == 'y' || *result == 'Y') {
      return 1;
   } else {
      return 0;
   }
}

// post: print instruction of the game
void instructions() {
   printf("A game of Hangman \n");
   printf("player 1 will choose a word \n");
   printf("player 2 will have 7 tries to guess the word \n");
   
}

// post: read in player's name
void readName(char *name) {
   printf("Please enter player's name: ");
   fgets(name, MAX, stdin);
   strip(name);
   //stripInputBuffer(stdin);
}

// post: read players word
void readWord(char *word) {
   printf("Player 1, please enter the word to guess: ");
   fgets(word, MAX, stdin);
   strip(word);
   toLowercaseString(word);
}

// post: plays the game. 
int playGame(char *word, char *alphabet, int wordLength) {
   char guess; 
   char correctGuess[wordLength];
   int turns = 0;
   int correct = 0;
   int validGuess = 0;
   int i;
   printf("Your word contains %d ", wordLength);
   printf("letters. \n");
   for(i = 0; i < wordLength; i++) {
      correctGuess[i] = '-';
      printf("-");   
   }
   while(turns < 7 && correct == 0) {
      printf("\nAvailible Letters: ");
      for(i = 0; i < 27; i++) {
         printf("%c", alphabet[i]);
      }
      printf("\nEnter a Letter: ");
      scanf(" %c", &guess);
      for(i = 0; i < 27; i++) {
         if(guess == alphabet[i]) {
            validGuess = 1;
         }
      }
      if(validGuess == 0) {
         printf("Letter either has already been guessed or is invalid \n");
      } else {
         validGuess = 0;
         //wrong guess
         if(isLetterInWord(guess, word, alphabet, wordLength) == 0) {
            turns++;
            printf("\nIncorrect guess! You have %d", (7 - turns));
            printf(" more tries! \n");
         }
         //print off the results of the word after the guess
         for(i = 0; i < wordLength; i++) {
         
            if(word[i] == guess) {
               correctGuess[i] = guess;
            }
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

// post: prints results
void printResults(int winner, char *name, char *word) {
   int i;
   if(winner == 1) {
      printf("Congratulations! Player 2 has won\n");
   } else {
      printf("Sorry! You lost\n");
   }
}

// post: checks if the letter guessed by the user is a correct guess
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