//hung auduong

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace MidtermProject {
   public partial class MainForm : Form {

      //private StatusBar statusBar = new StatusBar();
      private string path = "";
      private string filter = "";
      bool isWatching;
      bool newData;

      private string dataName;
      SQLiteConnection sqlite_conn;
      SQLiteCommand sqlite_cmd;
      SQLiteDataReader sqlite_datareader;
      //private;

      public MainForm() {
         InitializeComponent();
         dataName = "database.db";
         isWatching = false;
         newData = false;
         writeDatabaseButton.Enabled = false;
         clearButton.Enabled = true;
         initDatabase();

      }

      private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
   
         Application.Exit();

      }


      private void fileSystemWatcher1_onRenamed(object sender, RenamedEventArgs e) {
         Event data = new MidtermProject.Event();
         data.EventHappened = (e.ChangeType.ToString());
         data.Extension = Path.GetExtension(e.FullPath).ToString();
         data.Name = Path.GetFileNameWithoutExtension(e.FullPath);
         data.OldName = Path.GetFileNameWithoutExtension(e.OldName);
         data.Time = DateTime.Now.ToString();
         data.Location = e.FullPath;
         clearButton.Enabled = true;
         newData = true;
         updateWatcher(data);
      }

      private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e) {
         Event data = new MidtermProject.Event();
         data.EventHappened = (e.ChangeType.ToString());
         data.Extension = Path.GetExtension(e.FullPath).ToString();
         data.Name = Path.GetFileNameWithoutExtension(e.FullPath);
         data.Time = DateTime.Now.ToString();
         data.Location = e.FullPath;
         updateWatcher(data);
         newData = true;
         clearButton.Enabled = true;

      }

      private void updateWatcher(Event data) {
         eventWatcherGrid.Rows.Add(eventWatcherGrid.RowCount, data.EventHappened, data.Extension,
         data.Name, data.OldName, data.Location, data.Time);
         newData = true;

      }

      private void StopButton2_Click(object sender, EventArgs e) {
         StopButton2.Enabled = false;
         StopButton.Enabled = false;
         StartButton.Enabled = true;
         startButton2.Enabled = true;
         writeDatabaseButton.Enabled = true;
         WriteButton.Enabled = true;
         fileSystemWatcher1.EnableRaisingEvents = false;
         isWatching = false;

      }

      private void startButton2_Click(object sender, EventArgs e) {
         if (directoryTextbox.Text == "") {
            MessageBox.Show("Please Enter a Directory");
         } else {
            //get the configuration properties from the form.
            path = directoryTextbox.Text;
            if (!Directory.Exists(path)) {
               MessageBox.Show("Directory does not exist, please try again!");
               return;
            }
            if (filterBox.Text.ToString() != "") {
               filter = "*" + filterBox.Text.ToString();
            } else {
               filter = "";
            }
            startButton2.Enabled = false;
            StartButton.Enabled = false;
            StopButton2.Enabled = true;
            StopButton.Enabled = true;
            writeDatabaseButton.Enabled = false;

            //Set the properties on the monitor.
            fileSystemWatcher1.Path = path.ToString();
            fileSystemWatcher1.Filter = filter;

            fileSystemWatcher1.IncludeSubdirectories = true;
            fileSystemWatcher1.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
            | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            //Begin monitoring.
            isWatching = true;
            fileSystemWatcher1.EnableRaisingEvents = true;
         }
      }


      private void initDatabase() {
         string dataPath = Application.StartupPath + @"\" + dataName;
         if (!File.Exists(dataPath)) {
            sqlite_conn = new SQLiteConnection("Data Source = " + dataPath + "; Version = 3; New = True; Compress = True;");
         } else {
            sqlite_conn = new SQLiteConnection("Data Source = " + dataPath + "; Version = 3; New = False; Compress = True;");
         }
         // open the connection:
         sqlite_conn.Open();

         // create a new SQL command:
         sqlite_cmd = sqlite_conn.CreateCommand();

         sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS eventDataTable(event TEXT," +
                                    "extension TEXT, name TEXT, oldname TEXT," +
                                    "location TEXT, datetime TEXT);";
         
         // Now lets execute the SQL ;D
         sqlite_cmd.ExecuteNonQuery();
      }

      private void StartButton_Click(object sender, EventArgs e) {
         startButton2_Click(sender, e);
      }

      private void StopButton_Click(object sender, EventArgs e) {
         StopButton2_Click(sender, e);
      }

      private void startToolStripMenuItem_Click(object sender, EventArgs e) {
         startButton2_Click(sender, e);
      }

      private void stopToolStripMenuItem_Click(object sender, EventArgs e) {
         startButton2_Click(sender, e);
      }



      private void writeDatabaseButton_Click(object sender, EventArgs e) {
         sqlite_cmd = new SQLiteCommand("BEGIN", sqlite_conn);
         sqlite_cmd.ExecuteNonQuery();

         string extensionCheck = databaseExtensionBox.Text.ToString();
         foreach (DataGridViewRow row in eventWatcherGrid.Rows) {
            if (row.Cells["Extension"].Value.ToString() == extensionCheck || extensionCheck == "") {
               // Lets insert something into our new table:
               string tempEvent = row.Cells["Event"].Value.ToString();
               string tempExtension = row.Cells["Extension"].Value.ToString();
               string tempName = row.Cells["Name"].Value.ToString();
               string tempOldname = row.Cells["OldName"].Value.ToString();
               string tempLocation = row.Cells["Location"].Value.ToString();
               string tempTime = row.Cells["Time"].Value.ToString();

               sqlite_cmd.CommandText = "INSERT INTO eventDataTable (event, extension, name, oldname, location, datetime)" +
                                          "VALUES (@event, @extension, @name, @oldname, @location, @datetime)";
               sqlite_cmd.Parameters.AddWithValue("@event", tempEvent);
               sqlite_cmd.Parameters.AddWithValue("@extension", tempExtension);
               sqlite_cmd.Parameters.AddWithValue("@name", tempName);
               sqlite_cmd.Parameters.AddWithValue("@oldname", tempOldname);
               sqlite_cmd.Parameters.AddWithValue("@location", tempLocation);
               sqlite_cmd.Parameters.AddWithValue("@datetime", tempTime);

               // And execute this again ;D
               sqlite_cmd.ExecuteNonQuery();
            }
         }
         sqlite_cmd = new SQLiteCommand("END", sqlite_conn);
         sqlite_cmd.ExecuteNonQuery();
         writeDatabaseButton.Enabled = false;
         filterEvents(databaseExtensionBox.Text);
         newData = false;
      }

      private void filterEvents(string text) {
         for(int i = 0; i < eventWatcherGrid.RowCount; i++) {
            if(eventWatcherGrid.Rows[i].Cells["extension"].Value.ToString() == text || text == "") {
               eventWatcherGrid.Rows.RemoveAt(i);
               i--;
            }
         }
            if(eventWatcherGrid.RowCount ==0) {
         }
      }

      private void queryButton_Click(object sender, EventArgs e) {
         if (isWatching) {
            MessageBox.Show("File is still being watch, please stop file watch first");
         } else {
            QueryForm database = new QueryForm(databaseExtensionBox.Text, sqlite_conn, sqlite_cmd);
            database.Show();
         }
      }

      private void clearButton_Click(object sender, EventArgs e) {
         clearButton.Enabled = false;
         string deleteExt = databaseExtensionBox.Text.ToString();
         if(deleteExt == "") {
            eventWatcherGrid.Rows.Clear();
            sqlite_cmd.CommandText = "DELETE FROM eventDataTable";
         }
         sqlite_cmd.ExecuteNonQuery();

      }

      private void WriteButton_Click(object sender, EventArgs e) {
         writeDatabaseButton_Click(sender, e);
         WriteButton.Enabled = false;
      }


   }

}
