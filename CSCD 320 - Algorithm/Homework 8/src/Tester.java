// Hung Auduong
// Dijkstras shortest path algorithm. with DFS in tester for class work.


import java.util.ArrayList;


public class Tester {

   public static void main(String args[]) {
      Graph g = new Graph(9);
      addEdges(g);
      System.out.println("dfs first then dijkstras");
      g.dfsGraph(6);
      System.out.println();

      //g.edgeListTraversal();
      ArrayList<Path> paths = new ArrayList<>();
      for(int i = 0; i < 8; i++) {
         paths.add(g.shortestPath(1, i + 1));
      }
      System.out.println("I based my design on using few data structures including");
      System.out.println("Hashset, Hashmaps, etc. it's not Priority queue/ treemap but i was");
      System.out.println("Hoping if it still counted since difference between TreeMap and Hashmaps");
      System.out.println("were the orders of the key? \n");
      printPath(paths);
   }

   public static void printPath(ArrayList<Path> paths) {
      for(int i = 0; i < paths.size(); i++) {
         System.out.print("Path " + (i + 1) + "): Vertext 1 to Vertex " + (i + 1) + ", ");
         System.out.print(paths.get(i).toString() + ", length ");
         System.out.println(paths.get(i).getCost() + "");
      }
   }

   public static void addEdges(Graph g) {
      g.addEdge(1, 2, 9);
      g.addEdge(1, 6, 14);
      g.addEdge(1, 7, 15);
      g.addEdge(2, 3, 24);
      g.addEdge(3, 5, 2);
      g.addEdge(3, 8, 19);
      g.addEdge(4, 3, 6);
      g.addEdge(4, 8, 6);
      g.addEdge(5, 4, 11);
      g.addEdge(5, 8, 16);
      g.addEdge(6, 5, 30);
      g.addEdge(6, 7, 5);
      g.addEdge(6, 3, 18);
      g.addEdge(7, 5, 20);
      g.addEdge(7, 8, 44);


   }

}
