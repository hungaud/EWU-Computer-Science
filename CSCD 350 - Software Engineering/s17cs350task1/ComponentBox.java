package s17cs350task1;


import java.util.ArrayList;
import java.util.List;

/**
 * Created by Hung Auduong on 5/30/2017.
 */
public class ComponentBox extends A_Component {

   private Dimension3D size;

   public ComponentBox(String id, Dimension3D size) {
      this(id, size, false);
   }

   public ComponentBox(String id, Dimension3D size, boolean isRoot) {
      super(id, isRoot);
      this.size = size;
   }

   public ComponentBox clone() throws CloneNotSupportedException{
      ComponentBox clone = (ComponentBox) super.clone();
      clone.size = size.clone();
      return clone;
   }


   public double calculateAreaAll(BoundingBox.E_Plane plane) {
      if(plane == null) {
         throw new TaskException("Plane for area is Null");
      }
      double sum = calculateAreaSelf(plane);
      List<A_Component> componentChildren = getDescendants();
      for(A_Component child : componentChildren) {
         sum += child.calculateAreaSelf(plane);
      }
      return sum;
   }

   public double calculateAreaSelf(BoundingBox.E_Plane plane) {
      if(plane == null)
         throw new TaskException("plane is null when calculate area self");
      return (generateBoundingBoxSelf().calculateArea(plane));
   }

   public Point3D calculateCenterOfMassAll() {
      BoundingBox boundingBox = generateBoundingBoxAll();
      Point3D center = boundingBox.getCenter();
      return center;
   }

   public Point3D calculateCenterOfMassSelf() {
      return getAbsoluteCenterPosition();
   }


   public double calculateVolumeAll() {
      double sum = calculateVolumeSelf();
      List<A_Component> temp = getDescendants();
      for(A_Component b : temp) {
         sum += b.calculateVolumeSelf();
      }
      return sum;
   }

   public double calculateVolumeSelf() {
      return generateBoundingBoxSelf().calculateVolume();
   }

   public String export(A_Exporter exporter) {
      if(exporter == null) {
         throw new TaskException("exporter is null in export");
      }
      String ID, parentID;
      List<A_Component> tree = this.getDescendants();
      List<Point3D> points;
      for(A_Component c : tree) {
         ID = c.getID();
         if(c.isRoot()) {
            exporter.openComponentNode(ID);
         } else {
            A_Component parent = c.getConnectorToParent().getComponentParent();
            parentID = parent.getID();
            exporter.openComponentNode(ID, parentID);
         }
         points = c.generateFrameSelf();

         exporter.addPoint("center", points.get(0));
         exporter.addPoint("left-bottom-far", points.get(1));
         exporter.addPoint("right-bottom-far", points.get(2));
         exporter.addPoint("right-bottom-near", points.get(3));
         exporter.addPoint("left-bottom-near", points.get(4));
         exporter.addPoint("left-top-far", points.get(5));
         exporter.addPoint("right-top-far", points.get(6));
         exporter.addPoint("right-top-near", points.get(7));
         exporter.addPoint("left-top-near", points.get(8));
         exporter.closeComponentNode(ID);
      }
      exporter.closeExport();
      return exporter.export();
   }

   public BoundingBox generateBoundingBoxAll() {
      BoundingBox temp = generateBoundingBoxSelf();
      List<A_Component> descend = getDescendants();
      for (A_Component b : descend) {
         temp = temp.extend(b.generateBoundingBoxSelf());
      }
      return temp;
   }

   public BoundingBox generateBoundingBoxSelf() {
      return new BoundingBox(getAbsoluteCenterPosition(), size);
   }

   public List<List<Point3D>> generateFramesAll() {
      List<List<Point3D>> temp = new ArrayList<>();
      temp.add(generateFrameSelf());
      List<A_Component> boxes = getDescendants();
      for(A_Component b : boxes) {
         temp.add(b.generateFrameSelf());
      }
      return temp;
   }

   public List<Point3D> generateFrameSelf() {
      List<Point3D> points = new ArrayList<>();
      points.add(getAbsoluteCenterPosition());
      points.addAll(generateBoundingBoxSelf().generateCorners());
      return points;
   }

   public Dimension3D getSize() {
      return size;
   }








}
