namespace MissileCommand {
   partial class MissileCommand {
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
         this.GameMenu = new System.Windows.Forms.ToolStripMenuItem();
         this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.playButton = new System.Windows.Forms.PictureBox();
         this.scoreLabel = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.score = new System.Windows.Forms.Label();
         this.hiScore = new System.Windows.Forms.Label();
         this.level = new System.Windows.Forms.Label();
         this.settingGroupBox = new System.Windows.Forms.GroupBox();
         this.speedLabel = new System.Windows.Forms.Label();
         this.increaseCheckbox = new System.Windows.Forms.CheckBox();
         this.constantCheckbox = new System.Windows.Forms.CheckBox();
         this.cityLabel = new System.Windows.Forms.Label();
         this.cityComboBox = new System.Windows.Forms.ComboBox();
         this.missileLabel = new System.Windows.Forms.Label();
         this.numMissileComboBox = new System.Windows.Forms.ComboBox();
         this.ammoLabel = new System.Windows.Forms.Label();
         this.menuStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.playButton)).BeginInit();
         this.settingGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // GameMenu
         // 
         this.GameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.closeToolStripMenuItem});
         this.GameMenu.Name = "GameMenu";
         this.GameMenu.Size = new System.Drawing.Size(50, 20);
         this.GameMenu.Text = "Game";
         // 
         // startToolStripMenuItem
         // 
         this.startToolStripMenuItem.Name = "startToolStripMenuItem";
         this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.startToolStripMenuItem.Text = "Start / Pause";
         this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
         // 
         // closeToolStripMenuItem
         // 
         this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
         this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.closeToolStripMenuItem.Text = "Close";
         this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.aboutToolStripMenuItem1});
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
         this.aboutToolStripMenuItem.Text = "About";
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.helpToolStripMenuItem.Text = "Help";
         this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
         // 
         // rulesToolStripMenuItem
         // 
         this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
         this.rulesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.rulesToolStripMenuItem.Text = "Rules";
         this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem1
         // 
         this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
         this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
         this.aboutToolStripMenuItem1.Text = "About";
         this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenu,
            this.aboutToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(979, 24);
         this.menuStrip1.TabIndex = 0;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // playButton
         // 
         this.playButton.BackColor = System.Drawing.Color.Transparent;
         this.playButton.Image = global::MissileCommand.Properties.Resources.playButton;
         this.playButton.Location = new System.Drawing.Point(275, 35);
         this.playButton.Name = "playButton";
         this.playButton.Size = new System.Drawing.Size(200, 80);
         this.playButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.playButton.TabIndex = 1;
         this.playButton.TabStop = false;
         this.playButton.Click += new System.EventHandler(this.playButton_Click);
         // 
         // scoreLabel
         // 
         this.scoreLabel.AutoSize = true;
         this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
         this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.scoreLabel.ForeColor = System.Drawing.Color.Aqua;
         this.scoreLabel.Location = new System.Drawing.Point(125, 125);
         this.scoreLabel.Name = "scoreLabel";
         this.scoreLabel.Size = new System.Drawing.Size(87, 25);
         this.scoreLabel.TabIndex = 2;
         this.scoreLabel.Text = "Score: ";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.BackColor = System.Drawing.Color.Transparent;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.Color.Aqua;
         this.label1.Location = new System.Drawing.Point(380, 125);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(116, 25);
         this.label1.TabIndex = 3;
         this.label1.Text = "Hi Score: ";
         // 
         // score
         // 
         this.score.AutoSize = true;
         this.score.BackColor = System.Drawing.Color.Transparent;
         this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.score.ForeColor = System.Drawing.Color.Aqua;
         this.score.Location = new System.Drawing.Point(205, 129);
         this.score.Name = "score";
         this.score.Size = new System.Drawing.Size(18, 20);
         this.score.TabIndex = 4;
         this.score.Text = "0";
         // 
         // hiScore
         // 
         this.hiScore.AutoSize = true;
         this.hiScore.BackColor = System.Drawing.Color.Transparent;
         this.hiScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.hiScore.ForeColor = System.Drawing.Color.Aqua;
         this.hiScore.Location = new System.Drawing.Point(490, 130);
         this.hiScore.Name = "hiScore";
         this.hiScore.Size = new System.Drawing.Size(18, 20);
         this.hiScore.TabIndex = 5;
         this.hiScore.Text = "0";
         // 
         // level
         // 
         this.level.AutoSize = true;
         this.level.BackColor = System.Drawing.Color.Transparent;
         this.level.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.level.ForeColor = System.Drawing.Color.Lime;
         this.level.Location = new System.Drawing.Point(332, 652);
         this.level.Name = "level";
         this.level.Size = new System.Drawing.Size(83, 24);
         this.level.TabIndex = 6;
         this.level.Text = "Level: 1";
         // 
         // settingGroupBox
         // 
         this.settingGroupBox.BackColor = System.Drawing.Color.Transparent;
         this.settingGroupBox.Controls.Add(this.speedLabel);
         this.settingGroupBox.Controls.Add(this.increaseCheckbox);
         this.settingGroupBox.Controls.Add(this.constantCheckbox);
         this.settingGroupBox.Controls.Add(this.cityLabel);
         this.settingGroupBox.Controls.Add(this.cityComboBox);
         this.settingGroupBox.Controls.Add(this.missileLabel);
         this.settingGroupBox.Controls.Add(this.numMissileComboBox);
         this.settingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.settingGroupBox.ForeColor = System.Drawing.Color.White;
         this.settingGroupBox.Location = new System.Drawing.Point(675, 375);
         this.settingGroupBox.Name = "settingGroupBox";
         this.settingGroupBox.Size = new System.Drawing.Size(275, 275);
         this.settingGroupBox.TabIndex = 7;
         this.settingGroupBox.TabStop = false;
         this.settingGroupBox.Text = "Game Settings";
         // 
         // speedLabel
         // 
         this.speedLabel.AutoSize = true;
         this.speedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.speedLabel.Location = new System.Drawing.Point(31, 187);
         this.speedLabel.Name = "speedLabel";
         this.speedLabel.Size = new System.Drawing.Size(112, 18);
         this.speedLabel.TabIndex = 6;
         this.speedLabel.Text = "Speed of Game";
         // 
         // increaseCheckbox
         // 
         this.increaseCheckbox.AutoSize = true;
         this.increaseCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.increaseCheckbox.Location = new System.Drawing.Point(51, 232);
         this.increaseCheckbox.Name = "increaseCheckbox";
         this.increaseCheckbox.Size = new System.Drawing.Size(89, 20);
         this.increaseCheckbox.TabIndex = 5;
         this.increaseCheckbox.Text = "Increasing";
         this.increaseCheckbox.UseVisualStyleBackColor = true;
         this.increaseCheckbox.Click += new System.EventHandler(this.increaseLabel_Click);
         // 
         // constantCheckbox
         // 
         this.constantCheckbox.AutoSize = true;
         this.constantCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.constantCheckbox.Location = new System.Drawing.Point(51, 206);
         this.constantCheckbox.Name = "constantCheckbox";
         this.constantCheckbox.Size = new System.Drawing.Size(79, 20);
         this.constantCheckbox.TabIndex = 4;
         this.constantCheckbox.Text = "Constant";
         this.constantCheckbox.UseVisualStyleBackColor = true;
         this.constantCheckbox.Click += new System.EventHandler(this.constantCheckbox_Click);
         // 
         // cityLabel
         // 
         this.cityLabel.AutoSize = true;
         this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.cityLabel.Location = new System.Drawing.Point(31, 111);
         this.cityLabel.Name = "cityLabel";
         this.cityLabel.Size = new System.Drawing.Size(119, 18);
         this.cityLabel.TabIndex = 3;
         this.cityLabel.Text = "Number of Cities";
         // 
         // cityComboBox
         // 
         this.cityComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.cityComboBox.FormattingEnabled = true;
         this.cityComboBox.Items.AddRange(new object[] {
            "",
            "2",
            "4",
            "6"});
         this.cityComboBox.Location = new System.Drawing.Point(51, 130);
         this.cityComboBox.Name = "cityComboBox";
         this.cityComboBox.Size = new System.Drawing.Size(172, 28);
         this.cityComboBox.TabIndex = 2;
         // 
         // missileLabel
         // 
         this.missileLabel.AutoSize = true;
         this.missileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.missileLabel.Location = new System.Drawing.Point(31, 38);
         this.missileLabel.Name = "missileLabel";
         this.missileLabel.Size = new System.Drawing.Size(136, 18);
         this.missileLabel.TabIndex = 1;
         this.missileLabel.Text = "Number of Missiles";
         // 
         // numMissileComboBox
         // 
         this.numMissileComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.numMissileComboBox.FormattingEnabled = true;
         this.numMissileComboBox.Items.AddRange(new object[] {
            "",
            "15",
            "30",
            "Unlimited"});
         this.numMissileComboBox.Location = new System.Drawing.Point(51, 57);
         this.numMissileComboBox.Name = "numMissileComboBox";
         this.numMissileComboBox.Size = new System.Drawing.Size(172, 28);
         this.numMissileComboBox.TabIndex = 0;
         // 
         // ammoLabel
         // 
         this.ammoLabel.BackColor = System.Drawing.Color.Transparent;
         this.ammoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ammoLabel.ForeColor = System.Drawing.Color.Black;
         this.ammoLabel.Location = new System.Drawing.Point(348, 607);
         this.ammoLabel.Name = "ammoLabel";
         this.ammoLabel.Size = new System.Drawing.Size(51, 39);
         this.ammoLabel.TabIndex = 8;
         this.ammoLabel.Text = "30";
         this.ammoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // MissileCommand
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackgroundImage = global::MissileCommand.Properties.Resources.background;
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.ClientSize = new System.Drawing.Size(979, 685);
         this.Controls.Add(this.ammoLabel);
         this.Controls.Add(this.settingGroupBox);
         this.Controls.Add(this.level);
         this.Controls.Add(this.hiScore);
         this.Controls.Add(this.score);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.scoreLabel);
         this.Controls.Add(this.playButton);
         this.Controls.Add(this.menuStrip1);
         this.Cursor = System.Windows.Forms.Cursors.Cross;
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MissileCommand";
         this.Text = "Missile Command";
         this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MissileCommand_Click);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.playButton)).EndInit();
         this.settingGroupBox.ResumeLayout(false);
         this.settingGroupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStripMenuItem GameMenu;
      private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.PictureBox playButton;
      private System.Windows.Forms.Label scoreLabel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label score;
      private System.Windows.Forms.Label hiScore;
      private System.Windows.Forms.Label level;
      private System.Windows.Forms.GroupBox settingGroupBox;
      private System.Windows.Forms.ComboBox numMissileComboBox;
      private System.Windows.Forms.Label missileLabel;
      private System.Windows.Forms.Label cityLabel;
      private System.Windows.Forms.ComboBox cityComboBox;
      private System.Windows.Forms.Label speedLabel;
      private System.Windows.Forms.CheckBox increaseCheckbox;
      private System.Windows.Forms.CheckBox constantCheckbox;
      private System.Windows.Forms.Label ammoLabel;
   }
}

