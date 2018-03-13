import java.util.List;

public class Path {

   private List<Integer> vertices;
   private final int cost;

   public Path(List<Integer> vertices, int cost) {
      this.vertices = vertices;
      this.cost = cost;
   }

   public int getCost() {
      return cost;
   }

   public List<Integer> getVertices() {
      return vertices;
   }

   public String toString() {
      String s = vertices.get(0) + "";
      for(int i = 1; i < vertices.size(); i++) {
         s += " -> " + vertices.get(i);
      }
      return s;
   }
}
