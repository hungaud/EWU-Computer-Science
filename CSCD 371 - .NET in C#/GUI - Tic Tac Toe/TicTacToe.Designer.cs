namespace Tic_Tac_Toe {
   partial class TicTacToe {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.menu = new System.Windows.Forms.MenuStrip();
         this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.modeBox = new System.Windows.Forms.GroupBox();
         this.twoPlay = new System.Windows.Forms.CheckBox();
         this.aiCheck = new System.Windows.Forms.CheckBox();
         this.resetButton = new System.Windows.Forms.Button();
         this.coinTossButton = new System.Windows.Forms.Button();
         this.compLabel = new System.Windows.Forms.Label();
         this.playerLabel = new System.Windows.Forms.Label();
         this.result = new System.Windows.Forms.Label();
         this.menu.SuspendLayout();
         this.modeBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // menu
         // 
         this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
         this.menu.Location = new System.Drawing.Point(0, 0);
         this.menu.Name = "menu";
         this.menu.Size = new System.Drawing.Size(317, 24);
         this.menu.TabIndex = 0;
         this.menu.Text = "menuStrip1";
         // 
         // gameToolStripMenuItem
         // 
         this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
         this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
         this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
         this.gameToolStripMenuItem.Text = "Game";
         // 
         // newGameToolStripMenuItem
         // 
         this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
         this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.newGameToolStripMenuItem.Text = "New Game";
         this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // settingToolStripMenuItem
         // 
         this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
         this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
         this.settingToolStripMenuItem.Text = "Setting";
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesToolStripMenuItem});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "Help";
         // 
         // rulesToolStripMenuItem
         // 
         this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
         this.rulesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.rulesToolStripMenuItem.Text = "Rules";
         this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
         // 
         // modeBox
         // 
         this.modeBox.Controls.Add(this.twoPlay);
         this.modeBox.Controls.Add(this.aiCheck);
         this.modeBox.Location = new System.Drawing.Point(12, 330);
         this.modeBox.Name = "modeBox";
         this.modeBox.Size = new System.Drawing.Size(151, 63);
         this.modeBox.TabIndex = 1;
         this.modeBox.TabStop = false;
         this.modeBox.Text = "Mode";
         // 
         // twoPlay
         // 
         this.twoPlay.AutoSize = true;
         this.twoPlay.Location = new System.Drawing.Point(6, 40);
         this.twoPlay.Name = "twoPlay";
         this.twoPlay.Size = new System.Drawing.Size(84, 17);
         this.twoPlay.TabIndex = 3;
         this.twoPlay.Text = "Two Players";
         this.twoPlay.UseVisualStyleBackColor = true;
         this.twoPlay.Click += new System.EventHandler(this.twoPlay_Click);
         // 
         // aiCheck
         // 
         this.aiCheck.AutoSize = true;
         this.aiCheck.Location = new System.Drawing.Point(6, 19);
         this.aiCheck.Name = "aiCheck";
         this.aiCheck.Size = new System.Drawing.Size(119, 17);
         this.aiCheck.TabIndex = 2;
         this.aiCheck.Text = "Play With Computer";
         this.aiCheck.UseVisualStyleBackColor = true;
         this.aiCheck.Click += new System.EventHandler(this.aiCheck_Click);
         // 
         // resetButton
         // 
         this.resetButton.Location = new System.Drawing.Point(236, 343);
         this.resetButton.Name = "resetButton";
         this.resetButton.Size = new System.Drawing.Size(75, 23);
         this.resetButton.TabIndex = 2;
         this.resetButton.Text = "Reset";
         this.resetButton.UseVisualStyleBackColor = true;
         this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
         // 
         // coinTossButton
         // 
         this.coinTossButton.Location = new System.Drawing.Point(236, 372);
         this.coinTossButton.Name = "coinTossButton";
         this.coinTossButton.Size = new System.Drawing.Size(75, 23);
         this.coinTossButton.TabIndex = 3;
         this.coinTossButton.Text = "Coin Toss";
         this.coinTossButton.UseVisualStyleBackColor = true;
         this.coinTossButton.Click += new System.EventHandler(this.coinTossButton_Click);
         // 
         // compLabel
         // 
         this.compLabel.AutoEllipsis = true;
         this.compLabel.AutoSize = true;
         this.compLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.compLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.compLabel.Location = new System.Drawing.Point(138, 33);
         this.compLabel.Name = "compLabel";
         this.compLabel.Size = new System.Drawing.Size(167, 16);
         this.compLabel.TabIndex = 4;
         this.compLabel.Text = "Computer/ Player 2 = O";
         // 
         // playerLabel
         // 
         this.playerLabel.AutoEllipsis = true;
         this.playerLabel.AutoSize = true;
         this.playerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.playerLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.playerLabel.Location = new System.Drawing.Point(12, 33);
         this.playerLabel.Name = "playerLabel";
         this.playerLabel.Size = new System.Drawing.Size(90, 16);
         this.playerLabel.TabIndex = 5;
         this.playerLabel.Text = "Player 1 = X";
         // 
         // result
         // 
         this.result.AutoSize = true;
         this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.result.Location = new System.Drawing.Point(103, 301);
         this.result.Name = "result";
         this.result.Size = new System.Drawing.Size(106, 16);
         this.result.TabIndex = 6;
         this.result.Text = "Player 1 WIN!!";
         // 
         // TicTacToe
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(317, 404);
         this.Controls.Add(this.result);
         this.Controls.Add(this.playerLabel);
         this.Controls.Add(this.compLabel);
         this.Controls.Add(this.coinTossButton);
         this.Controls.Add(this.resetButton);
         this.Controls.Add(this.modeBox);
         this.Controls.Add(this.menu);
         this.MainMenuStrip = this.menu;
         this.Name = "TicTacToe";
         this.Text = "Tic Tac Toe";
         this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ticTacToe_Click);
         this.menu.ResumeLayout(false);
         this.menu.PerformLayout();
         this.modeBox.ResumeLayout(false);
         this.modeBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menu;
      private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.GroupBox modeBox;
      private System.Windows.Forms.CheckBox aiCheck;
      private System.Windows.Forms.CheckBox twoPlay;
      private System.Windows.Forms.Button resetButton;
      private System.Windows.Forms.Button coinTossButton;
      private System.Windows.Forms.Label compLabel;
      private System.Windows.Forms.Label playerLabel;
      private System.Windows.Forms.Label result;
      private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
   }
}

