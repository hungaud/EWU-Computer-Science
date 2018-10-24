import java.io.*;
import java.util.*;

public class Regex {

   public static final String[] TITLE = {
         "Social Security", "US Phone Number", "E-Mail Address", "Name on Class Roster",
         "Date in MM-DD-YYYY", "House address", "City, State, Zip", "Military Time",
         "US Currency", "URL", "Password", "Odd Numbers of Characters Ending in \"ion\""
   };
   private static HashSet<String> stateAbbrev;

   public static void main(String args[]) throws FileNotFoundException {
      HashMap<String, ArrayList<String>> input = new HashMap<>();
      stateAbbrev = new HashSet<>();
      initializeInputText(input);
      testFromFile(input);
      promptUserInputs();
   }

   public static void initializeInputText(HashMap<String, ArrayList<String>> input) throws FileNotFoundException {
      File file = new File("test.txt");
      Scanner sc = new Scanner(file);String key = "a";
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
      file = new File("StateAbbreviations.txt");
      sc = new Scanner(file);
      while(sc.hasNextLine()) {
         stateAbbrev.add(sc.nextLine());
      }
   }

   public static void promptUserInputs() {
      HashMap<String, ArrayList<String>> input;
      String option = "", response = "";
      Scanner sc = new Scanner(System.in);
      System.out.println("");
      String prompt ="User Input Test: \na\tSocial Security Number\nb\tUS Phone number\nc\tE-mail address\n" +
            "d\tName on a class roster, assuming one or more middle initials - Last name, First name, MI\n" +
            "e\tDate in MM-DD-YYYY format\n" +
            "f\tHouse address - Street number, street name, abbreviation for road, street, boulevard or avenue" +
            "g\tCity followed by state followed by zip as it should appear on a letter\n" +
            "h\tMilitary time, including seconds\ni\tUS Currency down to the penny (ex: $123,456,789.23)\n" +
            "j\tURL, including http:// (upper and lower case should be accepted)\n" +
            "k\tA password that contains at least 10 characters and includes at least one upper case character, " +
            "lower case character, digit, punctuation mark, and does not have more than " +
            "3 consecutive lower case characters\nl\tAll words containing an odd number of " +
            "alphabetic characters, ending in \"ion\"\nq\tQUIT";
      while(!option.equals("q")) {
         input = new HashMap<>();
         System.out.println(prompt + "\n");
         option = sc.next();
         if(option.equals("q")) break;
         response = sc.next();
         input.put(option, new ArrayList<>());
         input.get(option).add(response);
         mapToTestCase(input, null);
      }
   }

   public static void testFromFile(HashMap<String, ArrayList<String>> input) throws FileNotFoundException {
      PrintStream writer = new PrintStream("result.txt");
      System.out.println("Testing with: \"test.txt\"");
      writer.println("Regular Expressions");
      mapToTestCase(input, writer);
      System.out.println("Finished Testing with: \"test.txt\".\n" +
            "The result should be in \"result.txt\"");
   }

   private static void mapToTestCase(HashMap<String, ArrayList<String>> input, PrintStream writer) {
      ArrayList<String> valid = new ArrayList<>();
      ArrayList<String> failed = new ArrayList<>();
      int index = 0;
      for(String key : input.keySet()) {
         if(writer != null) {
            writer.println("\n" + (index + 1) + ". " + TITLE[index]);
         }
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
         if (writer != null)
            writeResultToFile(valid, failed, writer);
         else
            printResultToConsole(valid, failed);

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
   public static void printResultToConsole(ArrayList<String> valid, ArrayList<String> failed) {
      System.out.println(failed.isEmpty() ? "Valid Response" : "Failed Response");
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
      return s.matches("^((\\d)+\\s[a-zA-Z0-9 ]+(rd|st|blvd|ave|road|street|boulevard|avenue)+.?)$");
   }

   public static boolean isValidCityStateZip(String s) {
      boolean valid = s.matches("^(([a-zA-Z,]+\\s){2}\\d{5}(-\\d{4})?)$");
      String[] cityStateZip = s.split("\\s");
      return valid && stateAbbrev.contains(cityStateZip[1].toUpperCase());
   }

   public static boolean isValidMilitaryTime(String s) {
      boolean valid = s.matches("^([0-2]\\d(:[0-5]\\d){2})$");
      String[] time = s.split(":");
      return valid && Integer.parseInt(time[0]) < 24 ||
            (time[0].equals("24") && time[1].equals("00") && time[2].equals("00"));
   }

   public static boolean isValidUSCurrency(String s) {
      return s.matches("^(\\$\\d{1,3}(,\\d{3})*(.\\d{2}))$");
   }

   public static boolean isValidURL(String s) {
      s = s.toLowerCase();
      return s.matches("^((http://|https://)(www.)?([a-z0-9\\-]+)\\.([a-z0-9/.?=\\-])+)$");
   }

   public static boolean isValidPassword(String s) {
      return s.matches("^((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\\W)(?!.*[a-z]{3,})[\\w\\W]{10,})$");
   }

   public static boolean isValidOddLengthEndingIon(String s) {
      return (s.length() % 2 == 1) && s.matches("^[a-zA-Z]*(ion)$");
   }
}