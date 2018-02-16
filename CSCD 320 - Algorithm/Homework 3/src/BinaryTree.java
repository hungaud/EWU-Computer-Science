public class BinaryTree {

   private Node root;
   private int postIndex;

   // post: private Node class for each elements in the BST
   private class Node {
      Node l;
      Node r;
      Object data;

      Node(Object data) {
         this.data = data;
         l = null;
         r = null;
      }
   }

   public BinaryTree() {
      root = null;
   }

   public BinaryTree buildTree(Object inOrderSequence[], Object postOrderSequence[]) {
      int size = postOrderSequence.length;
      postIndex = size - 1;
      root = buildTree(inOrderSequence, postOrderSequence, 0, size - 1);
      return this;
   }

   private Node buildTree(Object inOrder[], Object postOrder[], int start, int end) {
      if(start > end) {
         return null;
      }
      Node node = new Node(postOrder[postIndex]);
      postIndex--;
      if(start == end) {
         return node;
      }
      int index = search(inOrder, start, end, node.data);
      node.r = buildTree(inOrder, postOrder, index + 1, end);
      node.l = buildTree(inOrder, postOrder, start, index - 1);

      return node;
   }


   private int search(Object in[], int start, int end, Object data) {
      for(int i = start; i <= end; i++) {
         if(in[i].equals(data)) {
            return i;
         }
      }
      return -1;
   }

   // post: traverse the tree in order.
   public void inorderTraversal() {
      printTreeInorder(root);
      System.out.println();
   }

   // post: private helper method that prints the data in a
   private void printTreeInorder(Node node) {
      if (node == null)
         return;
      printTreeInorder(node.l);
      System.out.print(node.data + " ");
      printTreeInorder(node.r);
   }

   // post: traverse the tree in a post order
   public void postorderTraversal() {
      printTreePostorder(root);
      System.out.println();
   }

   // post: helper method that traverse the tree post order
   private void printTreePostorder(Node node) {
      if (node == null)
         return;
      printTreePostorder(node.l);
      printTreePostorder(node.r);
      System.out.print(node.data + " ");
   }

}
