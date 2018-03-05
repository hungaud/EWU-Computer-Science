import java.util.*;

/**
 * Created by HungA on 2/23/2018.
 */
public class Graph {
   private LinkedList<Integer>[] adjacentList;
   private int numEdge;
   private Set<Integer> vistedVertex;
   private List<Edge> edgeList;

   public Graph(int n) {
      vistedVertex = new HashSet<Integer>();
      adjacentList = new LinkedList[n];
      numEdge = 0;
      edgeList = new ArrayList<>();

   }

   public int vistedSize() {
      return vistedVertex.size();
   }

   public int getNumEdge() {
      return numEdge;
   }

   public void addEdge(int v1, int v2) {
      Edge e = new Edge(v1, v2);
      addEdge(e);
   }

   public void addEdge(Edge e) {
      if(adjacentList[e.getV1()] == null) {
         adjacentList[e.getV1()] = new LinkedList<Integer>();
      }
      adjacentList[e.getV1()].add(e.getV2());
      edgeList.add(e);
      numEdge++;
   }

   public void edgeListTraversal() {

      for(int i = 0; i < edgeList.size(); i++) {
         int a = edgeList.get(i).getV1();
         int b = edgeList.get(i).getV2();
         System.out.println("Edge Node: " + a + " ------ " + b);
      }
   }

   public void bfsGraph() {
      Queue<Integer> q = new LinkedList<Integer>();
      vistedVertex.add(0);
      q.add(0);
      while(!q.isEmpty()) {
         int horizontalNum = q.remove();
         System.out.print(horizontalNum + " ");
         for(int i = 0; i < adjacentList[horizontalNum].size(); i++) {
            int numToAdd = adjacentList[horizontalNum].get(i);
            if(!vistedVertex.contains(numToAdd)) {
               q.add(numToAdd);
               vistedVertex.add(numToAdd);
            }
         }
      }

   }
}
