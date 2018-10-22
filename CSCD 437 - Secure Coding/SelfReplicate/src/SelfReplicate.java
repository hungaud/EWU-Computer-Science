// Jake, Matt, Hung
// Self Replicating Program
// 9/25/18
// Team: Low Self Esteem

public class SelfReplicate {

   public static void main (String[] args) {
      char quote = 34, comma = 44;
      String[] sourceCode = {
            "// Jake, Matt, Hung",
            "// Self Replicating Program",
            "// 9/25/18",
            "// Team: Low Self Esteem",
            "",
            "public class SelfReplicate {",
            "",
            "   public static void main (String[] args) {",
            "      char quote = 34, comma = 44;",
            "      String[] sourceCode = {",
            "      };",
            "      printSourceCode(sourceCode, quote, comma);",
            "   }",
            "",
            "   public static void printSourceCode(String[] sourceCode, char quote, char comma) {",
            "      for(int i = 0; i < 10; i++) {",
            "         System.out.println(sourceCode[i]);",
            "      }",
            "      for(int i = 0; i <sourceCode.length; i++) {",
            "         String array = sourceCode[sourceCode.length - 1] + quote + sourceCode[i] + quote + comma;",
            "         System.out.println(array);",
            "      }",
            "      for(int i = 10; i < sourceCode.length - 1; i++) {",
            "         System.out.println(sourceCode[i]);",
            "      }",
            "   }",
            "}",
            "            ",
      };
      printSourceCode(sourceCode, quote, comma);
   }

   public static void printSourceCode(String[] sourceCode, char quote, char comma) {
      for(int i = 0; i < 10; i++) {
         System.out.println(sourceCode[i]);
      }
      for(int i = 0; i <sourceCode.length; i++) {
         String array = sourceCode[sourceCode.length - 1] + quote + sourceCode[i] + quote + comma;
         System.out.println(array);
      }
      for(int i = 10; i < sourceCode.length - 1; i++) {
         System.out.println(sourceCode[i]);
      }
   }
}