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
            }
         }
         index++;
         writeResult(valid, failed, writer);
         valid.clear();
         failed.clear();
      }
   }


   public static void writeResult(ArrayList<String> valid, ArrayList<String> failed,
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
      return s.matches("^([a-zA-Z\\-])$");
   }
}
