using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MidtermProject {
   public partial class QueryForm : Form {

      private string extension;
      private SQLiteConnection sqlite_conn;
      private SQLiteCommand sqlite_cmd;
      private SQLiteDataReader sqlite_datareader;

      public QueryForm(string extension, SQLiteConnection conn, SQLiteCommand cmd) {

         sqlite_conn = conn;
         sqlite_cmd = cmd;
         this.extension = extension;
         
         InitializeComponent();
         createGrid();
      }

      private void createGrid() {
         if (extension == "") {
            sqlite_cmd.CommandText = "SELECT * FROM eventDataTable";
         } else {
            sqlite_cmd.CommandText = "SELECT * FROM eventDataTable WHERE extension = @extension";
            sqlite_cmd.Parameters.AddWithValue("extension", extension);
         }
         // Now the SQLiteCommand object can give us a DataReader-Object:
         using (sqlite_datareader = sqlite_cmd.ExecuteReader()) {

            // Read() returns true if there is still a result line to read
            while (sqlite_datareader.Read()) {

               resultGrid.Rows.Add(new object[] {
                                 resultGrid.RowCount,
                                 sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("event")),
                                 sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("extension")),
                                 sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("name")),
                                 sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("oldname")),
                                 sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("location")),
                                 sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("datetime"))
                                 });


            }
         }
         sqlite_datareader.Close();
      }



   }
}
