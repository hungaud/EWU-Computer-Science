// Hung Auduong
// 1/20/2018
// Homework 2
//
// This program implements a binary search tree. This includes building, traversing and deleting elements within
// the binary search tree.

import java.util.*;

public class BinarySearchTree {

   private Node root;

   // post: private Node class for each elements in the BST
   private class Node {
      Node l;
      Node r;
      Comparable data;

      Node(Comparable data) {
         this.data = data;
         l = null;
         r = null;
      }
   }

   // post: Constructor to initialize the BST.
   public BinarySearchTree() {
      root = null;
   }

   // post: inserts a new object into the binary search tree
   public void insert(Comparable n) {
      root = inserting(root, n);
   }

   // post: private helper method that traverses through the BST and finds the correct location where the node
   //       will be inserted. then it returns the node location.
   private Node inserting(Node root, Comparable n) {
      if (root == null) {
         Node newNode = new Node(n);
         return newNode;
      } else {
         if (n.compareTo(root.data) < 0) {
            root.l = inserting(root.l, n);
         } else {
            root.r = inserting(root.r, n);
         }
      }
      return root;
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

   // post: checks to see if the element is in the tree, if so it'll delete the node and returns true
   //       otherwise return false since the deletion didnt happen
   public boolean delete(Comparable toRemove) {
      if (contains(toRemove)) {
         root = remove(toRemove, root);
         return true;
      } else {
         return false;
      }
   }

   // post: helper method that traverse through the tree to delete the node
   private Node remove(Comparable toRemove, Node root) {
      if (root == null) {
         return root;
      }
      if (toRemove.compareTo(root.data) < 0) {
         root.l = remove(toRemove, root.l);
      } else if( toRemove.compareTo(root.data) > 0 ) {
         root.r = remove(toRemove, root.r);
      } else {
         if (root.r == null) {
            return root.l;
         }
         if (root.l == null) {
            return root.r;
         }
         Node temp = root;
         root = max(temp.l);
         root.l = removeMax(temp.l);
         root.r = temp.r;
      }
      return root;
   }

   // post: finds the max node within the left subtree of the "root"
   private Node max(Node root) {
      if (root.r == null) {
         return root;
      } else
         return max(root.r);
   }

   // post: private helper method that deletes the node and returning a new root.
   private Node removeMax(Node root) {
      if (root.r == null) {
         return root.l;
      } else {
         root.r = removeMax(root.r);
      }
      return root;
   }

   // post: traverse through the tree to see if the node exist.
   public boolean contains(Comparable toRemove) {
      return check(root, toRemove);
   }

   // post: traverse the tree. and returns true or false if it finds the element or not respectively.
   private boolean check(Node root, Comparable toRemove) {
      if (root.data.equals(toRemove)) {
         return true;
      } else if (toRemove.compareTo(root.data) < 0) {
         return check(root.l, toRemove);
      } else if (toRemove.compareTo(root.data) > 0) {
         return check(root.r, toRemove);
      } else {
         return false;
      }
   }

}

/*
You can still do a post order traversal because when the method is called, it traverses through the tree going to the
left node first and going by depth. as long as the original root isnt null, it'll still able to do post order
because after the recursion goes through the right node, and begins to backtrack, it'll start to print the elements.
because the tree isnt null, its able to backtrack and prints the element

*/
