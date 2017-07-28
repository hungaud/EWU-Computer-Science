package s17cs350task1;


import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by HungA on 5/11/2017.
 */

public class BoundingBox implements Cloneable {

   private Point3D center;
   private Dimension3D size;

   public BoundingBox(Point3D center, Dimension3D size) {
      this.center = center;
      this.size = size;
   }

   public double calculateArea(E_Plane plane) {
      if(plane == null) {
         throw new TaskException("plane passed in is NULL");
      }
      switch (plane) {
         case XY:
            return size.getWidth() * size.getHeight() * 2;
         case XZ:
            return size.getWidth() * size.getDepth() * 2;
         case YZ:
            return size.getHeight() * size.getDepth() * 2;
      }
      throw new TaskException("plane passed in is null");
   }

   public double calculateVolume() {
      return size.getDepth() * size.getHeight() * size.getWidth();
   }

   public BoundingBox clone() throws java.lang.CloneNotSupportedException {
      BoundingBox temp = (BoundingBox) super.clone();
      temp.size = new Dimension3D(this.size.getWidth(), this.size.getHeight(), this.size.getDepth());
      temp.center = new Point3D(this.center.getX(), this.center.getY(), this.center.getZ());
      return temp;
   }

   public BoundingBox extend(BoundingBox boundingBox) {
      if(boundingBox == null) {
         throw new TaskException("BoundingBox passed in is NULL");
      }
      List<Point3D> corners = this.generateCorners();
      corners.addAll(boundingBox.generateCorners());
      double maxX = Double.MIN_VALUE, maxY = Double.MIN_VALUE, maxZ = Double.MIN_VALUE;
      double minX = Double.MAX_VALUE, minY = Double.MAX_VALUE, minZ = Double.MAX_VALUE;
      double width, height, depth;
      Point3D temp;
      for(int i = 0; i < corners.size(); i++) {
         temp = corners.get(i);
         maxX = Math.max(maxX, temp.getX());
         minX = Math.min(minX, temp.getX());
         maxY = Math.max(maxY, temp.getY());
         minY = Math.min(minY, temp.getY());
         maxZ = Math.max(maxZ, temp.getZ());
         minZ = Math.min(minZ, temp.getZ());
      }
      width = maxX - minX;
      height = maxY - minY;
      depth = maxZ - minZ;
      return new BoundingBox(new Point3D(maxX - (width /2), maxY - (height / 2), maxZ - (depth /2)), new Dimension3D(width, height, depth));
   }

   public List<Point3D> generateCorners() {
      List<Point3D> corners = new ArrayList<>();
      double w, h, d, x, y, z;
      w = size.getWidth() / 2;
      h = size.getHeight() / 2;
      d = size.getDepth() / 2;
      x = center.getX();
      y = center.getY();
      z = center.getZ();
      corners.add(new Point3D(x - w, y - h, z - d));//left bottom far
      corners.add(new Point3D(x + w, y - h, z - d));//right bottom far
      corners.add(new Point3D(x + w, y - h, z + d));//right bottom near
      corners.add(new Point3D(x - w, y - h, z + d));//left bottom near
      corners.add(new Point3D(x - w, y + h, z - d));//left top far
      corners.add(new Point3D(x + w, y + h, z - d));//right top far
      corners.add(new Point3D(x + w, y + h, z + d));//right top near
      corners.add(new Point3D(x - w, y + h, z + d));//left top near
      return corners;

   }

   public Point3D getCenter() {
      return new Point3D(this.center.getX(), this.center.getY(), this.center.getZ());
   }

   public Dimension3D getSize() {
      return new Dimension3D(this.size.getWidth(), this.size.getHeight(), this.size.getDepth());
   }

   public static enum E_Plane implements Serializable, Comparable<E_Plane> {
      XY, XZ, YZ;
   }

   public String toString() {
      return String.format("[%s, %s]", center.toString(), size.toString());
   }

}
