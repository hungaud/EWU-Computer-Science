import java.util.*;

/**
 * Created by HungA on 2/23/2018.
 */
public class Graph {
   private LinkedList<Integer>[] adjacentList;
   private int numEdge;
   private Set<Integer> vistedVertex;
   private List<Edge> edgeList;
   private Set<Integer> test = new HashSet<>();

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

   public void addEdge(int v1, int v2, int weight) {
      Edge e = new Edge(v1, v2, weight);
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

   public int edgeCost(int a, int b) {
      for(Edge e : edgeList) {
         if(e.getV1() == a && e.getV2() == b) {
            return e.getWeight();
         }
      }
      return -1;
   }

   public void dfsGraph(int n) {
      if(!vistedVertex.contains(n)) {
         vistedVertex.add(n);
         System.out.print(n + " ");
         if(adjacentList[n] != null) {
            for(int i = 0; i < adjacentList[n].size(); i++) {
               dfsGraph(adjacentList[n].get(i));
            }
         }
      }

   }

   public Path shortestPath(int a, int b) {
      if(a == 0 || b == 0) {
         throw new IllegalArgumentException("Either A or B input is 0");
      }
      if (a == b) {
         ArrayList<Integer> temp = new ArrayList<>();
         temp.add(a);
         temp.add(b);
         return new Path(temp, 0);
      }

      Set<Integer> unknownVertex = new HashSet<>();
      Set<Integer> knownVertex = new HashSet<>();
      HashMap<Integer, Integer> distance = new HashMap<>();
      HashMap<Integer, Integer> link = new HashMap<>();

      for(Edge e : edgeList) {
         distance.put(e.getV1(), Integer.MAX_VALUE);
         distance.put(e.getV2(), Integer.MAX_VALUE);
         unknownVertex.add(e.getV1());
         unknownVertex.add(e.getV2());
      }

      unknownVertex.remove(a);
      distance.put(a, 0);
      while(!unknownVertex.isEmpty()) {
         for(int adj : adjacentList[a]) {
            if(unknownVertex.contains(adj)) {
               int c1 = distance.get(a) + edgeCost(a, adj);
               int c2 = distance.get(adj);
               if(c1 < c2) {
                  distance.put(adj, c1);
                  link.put(adj, a);
               }
               if(!knownVertex.contains(adj)) {
                  knownVertex.add(adj);
               }
            }
         }
         int min = Integer.MAX_VALUE;
         for(int vertex : knownVertex) {
            int n = distance.get(vertex);
            if(n < min) {
               min = n;
               a = vertex;
            }
         }
         if(a == b) {
            unknownVertex.clear();
         }

         knownVertex.remove(a);
         unknownVertex.remove(a);
      }
      if(a == b) {
         List<Integer> finalList = new ArrayList<>();
         if(link.get(b) == null) {
            return null;
         } else {
            finalList.add(b);
            int temp = b;
            while(link.get(temp) != null) {
               temp = link.get(temp);
               finalList.add(temp);
            }
            Collections.reverse(finalList);
         }
         Path p = new Path(finalList, distance.get(b));
         return p;
      } else {
         return null;
      }
   }
}
