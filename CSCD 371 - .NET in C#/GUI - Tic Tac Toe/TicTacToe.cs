// Hung Auduong
// 3/06/17
// Tom Capaul
// CSCD 371
// 
// This window form is a game of tic tac toe. the user can play against the computer
// or against another player. when the game is won or is a tie.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe {
   public partial class TicTacToe : Form {
      private int[,] cell;
      private int[] cellX = new int[] { 45, 125, 205, 275};
      private int[] cellY = new int[] { 55, 135, 215, 285};

      private bool gameOver;

      private bool player1Turn;
      private bool aiTurn;
      private bool player2Turn;
      private bool computer;
     
      int x;
      int y;
  
      int turn;

      public TicTacToe() {
         InitializeComponent();
         MaximizeBox = false;
         this.FormBorderStyle = FormBorderStyle.FixedSingle;
         this.Size = new Size(335, 450);
         gameOver = true;

         initializeGame();
      }

      // post: initialize the game
      private void initializeGame() {
         cell = new int[3, 3]   {   {0, 0, 0},
                                    {0, 0, 0},
                                    {0, 0, 0} };

         resetButton.Enabled = false;
         result.Text = "";
         turn = 0;
         aiCheck.Checked = false;
         twoPlay.Checked = false;
         computer = true;
         Invalidate();
      }

      // post: player 1 or 2 click event, handles what happens when clicked in the form
      //       also makes sure the cell that the user click is a valid move in the game
      private void ticTacToe_Click(object sender, MouseEventArgs e) {
         if (!gameOver && turn <= 9) {
            x = this.PointToClient(Cursor.Position).X;
            y = this.PointToClient(Cursor.Position).Y;
            if ((x < cellX[0] || x > cellX[3]) || (y < cellY[0] || y > cellY[3])) {
               MessageBox.Show("Cant make a move here!!");
               return;
            }
            bool validMove = setXY(x, y);
            if (validMove) {
               if (player1Turn) {
                  player1Turn = false;
                  if (!computer) {
                     result.Text = "Player 2's Turn";
                     player2Turn = true;

                  } else {
                     result.Text = "Computer's Turn";
                     aiTurn = true; 
                     computerTurn();
                  }
               } else if (player2Turn) {
                  player2Turn = false;
                  if (!computer) {
                     player1Turn = true;
                     result.Text = "Player 1's Turn";
                  }
               }
               checkGameStatus();
               Invalidate();
            }
         }
      }

      // post: sets the x and y to a specific cell to make sure the cell
      //       is availible to play on
      private bool setXY(int x, int y) {
         bool result = false;
         for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
               if ((x > cellX[j] && x < cellX[j + 1] - 10) && (y > cellY[i] && y < cellY[i + 1] - 10)) {
                  if (player1Turn && cell[j, i] == 0) {
                     cell[j, i] = 1;
                     turn++;
                     result = true;
                  } else if((player2Turn || aiTurn) && cell[j, i] == 0) {
                     cell[j, i] = 2;
                     turn++;
                     result = true;
                  }
               }
            }
         }
         return result;
      }

      // post: handles the computer move with a random number gen
      private void computerTurn() {
         Random r = new Random();
         int r1 = r.Next(0, 3);
         int r2 = r.Next(0, 3);
         while (cell[r1, r2] != 0) {
            r1 = r.Next(0, 3);
            r2 = r.Next(0, 3);
         }
         cell[r1, r2] = 2;
         turn++;

         aiTurn = false;
         player1Turn = true;
         result.Text = "Player 1's Turn";
         checkGameStatus();
         Invalidate();
      }

      // post: draws out the gameboard layout and along with that, the Xs and Os
      //       that represents the player 1 moves vs player 2/ computer
      protected override void OnPaint(PaintEventArgs e) {
         Graphics g = e.Graphics;
         int gameY = 230;
         int gameX = 230;
         int cellWidth = 70;
         int cellHeight = 70;
         this.BackColor = Color.Gray;
         SolidBrush whiteBrush = new SolidBrush(Color.White);
         SolidBrush grayBrush = new SolidBrush(Color.Gray);
         Pen bluePen = new Pen(Color.Blue, 3);
         Pen redPen = new Pen(Color.Red, 3);
         Rectangle gameRect = new Rectangle(45, 55, gameX, gameY);
         g.FillRectangle(whiteBrush, gameRect);

         //draws cells;
         for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
               Rectangle cellRect = new Rectangle(cellX[j], cellY[i], cellWidth, cellHeight);
               g.FillRectangle(grayBrush, cellRect);
            }
         }

         // draws the x/o
         for (int k = 0; k < 3; k++) {
            for (int l = 0; l < 3; l++) {
               if (cell[k, l] == 1) {
                  e.Graphics.DrawLine(bluePen, cellX[k], cellY[l], cellX[k] + cellWidth, cellY[l] + cellHeight);
                  e.Graphics.DrawLine(bluePen, cellX[k] + cellWidth, cellY[l], cellX[k], cellY[l] + cellHeight);
               } else if (cell[k, l] == 2) {
                  e.Graphics.DrawEllipse(redPen, cellX[k], cellY[l], cellWidth, cellHeight);
               }
            }
         }
      }

      // post: flips a coin to see who goes first and to intialize the game
      private void coinTossButton_Click(object sender, EventArgs e) {
         Random r = new Random();
         int coin = r.Next(0, 2);
         if (coin == 1) {
            result.Text = "Player 1's Turn!";
            player1Turn = true;
         } else {
            if (twoPlay.Checked) {
               result.Text = "Player 2's Turn!";
               player2Turn = true;
            } else {
               result.Text = "Computer's Turn!";
               aiTurn = true;
               computerTurn();
            }
         }
         coinTossButton.Enabled = false;
         resetButton.Enabled = true;
         aiCheck.Enabled = false;
         twoPlay.Enabled = false;
         gameOver = false;
      }

      // post: checks the game's status if a someones won yet or if the game is over
      //       it first checks all the vertical cells then the horizontals
      //       then the diagnols. then lastly checks if its a tie.
      private void checkGameStatus() {
         
         // vertical LEFT
         if (cell[0, 0] == cell[1, 0] && cell[0, 0] == cell[2, 0]) {
            if (cell[0, 0] == 1) {
               endGame("player 1 WIN!!!");
            } else if (cell[0, 0] == 2) {
               if (!computer) {
                  endGame("Player 2 WIN!!!");
               } else {
                  endGame("The computer Won :/");
               }
            }
            return;
         }
         // vertical MIDDLE
         if (cell[0, 1] == cell[1, 1] && cell[0, 1] == cell[2, 1]) {
            if (cell[0, 1] == 1) {
               endGame("player 1 WIN!!!");
            } else if (cell[0, 1] == 2) {
               if (!computer) {
                  endGame("Player 2 WIN!!!");
               } else {
                  endGame("The computer Won :/");
               }
            }
            return;
         }
         // vertical RIGHT
         if (cell[0, 2] == cell[1, 2] && cell[0, 2] == cell[2, 2]) {
            if (cell[0, 2] == 1) {
               endGame("player 1 WIN!!!");
            } else if (cell[0, 2] == 2) {
               if (!computer) {
                  endGame("Player 2 WIN!!!");
               } else {
                  endGame("The computer Won :/");
               }
            }
            return;
         }
         // horizontal TOP
         if (cell[0, 0] == cell[0, 1] && cell[0, 0] == cell[0, 2]) {
            if (cell[0, 0] == 1) {
               endGame("player 1 WIN!!!");
            } else if (cell[0, 0] == 2) {
               if (!computer) {
                  endGame("Player 2 WIN!!!");
               } else {
                  endGame("The computer Won :/");
               }
            }
            return;
         }
         // horizontal MIDDLE
         if (cell[1, 0] == cell[1, 1] && cell[1, 0] == cell[1, 2]) {
            if (cell[1, 0] == 1) {
               endGame("player 1 WIN!!!");
            } else if (cell[1, 0] == 2) {
               if (!computer) {
                  endGame("Player 2 WIN!!!");
               } else {
                  endGame("The computer Won :/");
               }
            }
            return;
         }
         // horizontal BOTTOM
         if (cell[2, 0] == cell[2, 1] && cell[2, 0] == cell[2, 2]) {
            if (cell[2, 0] == 1) {
               endGame("player 1 WIN!!!");
            } else if (cell[2, 0] == 2) {
               if (!computer) {
                  endGame("Player 2 WIN!!!");
               } else {
                  endGame("The computer Won :/");
               }
            }
            return;
         }
         // diagnol LEFT TOP
         if (cell[0, 0] == cell[1, 1] && cell[0, 0] == cell[2, 2]) {
            if (cell[0, 0] == 1) {
               endGame("player 1 WIN!!!");
            } else if (cell[0, 0] == 2) {
               if (!computer) {
                  endGame("Player 2 WIN!!!");
               } else {
                  endGame("The computer Won :/");
               }
            }
            return;
         }  
         // diagnol RIGHT TOP
         if (cell[0, 2] == cell[1, 1] && cell[0, 2] == cell[2, 0]) {
            if (cell[0, 2] == 1) {
               endGame("player 1 WIN!!!");
            } else if (cell[0, 2] == 2) {
               if (!computer) {
                  endGame("Player 2 WIN!!!");
               } else {
                  endGame("The computer Won :/");
               }
            }
            return;
         }
         // TIE
         if (turn == 9) {
            endGame("TIE GAME");
         }
      }

      // post: ends the game
      private void endGame(string s) {
         result.Text = s;
         gameOver = true;
      }

      // post: reset button on the menu item
      private void newGameToolStripMenuItem_Click(object sender, EventArgs e) {
         resetButton_Click(sender, e);
      }

      // post: resets the game
      private void resetButton_Click(object sender, EventArgs e) {
         initializeGame();
         coinTossButton.Enabled = true;
         aiCheck.Enabled = true;
         twoPlay.Enabled = true;
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
         Application.Exit();
      }

      // post: make sure that the user will play against the computer
      //       if this is checked then two player option will be unchecked
      private void aiCheck_Click(object sender, EventArgs e) {
         if (twoPlay.Checked) {
            twoPlay.Checked = false;
         }
         aiCheck.Checked = true;
         computer = true;
      }

      // post: make sure that the user will play against another player
      //       if this is cehcked then the play against computer is unchecked
      private void twoPlay_Click(object sender, EventArgs e) {
         if (aiCheck.Checked ) {
            aiCheck.Checked = false;
         }
         twoPlay.Checked = true;
         computer = false;
      }

      // post: about, the rules to play tic tac toe
      private void rulesToolStripMenuItem_Click(object sender, EventArgs e) {
         string s = "";
         s += "Simple game of TIC TAC TOE, try to get 3 in a row to Win! \n";
         s += "You can choose to play against the computer or another player \n";
         s += "flip a coin to see who goes first \n";
         s += "GOOD LUCK! \n";
         MessageBox.Show(s);
      }
   }
}
