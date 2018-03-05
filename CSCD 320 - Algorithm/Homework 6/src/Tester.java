public class Tester {

   public static void main(String args[]) {
      Graph g = new Graph(8);
      addEdges(g);
      //g.edgeListTraversal();
      System.out.println("BFS travesal: ");
      g.bfsGraph();
   }

   public static void addEdges(Graph g) {
      g.addEdge(0, 1);
      g.addEdge(1, 0);
      g.addEdge(0, 2);
      g.addEdge(2, 0);
      g.addEdge(0, 3);
      g.addEdge(3, 0);

      g.addEdge(1, 7);
      g.addEdge(7, 1);

      g.addEdge(2, 7);
      g.addEdge(7, 2);
      g.addEdge(2, 5);
      g.addEdge(5, 2);
      g.addEdge(2, 3);
      g.addEdge(3, 2);

      g.addEdge(3, 5);
      g.addEdge(5, 3);
      g.addEdge(3, 4);
      g.addEdge(4, 3);

      g.addEdge(5, 7);
      g.addEdge(7, 5);
      g.addEdge(5, 6);
      g.addEdge(6, 5);
      g.addEdge(5, 4);
      g.addEdge(4, 5);

      g.addEdge(6, 7);
      g.addEdge(7, 6);
      g.addEdge(6, 4);
      g.addEdge(4, 6);
   }

}
