import java.io.*;
import java.util.*;

public class Regex {

   public static final String[] TITLE = {
         "Social Security", "US Phone Number", "E-Mail Address", "Name on Class Roster",
         "Date in MM-DD-YYYY", "House address", "City, State, Zip", "Military Time",
         "US Currency", "URL", "Password", "Odd Numbers of Characters Ending in \"ion\""
   };

   public static void main(String args[]) throws FileNotFoundException {
      File file = new File("test.txt");
      Scanner scan = new Scanner(file);
      PrintStream writer = new PrintStream("result.txt");
      HashMap<String, ArrayList<String>> input = new HashMap<>();
      initializeInputText(scan, input);
      testFromFile(input, writer);
   }

   public static void initializeInputText(Scanner sc, HashMap<String, ArrayList<String>> input) {
      String key = "a";
      while(sc.hasNextLine()) {
         String line = sc.nextLine();
         if(line.length() == 1 && line.matches("[a-l]")) {
            key = line;
            if(!input.containsKey(key))
               input.put(key, new ArrayList<>());
         } else {
            input.get(key).add(line);
         }
      }
   }

   public static void testFromFile(HashMap<String, ArrayList<String>> input, PrintStream writer) {
      System.out.println("Testing with: \"result.txt\"");
      writer.println("Regular Expressions");
      ArrayList<String> valid = new ArrayList<>();
      ArrayList<String> failed = new ArrayList<>();
      int index = 0;
      for(String key : input.keySet()) {
         writer.println("\n" + (index + 1) + ". " + TITLE[index]);
         for(String value : input.get(key)) {
            switch(key) {
               case("a"):
                  (isValidSocialSecurityNumber(value) ? valid : failed).add(value);
                  break;
               case("b"):
                  (isValidPhoneNumber(value) ? valid : failed).add(value);
                  break;
               case("c"):
                  (isValidEmail(value) ? valid : failed).add(value);
                  break;
               case("d"):
                  (isValidRosterName(value) ? valid : failed).add(value);
                  break;
               case("e"):
                  (isValidDate(value) ? valid : failed).add(value);
                  break;
               case("f"):
                  (isValidHouseAddress(value) ? valid : failed).add(value);
                  break;
               case("g"):
                  (isValidCityStateZip(value) ? valid : failed).add(value);
                  break;
               case("h"):
                  (isValidMilitaryTime(value) ? valid : failed).add(value);
                  break;
               case("i"):
                  (isValidUSCurrency(value) ? valid : failed).add(value);
                  break;
               case("j"):
                  (isValidURL(value) ? valid : failed).add(value);
                  break;
               case("k"):
                  (isValidPassword(value) ? valid : failed).add(value);
                  break;
               case("l"):
                  (isValidOddLengthEndingIon(value) ? valid : failed).add(value);
                  break;
            }
         }
         index++;
         writeResultToFile(valid, failed, writer);
         valid.clear();
         failed.clear();
      }
   }

   public static void writeResultToFile(ArrayList<String> valid, ArrayList<String> failed,
                                  PrintStream writer) {
      writer.println("Passed Tests:");
      for(String s : valid) {
         writer.println("\t" + s);
      }
      writer.println("Failed Tests: ");
      for(String s : failed) {
         writer.println("\t" + s);
      }
   }

   public static boolean isValidSocialSecurityNumber(String s) {
      return s.matches("^(\\d{3}-?\\d{2}-?\\d{4})$|^(\\d{3} \\d{2} \\d{4})$");
   }

   public static boolean isValidPhoneNumber(String s) {
      return s.matches("^(\\(\\d{3}\\)-?\\d{3}-?\\d{4})$|^(\\d{3}-?\\d{3}-?\\d{4})$");
   }

   public static boolean isValidEmail(String s) {
      return s.matches("^((?!.*\\.{2,})[a-zA-Z0-9!#$%&'*+/=?^_`{|}~;\\-.]+@[a-zA-Z0-9\\-][.a-z]+)$");
   }

   public static boolean isValidRosterName(String s) {
      return s.matches("^(([a-zA-Z'\\-]+),\\s([a-zA-Z\\-]+)[,]*(\\s[\\w][.]*)*)$");
   }

   public static boolean isValidDate(String s) {
      boolean validFormat = s.matches("^(\\d{2}[/\\-]\\d{2}[/\\-]\\d{4})$");
      if(validFormat) {
         String[] date = s.split("[/\\-]");
         int month = Integer.parseInt(date[0]);
         int day = Integer.parseInt(date[1]);
         int year = Integer.parseInt(date[2]);
         try {
            GregorianCalendar calendar = new GregorianCalendar();
            calendar.setLenient(false);
            calendar.set(year,  month - 1, day);
            calendar.getTime();
            return true;
         } catch(Exception e) {}
      }
      return false;
   }

   public static boolean isValidHouseAddress(String s) {
      return true;
   }

   public static boolean isValidCityStateZip(String s) {
      return true;
   }

   public static boolean isValidMilitaryTime(String s) {
      return true;
   }

   public static boolean isValidUSCurrency(String s) {
      return true;
   }

   public static boolean isValidURL(String s) {
      return true;
   }

   public static boolean isValidPassword(String s) {
      return true;
   }

   public static boolean isValidOddLengthEndingIon(String s) {
      return (s.length() % 2 == 1) && s.matches("^[a-zA-Z]*(ion)$");
   }
}
