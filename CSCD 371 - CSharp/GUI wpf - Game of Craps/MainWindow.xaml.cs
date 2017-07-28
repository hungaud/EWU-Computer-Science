// Hung Auduong
// 2/26/16
// Tom Capaul
// Games of craps. Basic dice game that allows user to play the game
// also has a betting option when starting the game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;

namespace Craps {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {

      private int point;
      private int playerWinTotal;
      private int houseWinTotal;
      private bool isPlayAgain;
      private Die dice;
      private int nRoll;
      private bool isBet;
      Player p;
      private int n;
      private Window1 gambleWindow;

      public MainWindow() {
         InitializeComponent();
         playerWinTotal = 0;
         houseWinTotal = 0;
         rollDiceButton.IsEnabled = false;
         playAgainButton.IsEnabled = false;
         balanceText.IsReadOnly = true;
         betText.IsEnabled = false;
         disableRichTextBox();
         isPlayAgain = false;
      }

      // post: start the game without betting
      private void startMenuItem_Click(object sender, RoutedEventArgs e) {
         p = new Player();
         initGame(playerWinTotal, houseWinTotal);
         isBet = false;
      }

      // post: starts the game with betting
      private void startBet_Click(object sender, RoutedEventArgs e) {
         if (!isPlayAgain) {
            betText.IsEnabled = true;
            p = new Player(true);
            gambleWindow = new Window1(p);
            gambleWindow.Show();
         }
         isBet = true;
         initGame(playerWinTotal, houseWinTotal);
      }

      // post: initiate the game
      private void initGame(int playerWin, int houseWin) {
         startMenuItem.IsEnabled = false;
         startBet.IsEnabled = false;
         rollDiceButton.IsEnabled = true;
         dice = new Die();
         nRoll = 0;
         point = 0;
         playerWinTotal = playerWin;
         houseWinTotal = houseWin;

      }

      // post: rolls the dice. when clicked itll display the result of the dice roll. if 
      //       the user is gambling, then itll show the user's balance also the user's
      //       input for the amount they want to gamble. it sets limation on what the user
      //       is allowed to put in though.
      private void rollDiceButton_Click(object sender, RoutedEventArgs e) {
         if (isBet) {
            balanceText.Text = p.balance.ToString();
         }
         if (isBet && betText.Text == "") {
            MessageBox.Show("please put in a bet");
            return;
         } else if (isBet && (p.balance < int.Parse(betText.Text))) {
            MessageBox.Show("Bet is too high, you don't have enough!!");
            return;
         } else {
            dice.roll();
            nRoll++;
            int diceOne = dice.dieRoll1;
            int diceTwo = dice.dieRoll2;
            int diceSum = dice.getSum;

            currentRollClear();
            rollOneTextBox.Document.Blocks.Add(new Paragraph(new Run(diceOne.ToString())));
            rollTwoTextBox.Document.Blocks.Add(new Paragraph(new Run(diceTwo.ToString())));
            sumTextBox.Document.Blocks.Add(new Paragraph(new Run(diceSum.ToString())));

            if (nRoll == 1 && (diceSum == 7 || diceSum == 11)) {
               gameOver(true);
            } else if (nRoll == 1 && (diceSum == 2 || diceSum == 3 || diceSum == 12)) {
               gameOver(false);
            } else {
               if (nRoll == 1) {
                  point = diceSum;
                  pointTextBox.Document.Blocks.Clear();
                  pointTextBox.Document.Blocks.Add(new Paragraph(new Run(point.ToString())));
               } else if (diceSum == point && nRoll > 1) {
                  gameOver(true);
               } else if (diceSum == 7) {
                  gameOver(false);
               }
            }
         }
      }

      // post: when the game is won/lost. display the results accordingly along with 
      //       the users and the house's win record.
      private void gameOver(bool playerWin) {
         rollDiceButton.IsEnabled = false;
         playAgainButton.IsEnabled = true;
         if (playerWin) {
            playerWinTotal++;
            resultLabel.Content = "WINNER!!!!";
            playerWinTextbox.Document.Blocks.Clear();
            playerWinTextbox.Document.Blocks.Add(new Paragraph(new Run(playerWinTotal.ToString())));
            if (isBet) {
               p.balance += int.Parse(betText.Text);
               balanceText.Text = p.balance.ToString();
            }
         } else {
            houseWinTotal++;
            resultLabel.Content = "Sorry! You lose!";
            houseWinTextbox.Document.Blocks.Clear();
            houseWinTextbox.Document.Blocks.Add(new Paragraph(new Run(houseWinTotal.ToString())));
            if (isBet) {
               p.balance -= int.Parse(betText.Text);
               balanceText.Text = p.balance.ToString();
               if (p.balance <= 0) {
                  MessageBox.Show("You lost all your money :(");
                  playAgainButton.IsEnabled = false;
               }
            }
         }
      }

      // post: allow the user to play the game again and clear the result of
      //       the previous game except for the win record
      private void playAgainButton_Click(object sender, RoutedEventArgs e) {
         currentRollClear();
         isPlayAgain = true;
         pointTextBox.Document.Blocks.Clear();
         resultLabel.Content = "";
         playAgainButton.IsEnabled = false;
         if (p.isBet()) {
            startBet_Click(sender, e);
         } else {
            startMenuItem_Click(sender, e);
         }
      }

      private void rulesMenuItem_Click(object sender, RoutedEventArgs e) {
         string rules = "* A player rolls two dice where each die has six faces in the usual way(values 1\n";
         rules += "   through 6).\n";
         rules += "* After the dice have come to rest the sum of the two upward faces is calculated.\n";
         rules += "* The first roll\n";
         rules += "     - If the sum is 7 or 11 on the first throw the roller / player wins.\n";
         rules += "     - If the sum is 2, 3 or 12 the roller/ player loses, that is the house wins.\n";
         rules += "     - if the sum is 4, 5, 6, 8, 9, or 10, that sum becomes the roller / player's \"point\".\n";
         rules += "* Continue given the player's point\n";
         rules += "     - Now the player must roll the \"point\" total before rolling a 7 in order to win.\n";
         rules += "     - If they roll a 7 before rolling the point value they got on the first roll the\n";
         rules += "       roller / player loses(the 'house' wins).\n";
         MessageBox.Show(rules);
   }

      private void aboutMenuItem_Click(object sender, RoutedEventArgs e) {
         string result = "Hung Auduong\n";
         result += Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\n";
         result += ".NET Framework: 4.5.2\n";
         if (Environment.Is64BitOperatingSystem) {
            result += "64 Bit";
         } else {
            result += "32 Bit";
         }
         MessageBox.Show(result);
      }

      // post: reset the game as if the app just first started
      private void resetMenuItem_Click(object sender, RoutedEventArgs e) {
         playerWinTotal = 0;
         houseWinTotal = 0;
         playerWinTextbox.Document.Blocks.Clear();
         houseWinTextbox.Document.Blocks.Clear();
         pointTextBox.Document.Blocks.Clear();
         currentRollClear();
         resultLabel.Content = "";
         rollDiceButton.IsEnabled = false;
         playAgainButton.IsEnabled = false;
         startMenuItem.IsEnabled = true;
         startBet.IsEnabled = true;
         balanceText.Text = "";
         betText.Text = "";
         MessageBox.Show("Game has been Restarted, You can chose to\n" +
                           "start again or start with a bet");
      }

      private void exit_Click(object sender, RoutedEventArgs e) {
         MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
         if (messageBoxResult == MessageBoxResult.Yes) {
            Application.Current.Shutdown();
         }
      }


      // post: make sure the user inputs numeric value for bets
      private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
         Regex regex = new Regex("[^0-9]+");
         e.Handled = regex.IsMatch(e.Text);
      }

      // post: disable textbox changes
      private void disableRichTextBox() {
         rollOneTextBox.IsReadOnly = true;
         rollTwoTextBox.IsReadOnly = true;
         sumTextBox.IsReadOnly = true;
         playerWinTextbox.IsReadOnly = true;
         houseWinTextbox.IsReadOnly = true;
      }

      // post: clear the results of the dice rolls;
      private void currentRollClear() {
         rollOneTextBox.Document.Blocks.Clear();
         rollTwoTextBox.Document.Blocks.Clear();
         sumTextBox.Document.Blocks.Clear();
      }

   }
}
