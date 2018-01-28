// Hung Auduong
// 1/20/2018
// hw2
// Tester class to test the binary search tree.

public class Tester {

   public static void main(String[] args) {

      int array[] = {8, 3, 10, 1, 6, 14, 4, 7, 13};
      BinarySearchTree bst = new BinarySearchTree();
      for (int i = 0; i < array.length; i++) {
         bst.insert(array[i]);
         System.out.println("Adding: " + array[i] + " to the Binary Search Tree.");
      }
      System.out.println();
      bst.inorderTraversal();
      bst.postorderTraversal();
      bst.delete(new Integer(8));
      System.out.println("\nAfter deleting 8.");
      bst.inorderTraversal();
      bst.postorderTraversal();

      bst.delete(new Integer(10));
      System.out.println("\nAfter deleting 10.");
      bst.inorderTraversal();
      bst.postorderTraversal();

   }

}
