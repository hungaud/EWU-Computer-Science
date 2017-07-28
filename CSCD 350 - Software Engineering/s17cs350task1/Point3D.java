package s17cs350task1;

/**
 * Created by HungA on 5/30/2017.
 */
public class Point3D implements Cloneable {

   private double x, y, z;

   public Point3D(double x, double h, double d) {
      if(x <=0 || h <= 0 || d <= 0) {
         throw new TaskException("Invalid input for width, height, and or depth");
      }
      this.x = x;
      this.y = h;
      this.z = d;
   }

   @Override
   public Point3D clone() throws CloneNotSupportedException {
      Point3D point = (Point3D) super.clone();
      point.x = x;
      point.y = y;
      point.z = z;
      return point;
   }

   public double getX() {
      return x;
   }

   public double getY() {
      return y;
   }

   public double getZ() {
      return z;
   }

   public Point3D add(Point3D point) {
      if(point == null) {
         throw new TaskException("Error! Point being added is null");
      }
      double x, y, z;
      x = this.x + point.getX();
      y = this.y + point.getY();
      z = this.z + point.getZ();
      return new Point3D(x, y, z);
   }

   public Point3D subtract(Point3D point) {
      if(point == null) {
         throw new TaskException("Error! Point being subtracted is null");
      }
      double x, y, z;
      x = this.x - point.getX();
      y = this.y - point.getY();
      z = this.z - point.getZ();
      return new Point3D(x, y, z);
   }

   @Override
   public String toString() {
      return "[" + x + " " + y + " " + z + "]";
   }

}
