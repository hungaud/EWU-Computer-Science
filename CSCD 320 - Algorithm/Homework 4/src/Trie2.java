import java.util.*;

public class Trie2 {

      private class TrieNode {
         Map<Character, TrieNode> children = new TreeMap<>();
         boolean aword = false;
      }

      private TrieNode root;

      public Trie2() {
         this.root = new TrieNode();
      }

      public void insertString(String s) {
         insertString(root, s);
      }

      private void insertString(TrieNode root, String s) {
         TrieNode cur = root;
         for (char ch : s.toCharArray()) {
            TrieNode next = cur.children.get(ch);
            if (next == null)
               cur.children.put(ch, next = new TrieNode());
            cur = next;
         }
         cur.aword = true;
      }

      public LinkedList wordsPrefixedBy(String p) {
         return wordsPrefixedBy(this.root, p);
      }

      private LinkedList wordsPrefixedBy(TrieNode root, String p) {
         char[] chars = p.toCharArray();
         LinkedList<String> result = new LinkedList<>();
         for(int i = 0; i < chars.length; i++) {
            if(!root.children.containsKey(chars[i])){
               return result;
            }
            root = root.children.get(chars[i]);
         }
         String post = "";
         return wordsHelper(root, p, post, new LinkedList<String>());
      }

      private LinkedList wordsHelper(TrieNode root, String pre, String post, LinkedList results) {
         if(root.aword) {
            results.add(pre+post);
         }
         for(char c : root.children.keySet()) {
            wordsHelper(root.children.get(c), pre, post + c, results);
         }
         return results;
      }


      public void printSorted() {
         printSorted(root, "");
      }

      private void printSorted(TrieNode node, String s) {
         if (node.aword) {
            System.out.println(s);
         }
         for (Character ch : node.children.keySet()) {
            printSorted(node.children.get(ch), s + ch);
         }
      }

      public boolean findWord(String s) {
         return findWord(root, s);
      }

      private boolean findWord(TrieNode node, String s) {
         if(s != null) {
            String rest = s.substring(1); //rest is a substring of s, by excluding the first character in s
            char ch = s.charAt(0);        //ch is the first letter of s
            TrieNode child = node.children.get(ch);	//return the child that ch associated with.
            if(s.length() == 1 && child != null) //if s contains only one letter, and current node has a child associated with that letter, we find the prefix in Trie!
               return true;	                 //base case
            if(child == null)
               return false;
            else
               return findWord(child, rest);    //recursive, In this way, we follow the path of the trie from root down towards leaf
         }
         return false;
      }



}
