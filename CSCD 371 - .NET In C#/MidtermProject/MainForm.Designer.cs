using System;
using System.IO;

namespace MidtermProject {
   partial class MainForm {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.file = new System.Windows.Forms.ToolStripMenuItem();
         this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.fileSW = new System.Windows.Forms.ToolStripMenuItem();
         this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.shortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.StartButton = new System.Windows.Forms.ToolStripButton();
         this.StopButton = new System.Windows.Forms.ToolStripButton();
         this.WriteButton = new System.Windows.Forms.ToolStripButton();
         this.instructionLabel = new System.Windows.Forms.Label();
         this.filterBox = new System.Windows.Forms.ComboBox();
         this.extensionLabel = new System.Windows.Forms.Label();
         this.directoryLabel = new System.Windows.Forms.Label();
         this.directoryTextbox = new System.Windows.Forms.TextBox();
         this.startButton2 = new System.Windows.Forms.Button();
         this.StopButton2 = new System.Windows.Forms.Button();
         this.queryLabel = new System.Windows.Forms.Label();
         this.databaseExtensionBox = new System.Windows.Forms.ComboBox();
         this.writeDatabaseButton = new System.Windows.Forms.Button();
         this.clearButton = new System.Windows.Forms.Button();
         this.queryButton = new System.Windows.Forms.Button();
         this.eventLabel = new System.Windows.Forms.Label();
         this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
         this.eventWatcherGrid = new System.Windows.Forms.DataGridView();
         this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.menuStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.eventWatcherGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.fileSW,
            this.databaseToolStripMenuItem,
            this.aboutToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(472, 24);
         this.menuStrip1.TabIndex = 0;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // file
         // 
         this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.closeToolStripMenuItem});
         this.file.Name = "file";
         this.file.Size = new System.Drawing.Size(37, 20);
         this.file.Text = "File";
         // 
         // closeToolStripMenuItem
         // 
         this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
         this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.closeToolStripMenuItem.Text = "Close";
         this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
         // 
         // fileSW
         // 
         this.fileSW.Name = "fileSW";
         this.fileSW.Size = new System.Drawing.Size(125, 20);
         this.fileSW.Text = "File System Watcher";
         // 
         // databaseToolStripMenuItem
         // 
         this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
         this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
         this.databaseToolStripMenuItem.Text = "Database";
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shortcutsToolStripMenuItem,
            this.aboutToolStripMenuItem1});
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.aboutToolStripMenuItem.Text = "Help";
         // 
         // shortcutsToolStripMenuItem
         // 
         this.shortcutsToolStripMenuItem.Name = "shortcutsToolStripMenuItem";
         this.shortcutsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
         this.shortcutsToolStripMenuItem.Text = "Shortcuts";
         // 
         // aboutToolStripMenuItem1
         // 
         this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
         this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
         this.aboutToolStripMenuItem1.Text = "About";
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartButton,
            this.StopButton,
            this.WriteButton});
         this.toolStrip1.Location = new System.Drawing.Point(0, 24);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(472, 25);
         this.toolStrip1.TabIndex = 1;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // StartButton
         // 
         this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.StartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.StartButton.Image = global::MidtermProject.Properties.Resources.Play;
         this.StartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.StartButton.Name = "StartButton";
         this.StartButton.Size = new System.Drawing.Size(23, 22);
         this.StartButton.Text = "Start Watch";
         this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
         // 
         // StopButton
         // 
         this.StopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.StopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.StopButton.Image = global::MidtermProject.Properties.Resources.stop_145678_960_720;
         this.StopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.StopButton.Name = "StopButton";
         this.StopButton.Size = new System.Drawing.Size(23, 22);
         this.StopButton.Text = "Stop Watch";
         this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
         // 
         // WriteButton
         // 
         this.WriteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.WriteButton.Image = ((System.Drawing.Image)(resources.GetObject("WriteButton.Image")));
         this.WriteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.WriteButton.Name = "WriteButton";
         this.WriteButton.Size = new System.Drawing.Size(23, 22);
         this.WriteButton.Text = "Write to Database";
         this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
         // 
         // instructionLabel
         // 
         this.instructionLabel.AutoSize = true;
         this.instructionLabel.Location = new System.Drawing.Point(45, 50);
         this.instructionLabel.Name = "instructionLabel";
         this.instructionLabel.Size = new System.Drawing.Size(374, 13);
         this.instructionLabel.TabIndex = 2;
         this.instructionLabel.Text = "Select a file extension, a directory, and click Start to begin File System Monite" +
    "r";
         // 
         // filterBox
         // 
         this.filterBox.FormattingEnabled = true;
         this.filterBox.Items.AddRange(new object[] {
            ".txt",
            ".pdf",
            ".doc",
            ".gif",
            ".png",
            ".jpeg",
            ".mp3"});
         this.filterBox.Location = new System.Drawing.Point(48, 88);
         this.filterBox.Name = "filterBox";
         this.filterBox.Size = new System.Drawing.Size(121, 21);
         this.filterBox.TabIndex = 3;
         // 
         // extensionLabel
         // 
         this.extensionLabel.AutoSize = true;
         this.extensionLabel.Location = new System.Drawing.Point(45, 72);
         this.extensionLabel.Name = "extensionLabel";
         this.extensionLabel.Size = new System.Drawing.Size(104, 13);
         this.extensionLabel.TabIndex = 4;
         this.extensionLabel.Text = "Moniter by extension";
         // 
         // directoryLabel
         // 
         this.directoryLabel.AutoSize = true;
         this.directoryLabel.Location = new System.Drawing.Point(211, 72);
         this.directoryLabel.Name = "directoryLabel";
         this.directoryLabel.Size = new System.Drawing.Size(98, 13);
         this.directoryLabel.TabIndex = 6;
         this.directoryLabel.Text = "Directory to moniter";
         // 
         // directoryTextbox
         // 
         this.directoryTextbox.Location = new System.Drawing.Point(214, 88);
         this.directoryTextbox.Name = "directoryTextbox";
         this.directoryTextbox.Size = new System.Drawing.Size(205, 20);
         this.directoryTextbox.TabIndex = 7;
         // 
         // startButton2
         // 
         this.startButton2.Location = new System.Drawing.Point(214, 115);
         this.startButton2.Name = "startButton2";
         this.startButton2.Size = new System.Drawing.Size(95, 23);
         this.startButton2.TabIndex = 8;
         this.startButton2.Text = "Start";
         this.startButton2.UseVisualStyleBackColor = true;
         this.startButton2.Click += new System.EventHandler(this.startButton2_Click);
         // 
         // StopButton2
         // 
         this.StopButton2.Location = new System.Drawing.Point(324, 115);
         this.StopButton2.Name = "StopButton2";
         this.StopButton2.Size = new System.Drawing.Size(95, 23);
         this.StopButton2.TabIndex = 9;
         this.StopButton2.Text = "Stop";
         this.StopButton2.UseVisualStyleBackColor = true;
         this.StopButton2.Click += new System.EventHandler(this.StopButton2_Click);
         // 
         // queryLabel
         // 
         this.queryLabel.AutoSize = true;
         this.queryLabel.Location = new System.Drawing.Point(45, 160);
         this.queryLabel.Name = "queryLabel";
         this.queryLabel.Size = new System.Drawing.Size(210, 13);
         this.queryLabel.TabIndex = 10;
         this.queryLabel.Text = "Query or Write by Extension (blank for ALL)";
         // 
         // databaseExtensionBox
         // 
         this.databaseExtensionBox.FormattingEnabled = true;
         this.databaseExtensionBox.Items.AddRange(new object[] {
            ".txt",
            ".pdf",
            ".doc",
            ".gif",
            ".png",
            ".jpeg",
            ".mp3"});
         this.databaseExtensionBox.Location = new System.Drawing.Point(48, 177);
         this.databaseExtensionBox.Name = "databaseExtensionBox";
         this.databaseExtensionBox.Size = new System.Drawing.Size(121, 21);
         this.databaseExtensionBox.TabIndex = 12;
         // 
         // writeDatabaseButton
         // 
         this.writeDatabaseButton.Location = new System.Drawing.Point(215, 177);
         this.writeDatabaseButton.Name = "writeDatabaseButton";
         this.writeDatabaseButton.Size = new System.Drawing.Size(101, 23);
         this.writeDatabaseButton.TabIndex = 14;
         this.writeDatabaseButton.Text = "Write to database";
         this.writeDatabaseButton.UseVisualStyleBackColor = true;
         this.writeDatabaseButton.Click += new System.EventHandler(this.writeDatabaseButton_Click);
         // 
         // clearButton
         // 
         this.clearButton.Location = new System.Drawing.Point(376, 177);
         this.clearButton.Name = "clearButton";
         this.clearButton.Size = new System.Drawing.Size(43, 23);
         this.clearButton.TabIndex = 15;
         this.clearButton.Text = "Clear";
         this.clearButton.UseVisualStyleBackColor = true;
         this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
         // 
         // queryButton
         // 
         this.queryButton.Location = new System.Drawing.Point(322, 177);
         this.queryButton.Name = "queryButton";
         this.queryButton.Size = new System.Drawing.Size(48, 23);
         this.queryButton.TabIndex = 16;
         this.queryButton.Text = "Query";
         this.queryButton.UseVisualStyleBackColor = true;
         this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
         // 
         // eventLabel
         // 
         this.eventLabel.AutoSize = true;
         this.eventLabel.Location = new System.Drawing.Point(45, 217);
         this.eventLabel.Name = "eventLabel";
         this.eventLabel.Size = new System.Drawing.Size(140, 13);
         this.eventLabel.TabIndex = 17;
         this.eventLabel.Text = "File System Watcher Events";
         // 
         // fileSystemWatcher1
         // 
         this.fileSystemWatcher1.EnableRaisingEvents = true;
         this.fileSystemWatcher1.SynchronizingObject = this;
         this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
         this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
         this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
         this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_onRenamed);
         // 
         // eventWatcherGrid
         // 
         this.eventWatcherGrid.AllowUserToAddRows = false;
         this.eventWatcherGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.eventWatcherGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.Event,
            this.Extension,
            this.Name,
            this.OldName,
            this.location,
            this.Time});
         this.eventWatcherGrid.Location = new System.Drawing.Point(48, 233);
         this.eventWatcherGrid.Name = "eventWatcherGrid";
         this.eventWatcherGrid.ReadOnly = true;
         this.eventWatcherGrid.Size = new System.Drawing.Size(371, 181);
         this.eventWatcherGrid.TabIndex = 18;
         // 
         // Row
         // 
         this.Row.HeaderText = "Row";
         this.Row.Name = "Row";
         this.Row.ReadOnly = true;
         // 
         // Event
         // 
         this.Event.HeaderText = "Event";
         this.Event.Name = "Event";
         this.Event.ReadOnly = true;
         // 
         // Extension
         // 
         this.Extension.HeaderText = "Extension";
         this.Extension.Name = "Extension";
         this.Extension.ReadOnly = true;
         // 
         // Name
         // 
         this.Name.HeaderText = "Name";
         this.Name.Name = "Name";
         this.Name.ReadOnly = true;
         // 
         // OldName
         // 
         this.OldName.HeaderText = "OldName";
         this.OldName.Name = "OldName";
         this.OldName.ReadOnly = true;
         // 
         // location
         // 
         this.location.HeaderText = "Location";
         this.location.Name = "location";
         this.location.ReadOnly = true;
         // 
         // Time
         // 
         this.Time.HeaderText = "Time";
         this.Time.Name = "Time";
         this.Time.ReadOnly = true;
         // 
         // startToolStripMenuItem
         // 
         this.startToolStripMenuItem.Name = "startToolStripMenuItem";
         this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.startToolStripMenuItem.Text = "Start";
         this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
         // 
         // stopToolStripMenuItem
         // 
         this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
         this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.stopToolStripMenuItem.Text = "Stop";
         this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(472, 425);
         this.Controls.Add(this.eventWatcherGrid);
         this.Controls.Add(this.eventLabel);
         this.Controls.Add(this.queryButton);
         this.Controls.Add(this.clearButton);
         this.Controls.Add(this.writeDatabaseButton);
         this.Controls.Add(this.databaseExtensionBox);
         this.Controls.Add(this.queryLabel);
         this.Controls.Add(this.StopButton2);
         this.Controls.Add(this.startButton2);
         this.Controls.Add(this.directoryTextbox);
         this.Controls.Add(this.directoryLabel);
         this.Controls.Add(this.extensionLabel);
         this.Controls.Add(this.filterBox);
         this.Controls.Add(this.instructionLabel);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.menuStrip1);
         this.MainMenuStrip = this.menuStrip1;
         this.Text = "File System Watcher";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.eventWatcherGrid)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem file;
      private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem fileSW;
      private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem shortcutsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;


      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton StartButton;
      private System.Windows.Forms.ToolStripButton StopButton;
      private System.Windows.Forms.ToolStripButton WriteButton;

      private System.Windows.Forms.Label instructionLabel;
      private System.Windows.Forms.ComboBox filterBox;
      private System.Windows.Forms.Label extensionLabel;
      private System.Windows.Forms.Label directoryLabel;
      private System.Windows.Forms.TextBox directoryTextbox;
      private System.Windows.Forms.Button startButton2;
      private System.Windows.Forms.Button StopButton2;


      private System.Windows.Forms.Label queryLabel;
      private System.Windows.Forms.ComboBox databaseExtensionBox;
      private System.Windows.Forms.Button writeDatabaseButton;
      private System.Windows.Forms.Button clearButton;
      private System.Windows.Forms.Button queryButton;

      private System.Windows.Forms.Label eventLabel;
      private System.IO.FileSystemWatcher fileSystemWatcher1;
      private System.Windows.Forms.DataGridView eventWatcherGrid;
      private System.Windows.Forms.DataGridViewTextBoxColumn Row;
      private System.Windows.Forms.DataGridViewTextBoxColumn Event;
      private System.Windows.Forms.DataGridViewTextBoxColumn Extension;
      private System.Windows.Forms.DataGridViewTextBoxColumn Name;
      private System.Windows.Forms.DataGridViewTextBoxColumn OldName;
      private System.Windows.Forms.DataGridViewTextBoxColumn location;
      private System.Windows.Forms.DataGridViewTextBoxColumn Time;
      private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
   }
}

