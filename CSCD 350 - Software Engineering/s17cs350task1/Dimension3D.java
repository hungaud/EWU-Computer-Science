package s17cs350task1;

/**
 * Created by HungA on 4/18/2017.
 */
public class Dimension3D implements Cloneable {

   private double width;
   private double height;
   private double depth;

   public Dimension3D(double w, double h, double d) {
      if(w <=0 || h <= 0 || d <= 0) {
         throw new TaskException("Invalid input for width, height, and or depth");
      }
      width = w;
      height = h;
      depth = d;
   }

   public double getWidth() {
      return width;
   }

   public double getHeight() {
      return height;
   }

   public double getDepth() {
      return depth;
   }

   public Dimension3D clone() throws CloneNotSupportedException {
      return (Dimension3D) super.clone();
   }
	@Override
	public String toString() {
		return "[" + width + " " + height + " " + depth + "]";
	}
}
