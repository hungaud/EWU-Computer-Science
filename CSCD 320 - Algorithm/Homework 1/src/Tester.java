// Hung Auduong
// 1/10/2018
// Professor Tony
// CSCD 320 Algorithm
//
// This is a simple Tester program that searches a sorted input array. It finds the element X such that X is greater than
// or equal to the value thats to be searched. If its not in the array, then it'll take the closest element X that
// is greater than the value.


public class Tester {

   public static void main(String args[]) {
      int array[] = {1,  3,  5,  7,  9, 14, 15, 16, 17, 19};
      //int array[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
      int index;
      System.out.println("Using an input array A = [ 1,  3,  5,  7,  9, 14, 16, 19 ]");

      index = quickSearch(array, 8);
      System.out.println("performing quickSearch(A, 8), it return " + index + ", the index of number " + array[index] + ".");
      index = quickSearch(array, 19);
      System.out.println("performing quickSearch(A, 19), it return " + index + ", the index of number " + array[index] + ".");
      index = quickSearch(array, 20);
      System.out.println("performing quickSearch(A, 20), it return  " + index + ", indicating there is no such value that is bigger than or equal to 20 in array A.");
      index = quickSearch(array, 6);
      System.out.println("performing quickSearch(A, 6), it return " + index + ", the index of number " + array[index] + ".");
      index = quickSearch(array, -1);
      System.out.println("performing quickSearch(A, -1), it return " + index + ", the index of number " + array[index] + ".");
      index = quickSearch(array, 1);
      System.out.println("performing quickSearch(A, 1), it return " + index + ", the index of number " + array[index] + ".");


   }

   // post: checks the edge cases before starting the binary search. if the value is greater than the max value
   //       in the array, it'll return -1.
   //       but if the value is less than the 0th index value, then it returns the 0th index
   public static int quickSearch(int array[], int value) {
      if(value > array[array.length -1]) {
         return -1;
      } else if (value <= array[0]) {
         return 0;
      }
      return binarySearch(array, value, array.length, array.length /2);
   }

   // post: recursively search the array O(log n) runtime. Base case if it finds the value or the closest value
   //       thats greater than the value being searched.
   //       starting from the middle of the array. if the value < mid
   //       it'll search the lower half of the array. if value > mid. itll search the higher half of the array
   //       as the new "array" creating a new midpoint each time.
   private static int binarySearch(int array[], int value, int max, int index) {
      if(value > array[index] && value <= array[index + 1]) {
         return index + 1;
      }
      if(value == array[index]) {
         return index;
      } else {
         if (value > array[index]) {
            return binarySearch(array, value, max, (index + max) / 2);
         } else {
            return binarySearch(array, value, index, index - (max - index)/2 );
         }
      }
   }
}