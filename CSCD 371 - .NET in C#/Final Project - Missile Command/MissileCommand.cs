// Hung Auduong && Brian Buermann
// CSCD 371 Final
// 
// Missile Command
// This is a missile command replica game inspired by the famous Missile Command Game by Atari back in the 90s.
// this is the main class that handles the the games function. players have several settings that they 
// can choose before playing the game.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MissileCommand {
   public partial class MissileCommand : Form {

      private Base defense;
      private int numDefenseMissile;
      private int activeDefMissile = 0;
      private int defMissileCounter = 0;

      private int numEnemyMissile;
      private int enemyMissileCounter = 0;
      private int enemyMissileDestroy = 0;

      private int numCities;
      private int numCityLost = 0;
      private int gameLevel = 1;
      private bool constantSpeed;

      int currScore = 0;
      int hiscore = 0;
      double timer = 0.0;

      private City[] city;
      private List<Missile> enemyMissile = new List<Missile>();
      private List<Missile> defenseMissile = new List<Missile>();
      private List<Explosion> explosionList = new List<Explosion>();

      System.Windows.Forms.Timer wt = new System.Windows.Forms.Timer();
      System.Media.SoundPlayer explode;

      private bool isPause = true;
      private bool gameOver = true;
      private int cityDestroyed = 0;


      public MissileCommand() {
         InitializeComponent();
         MaximizeBox = false;
         this.Size = new Size(1000, 750);
         numCities = 6;
         city = new City[6];
         for (int i = 0; i < numCities; i++) {
            if (i < (numCities / 2)) {
               if (numCities == 6) {
                  city[i] = new City(65.0 * (i + 1) + 90, 645.0);
               }
            } else {
               city[i] = new City(65.0 * (i + 1) + 175, 645.0);
            }
         }
         wt.Interval = 50;
         wt.Tick += new EventHandler(wt_Tick);
         wt.Enabled = false;

         SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.UserPaint,
            true);
         Invalidate();
         explode = new System.Media.SoundPlayer();
         explode.SoundLocation = "explode.wav";       
      }

      private void initializeGame() {
         if (gameLevel == 1) {

            defenseSetting();
            citySetting();
         }
         cityComboBox.Enabled = false;
         numMissileComboBox.Enabled = false;
         increaseCheckbox.Enabled = false;
         constantCheckbox.Enabled = false;
         gameOver = false;
         isPause = false;

         if (increaseCheckbox.Checked) {
            constantSpeed = false;
         } else {
            constantSpeed = true;
         }

         
         defense = new Base(numDefenseMissile);

         if (gameLevel == 1) {
            Array.Clear(city, 0, city.Length);
            city = new City[numCities];

            addCities();
         }

         if (numDefenseMissile != -1) {
            numEnemyMissile = (numDefenseMissile / 3) + gameLevel;
            if (numEnemyMissile > (numDefenseMissile - 5)) {
               numEnemyMissile = numDefenseMissile - 5;
            }
            addEnemyMissile(numEnemyMissile);
         } else {
            numEnemyMissile = 30 + gameLevel;
            addEnemyMissile(numEnemyMissile);
         }


         wt.Enabled = true;

         Invalidate();
      }

      private void wt_Tick(object sender, EventArgs e) {
         timer += 100.0;
         if (enemyMissileCounter < numEnemyMissile) {
            enemyMissileCounter++;
         }
         for (int i = 0; i < enemyMissileCounter; i++) {
            if (timer > enemyMissile[i].getLaunchTime && !enemyMissile[i].isDestroyed) {
               enemyMissile[i].updateSlope();
            }
         }

         for (int i = 0; i < defMissileCounter; i++) {
            defenseMissile[i].updateSlope();
         }
         if (currScore >= 10000) {
            extraCity();
         }

         checkDef();
         checkCity();
         checkMissileExplosion();
         Invalidate();

         if ((cityDestroyed - numCityLost == 3 || checkEnemMissile()) && enemyMissile.Count > 0) {
            nextLevel();
         } else if (checkGameStatus()) {
            endGame();
         }
      }

      private void addCities() {
         for (int i = 0; i < numCities; i++) {
            if (i < (numCities / 2)) {
               if (numCities == 6) {
                  city[i] = new City(65.0 * (i + 1) + 90.0, 645.0);
               } else if (numCities == 4) {
                  city[i] = new City(90.0 * (i + 1) + 90, 645.0);
               } else {
                  city[i] = new City(225.0, 645.0);
               }
            } else {
               if (numCities == 6) {
                  city[i] = new City(65.0 * (i + 1) + 175, 645.0);
               } else if (numCities == 4) {
                  city[i] = new City(90.0 * (i + 1) + 175, 645.0);
               } else {
                  city[i] = new City(495.0, 645.0);
               }
            }
         }
      }

      private void extraCity() {
         for (int i = 0; i < city.Length; i++) {
            if (city[i].isDestroy) {
               city[i].isDestroy = false;
               return;
            }
         }
      }


      private void addEnemyMissile(int amount) {
         Random rand = new Random();
         for (int em = 1; em <= amount; em++) {
            double start = rand.Next(125, 625);
            int target = rand.Next(city.Length);
            while (city[target].isDestroy) {
               target = rand.Next(city.Length);
            }
            int time = rand.Next(amount * 3000);
            if (constantSpeed) {
               Missile eMissile = new Missile(city[target].getX + 15.0, 615.0, start, 150, 1, Color.Crimson, Color.Yellow, time, false);
               enemyMissile.Add(eMissile);
            } else {
               Missile eMissile = new Missile(city[target].getX + 15.0, 615.0, start, 150, gameLevel, Color.Crimson, Color.Yellow, time, false);
               enemyMissile.Add(eMissile);
            }

         }
      }


      private void defenseSetting() {
         if (numMissileComboBox.Text.Equals("15")) {
            numDefenseMissile = 15;
            ammoLabel.Text = numDefenseMissile.ToString();
         } else if (numMissileComboBox.Text.Equals("Unlimited")) {
            numDefenseMissile = -1;
            ammoLabel.Text = " **";
         } else {
            numDefenseMissile = 30;
            ammoLabel.Text = " " + numDefenseMissile.ToString();
         }
      }

      private void citySetting() {
         if (cityComboBox.Text.Equals("2")) {
            numCities = 2;
         } else if (cityComboBox.Text.Equals("4")) {
            numCities = 4;
         } else {
            numCities = 6;
         }
      }


      private void playButton_Click(object sender, EventArgs e) {
         if (!isPause) {
            wt.Stop();
            isPause = true;
         } else if (isPause) {
            wt.Start();
            isPause = false;
         }
         if (gameOver) {
            initializeGame();
            settingGroupBox.Enabled = false;
         }
      }

      private void MissileCommand_Click(object sender, MouseEventArgs e) {
         if (!gameOver && !isPause) {
            int x = this.PointToClient(Cursor.Position).X;
            int y = this.PointToClient(Cursor.Position).Y;
            if ((x < 125 || x > 615) || (y < 150 || y > 605)) {
               return;
            }
            if (numDefenseMissile == -1 || (defMissileCounter < numDefenseMissile)) {
               defenseMissile.Add(new Missile(x, y, 375, 605, 20, Color.Blue, Color.YellowGreen, -1, false));
               defMissileCounter++;
               if (numDefenseMissile != -1) {
                  ammoLabel.Text = " " + (numDefenseMissile - defMissileCounter).ToString();
                  explode.Play();
               }
            }
         }

      }


      private void nextLevel() {
         wt.Stop();
         gameLevel++;
         level.Text = "Level: " + gameLevel;
         int cityScore = 0;
         currScore += (numDefenseMissile - defMissileCounter) * 10;
         for (int i = 0; i < city.Length; i++) {
            if (!city[i].isDestroy) {
               cityScore++;
            }
         }
         currScore += cityScore * 100;
         score.Text = currScore.ToString();
         if (currScore > hiscore) {
            hiscore = currScore;
            hiScore.Text = hiscore.ToString();
         }
         if (numDefenseMissile != -1) {
            numDefenseMissile = 30;
            defMissileCounter = 0;
            numEnemyMissile = (numDefenseMissile / 3) + gameLevel;
            enemyMissileCounter = 0;
         } else {
            numEnemyMissile = 30 + gameLevel;
         }
         enemyMissile.Clear();
         defenseMissile.Clear();
         explosionList.Clear();
         initializeGame();
         timer = 0.0;
         addEnemyMissile(numEnemyMissile);
         //wt.Stop();
         numCityLost = cityDestroyed;

      }

      protected async override void OnPaint(PaintEventArgs e) {
         Graphics g = e.Graphics;
         SolidBrush whiteBrush = new SolidBrush(Color.White);
         SolidBrush blackBrush = new SolidBrush(Color.Black);
         SolidBrush SpringGreenBrush = new SolidBrush(Color.SpringGreen);
         SolidBrush redBrush = new SolidBrush(Color.Red);
         SolidBrush blueBrush = new SolidBrush(Color.Blue);
         SolidBrush violetBrush = new SolidBrush(Color.Violet);

         int gameX = 500;
         int gameY = 500;

         Rectangle gameBorder = new Rectangle(124, 149, gameX + 2, gameY + 2);
         Rectangle gameRect = new Rectangle(125, 150, gameX, gameY);
         Rectangle groundRect = new Rectangle(125, gameY + 125, gameX, 25);
         g.FillRectangle(whiteBrush, gameBorder);
         g.FillRectangle(blackBrush, gameRect);
         g.FillRectangle(SpringGreenBrush, groundRect);

         drawBase(g, gameX, gameY, SpringGreenBrush);

         for (int i = 0; i < numCities; i++) {
            if (!city[i].isDestroy) {
               g.FillRectangle(violetBrush, (float) city[i].getX, gameY + 115, 30, 10);
            }
         }

         if (!isPause) {
            for (int i = 0; i < enemyMissileCounter; i++) {
               if (timer > enemyMissile[i].getLaunchTime && !enemyMissile[i].isDestroyed) {
                  drawMissile(g, enemyMissile[i]);
               }
            }
            for (int i = 0; i < defMissileCounter; i++) {
               if (!defenseMissile[i].isDestroyed) {
                  drawMissile(g, defenseMissile[i]);
               }
            }
            if (explosionList.Count >= 1) {
               for (int i = 0; i < explosionList.Count; i++) {
                  if (!explosionList[i].isDestroy) {
                     drawExplosionBigger(g, explosionList[i]);
                  }
               }
            }
         }


      }

      private void drawBase(Graphics g, int gameX, int gameY, SolidBrush SpringGreenBrush) {
         Rectangle tip = new Rectangle(370, gameY + 105, 10, 5);
         PointF point1 = new PointF(350, gameY + 125);
         PointF point2 = new PointF(360, gameY + 110);
         PointF point3 = new PointF(390, gameY + 110);
         PointF point4 = new PointF(400, gameY + 125);
         PointF[] curvePoints = { point1, point2, point3, point4 };
         FillMode newFillMode = FillMode.Winding;
         g.FillPolygon(SpringGreenBrush, curvePoints, newFillMode);
         g.FillRectangle(SpringGreenBrush, tip);
      }

      private void drawMissile(Graphics g, Missile missile) {//, int n) {
         Pen pen = new Pen(missile.getColor, 1);
         Pen headPen = new Pen(missile.getHeadColor, 1);
         g.DrawLine(pen, (float) missile.getStartX, (float) missile.getStartY, (float) missile.currX, (float) missile.currY);
         if (missile.slopeX < 0)
            g.DrawLine(headPen, (float) missile.currX, (float) missile.currY + 1, (float) missile.currX, (float) missile.currY);
         else
            g.DrawLine(headPen, (float) missile.currX, (float) missile.currY - 1, (float) missile.currX, (float) missile.currY);

      }



      private void drawExplosionBigger(Graphics g, Explosion explosion) {
         SolidBrush brush;
         Rectangle explosionBox;
         Random rand = new Random();
         int num = rand.Next(4);
         switch (num) {
            case 1:
            brush = new SolidBrush(Color.Red);
            break;
            case 2:
            brush = new SolidBrush(Color.Purple);
            break;
            case 3:
            brush = new SolidBrush(Color.Cyan);
            break;
            default:
            brush = new SolidBrush(Color.White);
            break;
         }
         if (explosion.getSizeWH() <= 100) {
            explosionBox = new Rectangle(explosion.getX() - explosion.getSizeWH() / 2, explosion.getY() - explosion.getSizeWH() / 2, explosion.getSizeWH(), explosion.getSizeWH());
            explosion.setSize(explosion.getSizeWH() + 1);
            g.FillEllipse(brush, explosionBox);
         } else {
            explosion.isDestroy = true;
         }
      }

      private void checkCity() {
         cityDestroyed = 0;
         for (int i = 0; i < enemyMissileCounter; i++) {
            for (int j = 0; j < city.Length; j++) {
               double difference = enemyMissile[i].currX - city[j].getX;
               if (enemyMissile[i].currY > 615 && (enemyMissile[i].currX > city[j].getX && enemyMissile[i].currX <= city[j].getX + 30)) {
                  city[j].isDestroy = true;
                  enemyMissile[i].Destroy();
                  enemyMissileDestroy++;
                  //player.Play();

               }
            }
         }
         for (int k = 0; k < city.Length; k++) {
            if (city[k].isDestroy) {
               cityDestroyed++;
            }
         }

      }

      private void checkDef() {
         for (int i = 0; i < defMissileCounter; i++) {
            double diffX = defenseMissile[i].currX - defenseMissile[i].getTargetX;
            double diffY = defenseMissile[i].currY - defenseMissile[i].getTargetY;
            if (Math.Abs(diffX) < 1 && Math.Abs(diffY) < 1 && !defenseMissile[i].isDestroyed) {
               explosionList.Add(new Explosion((int) defenseMissile[i].getTargetX, (int) defenseMissile[i].getTargetY));// = new Explosion(x, y);
               defenseMissile[i].Destroy();

            }
         }
      }

      private void checkMissileExplosion() {
         for (int i = 0; i < enemyMissile.Count; i++) {
            for (int j = 0; j < explosionList.Count; j++) {
               if (!explosionList[j].isDestroy) {
                  double x = enemyMissile[i].currX;
                  double y = enemyMissile[i].currY;
                  int x2 = explosionList[j].getX() - explosionList[j].getSizeWH() / 2;
                  int y2 = explosionList[j].getY() - explosionList[j].getSizeWH() / 2;
                  int size = explosionList[j].getSizeWH();
                  if (x >= x2 && x <= x2 + size && y >= y2 && y <= y2 + size) {
                     enemyMissile[i].Destroy();
                     enemyMissileDestroy++;

                  }
               }
            }
         }
      }

      private bool checkEnemMissile() {
         for (int i = 0; i < numEnemyMissile; i++) {
            if (enemyMissile[i].isDestroyed == false) {
               return false;
            }
         }
         return true;
      }

      private bool checkBase() {
         return defMissileCounter - numDefenseMissile == 0;
      }

      private bool checkGameStatus() {
         for (int i = 0; i < city.Length; i++) {
            if (!city[i].isDestroy) {
               return false;
            }
         }
         return true;
      }

      private void endGame() {         
         Invalidate();
         wt.Stop();
         MessageBox.Show("GameOver!");

      }

      private void pauseToolStripMenuItem_Click(object sender, EventArgs e) {
         playButton_Click(sender, e);
      }

      private void constantCheckbox_Click(object sender, EventArgs e) {
         if (increaseCheckbox.Checked) {
            increaseCheckbox.Checked = false;
         }
         constantCheckbox.Checked = true;
      }

      private void increaseLabel_Click(object sender, EventArgs e) {
         if (constantCheckbox.Checked) {
            constantCheckbox.Checked = false;
         }
         increaseCheckbox.Checked = true;
      }

      private void startToolStripMenuItem_Click(object sender, EventArgs e) {
         playButton_Click(sender, e);
      }

      private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
         Application.Exit();
      }

      private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
         rulesToolStripMenuItem_Click(sender, e);
      }

      private void rulesToolStripMenuItem_Click(object sender, EventArgs e) {
         string str = " Missile Command Game by Atari \n ";
         str += " destroy the missile before they hit the city \n";
         MessageBox.Show(str);
      }

      private void aboutToolStripMenuItem1_Click(object sender, EventArgs e) {
         MessageBox.Show("Missile Command by Brian and Hung");
      }
   }
}
