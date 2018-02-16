public class Tester {

   public static void main (String[] args) {
      Object[] inOrderSequence = {9, 5, 1, 7, 2, 12, 8, 4, 3, 11};
      Object[] postOrderSequence = {9, 1, 2, 12, 7, 5, 3, 11, 4, 8};

      BinaryTree mytree = new BinaryTree().buildTree(inOrderSequence, postOrderSequence);

      mytree.inorderTraversal();
      System.out.println();
      mytree.postorderTraversal();
   }


}
