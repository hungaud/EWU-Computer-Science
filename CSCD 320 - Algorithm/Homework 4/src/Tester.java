import java.util.LinkedList;

public class Tester {

   public static void main(String[] args) {
      Trie2 myTrie = new Trie2();
      String[] words = {"apple", "bike", "bake", "pen", "did", "ape",
                        "child", "cat", "file", "hello", "he", "hell"};
      for(int i = 0; i < words.length; i++) {
         myTrie.insertString(words[i]);
      }

      LinkedList<String> result = myTrie.wordsPrefixedBy("ap");
      for(Object s : result.toArray()) {
         System.out.println(s.toString());
      }


      result = myTrie.wordsPrefixedBy("he");
      for(Object s : result.toArray()) {
         System.out.println(s.toString());
      }


   }

}
