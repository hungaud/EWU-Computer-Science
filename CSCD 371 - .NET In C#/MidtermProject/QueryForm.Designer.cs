namespace MidtermProject {
   partial class QueryForm {
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
         this.components = new System.ComponentModel.Container();
         this.resultGrid = new System.Windows.Forms.DataGridView();
         this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.eventArgsBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.eventArgsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.eventArgsBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.eventArgsBindingSource1)).BeginInit();
         this.SuspendLayout();
         // 
         // resultGrid
         // 
         this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Event,
            this.Extension,
            this.FileName,
            this.OldName,
            this.Path,
            this.DateTime});
         this.resultGrid.Location = new System.Drawing.Point(15, 12);
         this.resultGrid.Name = "resultGrid";
         this.resultGrid.Size = new System.Drawing.Size(627, 276);
         this.resultGrid.TabIndex = 3;
         // 
         // ID
         // 
         this.ID.HeaderText = "ID";
         this.ID.Name = "ID";
         this.ID.Width = 50;
         // 
         // Event
         // 
         this.Event.HeaderText = "Event";
         this.Event.Name = "Event";
         // 
         // Extension
         // 
         this.Extension.HeaderText = "Extension";
         this.Extension.Name = "Extension";
         // 
         // FileName
         // 
         this.FileName.HeaderText = "Name";
         this.FileName.Name = "FileName";
         // 
         // OldName
         // 
         this.OldName.HeaderText = "OldName";
         this.OldName.Name = "OldName";
         // 
         // Path
         // 
         this.Path.HeaderText = "Location";
         this.Path.Name = "Path";
         this.Path.Width = 200;
         // 
         // DateTime
         // 
         this.DateTime.HeaderText = "DateTime";
         this.DateTime.Name = "DateTime";
         // 
         // eventArgsBindingSource
         // 
         this.eventArgsBindingSource.DataSource = typeof(System.EventArgs);
         // 
         // eventArgsBindingSource1
         // 
         this.eventArgsBindingSource1.DataSource = typeof(System.EventArgs);
         // 
         // QueryForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(654, 298);
         this.Controls.Add(this.resultGrid);
         this.Name = "QueryForm";
         this.Text = "QueryForm";
         ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.eventArgsBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.eventArgsBindingSource1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.DataGridView resultGrid;
      private System.Windows.Forms.BindingSource eventArgsBindingSource;
      private System.Windows.Forms.BindingSource eventArgsBindingSource1;
      private System.Windows.Forms.DataGridViewTextBoxColumn ID;
      private System.Windows.Forms.DataGridViewTextBoxColumn Event;
      private System.Windows.Forms.DataGridViewTextBoxColumn Extension;
      private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
      private System.Windows.Forms.DataGridViewTextBoxColumn OldName;
      private System.Windows.Forms.DataGridViewTextBoxColumn Path;
      private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
   }
}