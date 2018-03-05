/*****************************
 Query the Crime Database
 *****************************/
import java.io.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.CallableStatement;
import java.util.Date;
import java.lang.String;

public class MyQuery {

   private Connection conn = null;
   private Statement statement = null;
   private ResultSet resultSet = null;

   public MyQuery(Connection c)throws SQLException {
      conn = c;
      statement = conn.createStatement();
   }

   //Query 0: this is a sample query provided by Dr. Li
   public void findChargeDate() throws SQLException {
      String query  = "SELECT crime_id, date_charged " +
            "FROM crimes " +
            "WHERE date_charged <= \'2008-10-22\';";

      resultSet = statement.executeQuery(query);
   }

   public void printChargeDate() throws IOException, SQLException {
      System.out.println("******** Query 0 ********");
      System.out.println("Crime_ID\t"+"Charge_Date");

      while (resultSet.next()) {
         // It is possible to get the columns via name
         // also possible to get the columns via the column number
         // which starts at 1
         // e.g. resultSet.getString(2);
         int crime_id = resultSet.getInt(1);
         Date charge_date = resultSet.getDate("date_charged");
         System.out.println(crime_id+"\t\t"+charge_date);
      }
      System.out.println();
   }

   //Query 1
   public void findBestOfficer() throws SQLException {
      String query = "SELECT first, last, COUNT(officer_id) cnt \n" +
                     "FROM officers NATURAL JOIN crime_officers \n" +
                     "GROUP BY officer_id \n" +
                     "HAVING cnt > (SELECT COUNT(crime_id) / COUNT(DISTINCT officer_id) \n" +
                                    "FROM crime_officers) \n";
      resultSet = statement.executeQuery(query);
   }

   public void printBestOfficer() throws IOException, SQLException {
      System.out.println("******** Query 1 ********");
      System.out.println("First \t Last \t count \t");
      while(resultSet.next()) {
         String first = resultSet.getString("First");
         String last = resultSet.getString("Last");
         int count = resultSet.getInt("cnt");
         System.out.println(first + "\t " + last + " \t " + count);
      }
      System.out.println();
   }


   //Query 2
   public void findCrimeCharge() throws SQLException {
      String query = "SELECT charge_id \n" +
                     "FROM crime_charges \n" +
                     "WHERE fine_amount > (SELECT AVG(fine_amount) FROM crime_charges) AND \n" +
                           "amount_paid < (SELECT AVG(amount_paid) FROM crime_charges) \n";
      resultSet = statement.executeQuery(query);
   }

   public void printCrimeCharge() throws IOException, SQLException {
      System.out.println("******** Query 2 ********");
      System.out.println("charge_id");
      while(resultSet.next()) {
         int id = resultSet.getInt("charge_id");
         System.out.println(id);
      }
      System.out.println();
   }


   //Query 3
   public void findCriminal() throws SQLException {
      String query = "SELECT distinct first, last \n" +
                     "FROM criminals NATURAL JOIN crimes NATURAL JOIN crime_charges \n" +
                     "WHERE crime_code in (SELECT crime_code \n" +
                                          "FROM crime_charges \n" +
                                          "WHERE crime_id = 10089) ";
      resultSet = statement.executeQuery(query);
   }

   public void printCriminal() throws IOException, SQLException {
      System.out.println("******** Query 3 ********");
      System.out.println("first \t last");
      while(resultSet.next()) {
         String first = resultSet.getString("first");
         String last = resultSet.getString("last");
         System.out.println(first + " \t " + last);
      }
      System.out.println();
   }


   //Query 4
   public void findCriminalSentence() throws SQLException {
      String query = "SELECT criminal_id, last, first, COUNT(crime_id) cnt_sentence \n" +
                     "FROM criminals NATURAL JOIN crimes \n" +
                     "GROUP BY criminal_id \n" +
                     "HAVING cnt_sentence > 1";
      resultSet = statement.executeQuery(query);
   }

   public void printCriminalSentence() throws IOException, SQLException {
      System.out.println("******** Query 4 ********");
      System.out.println("criminal_id \t last \t\t first \t\t cnt_sentence");
      while(resultSet.next()) {
         int criminal_id = resultSet.getInt("criminal_id");
         String last = resultSet.getString("last");
         String first = resultSet.getString("first");
         int count = resultSet.getInt("cnt_sentence");
         System.out.println(criminal_id + " \t\t\t " + last + " \t " + first + " \t\t " + count);
      }
      System.out.println();
   }


   //Query 5
   public void findChargeCount() throws SQLException {
      String query = "SELECT precinct, COUNT(precinct) charge_cnt \n" +
                     "FROM officers NATURAL JOIN crime_officers NATURAL JOIN crime_charges \n" +
                     "WHERE charge_status = 'GL' \n" +
                     "GROUP BY precinct \n" +
                     "HAVING charge_cnt >= 7 \n";
      resultSet = statement.executeQuery(query);
   }

   public void printChargeCount() throws IOException, SQLException {
      System.out.println("******** Query 5 ********");
      System.out.println("precinct \t count \t");
      while(resultSet.next()) {
         String precinct = resultSet.getString("precinct");
         int count = resultSet.getInt("charge_cnt");
         System.out.println(precinct + " \t\t " + count);
      }
      System.out.println();
   }


   //Query 6
   public void findEarliestLatest() throws SQLException {
      String query = "SELECT criminal_id id, first, last, " +
                     "min(start_date) 'start date', max(end_date) 'end date' \n" +
                     "FROM criminals NATURAL JOIN sentences \n" +
                     "GROUP BY id \n";
      resultSet = statement.executeQuery(query);
   }

   public void printEarliestLatest() throws IOException, SQLException {
      System.out.println("******** Query 6 ********");
      System.out.println("id \t\t first \t\t last \t\t\t earliest start date \t latest end date");
      while(resultSet.next()) {
         int id = resultSet.getInt("id");
         String first = resultSet.getString("first");
         String last = resultSet.getString("last");
         String start = resultSet.getString("start date");
         String end = resultSet.getString("end date");
         System.out.println(id + " \t " + first + " \t\t " + last+ "\t\t\t " + start+ " \t\t\t " + end);
      }
      System.out.println();
   }


   //Query 7
  /*
   public void findCrimeCounts() throws SQLException
   {
      System.out.println("******** Query 7 ********");
      InputStreamReader istream = new InputStreamReader(System.in) ;
      BufferedReader bufRead = new BufferedReader(istream) ;

      try{
         System.out.println("Please enter the officer_id for the query: ");
         //fill in this portion

         System.out.println("Officer " +id+" has reported "+cnt+" crimes.");
      }
      catch (IOException err) {
         System.out.println("Error reading line");
      }
   }
   */
}


