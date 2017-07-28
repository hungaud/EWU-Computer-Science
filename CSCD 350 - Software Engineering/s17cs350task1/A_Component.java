package s17cs350task1;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

/**
 * Created by Hung Auduong on 5/30/2017.
 */
public abstract class A_Component implements Cloneable {

   private String id;
   private boolean isRoot;
   private ArrayList<Connector> children;
   private Connector parent;


   public A_Component(String id, boolean isRoot) {
      if(id == null || id.equals("")) {
         throw new TaskException("ID was null or empty");
      }
      this.id = id;
      this.isRoot = isRoot;
      children = new ArrayList<>();
   }


   abstract double calculateAreaAll(BoundingBox.E_Plane plane);

   abstract public double calculateAreaSelf(BoundingBox.E_Plane plane);

   abstract public Point3D calculateCenterOfMassAll();

   abstract public Point3D calculateCenterOfMassSelf();

   abstract public double calculateVolumeAll();

   abstract public double calculateVolumeSelf();

   public A_Component clone() throws CloneNotSupportedException {
      A_Component clone = (A_Component) super.clone();
      clone.id = new String(this.getID());
      clone.parent = null;
      if(!hasConnectorToParent()) {
         clone.isRoot = isRoot();
      }
      clone.children = new ArrayList<>();
      for(Connector connect : children) {
         clone.connectChild(connect.clone());
      }
      return clone;
   }

   public void connectChild(Connector connector) {
      if(connector == null) {
         throw new TaskException("Connector is null");
      }
      if(connector.getComponentChild().isRoot()) {
         throw new TaskException("Connector child can not be a root.");
      }
      if(!matchingID(connector, connector.getComponentChild().getID())) {
         throw new TaskException("Tree already contains the this ID.");
      }
      connector.setParentComponent(this);
      children.add(connector);
   }


   private boolean matchingID(Connector connectChild, String checkingID) {
      A_Component temp = this;
      while(temp.hasConnectorToParent()) {
         temp = temp.getConnectorToParent().getComponentParent();
      }
      List<A_Component> checkTempTree = temp.getDescendants();
      List<A_Component> checkTempConnector = connectChild.getComponentChild().getDescendants();
      ArrayList<String> idTree = new ArrayList<>();
      ArrayList<String> idChild = new ArrayList<>();
      for(A_Component component : checkTempTree) {
         idTree.add(component.getID().toLowerCase());
      }
      idChild.add(checkingID.toLowerCase());
      for(A_Component component : checkTempConnector) {
         idChild.add(component.getID().toLowerCase());
      }
      return Collections.disjoint(idTree, idChild);
   }

   public abstract String export(A_Exporter exporter);

   abstract public BoundingBox generateBoundingBoxAll();

   abstract public BoundingBox generateBoundingBoxSelf();

   abstract public List<List<Point3D>> generateFramesAll();

   abstract public List<Point3D> generateFrameSelf();

   public Point3D getAbsoluteCenterPosition() {
      Point3D point = new Point3D(0,0,0);
      if(!hasConnectorToParent()) {
         if(!isRoot) {
            throw new TaskException("Box is not connected to a root");
         }
         return point;
      } else {
         point = point.add(parent.getOffsetFromParent()).add(parent.getComponentParent().getAbsoluteCenterPosition());
         return point;
      }
   }

   public int getChildCount() {
      return children.size();
   }

   public List<A_Component> getChildren() {
      ArrayList<A_Component> component = new ArrayList<>();
      for(Connector c : children) {
         component.add(c.getComponentChild());
      }
      Collections.sort(component, new Comparator<A_Component>() {
         @Override
         public int compare(A_Component b1, A_Component b2) {
            return b1.id.compareTo((b2.id));
         }
      });
      return component;
   }

   public List<Connector> getConnectorsToChildren() {
      List<Connector> temp = new ArrayList<>();
      temp.addAll(children);
      return temp;
   }

   public Connector getConnectorToParent() {
      if(hasConnectorToParent()) {
         return parent;
      } else {
         throw new TaskException("No connector to parent");
      }
   }

   public int getDescendantBoxCount() {
      return getDescendants().size();
   }

   public List<A_Component> getDescendants() {
      List<A_Component> allChildren = getChildren();
      for(int i = 0; i < allChildren.size(); i++) {
         List<A_Component> list = allChildren.get(i).getChildren();
         allChildren.addAll(list);
         for(int j = 0; j < list.size(); j++) {
            allChildren.addAll(list.get(j).getDescendants());
         }
      }
      Collections.sort(allChildren, new Comparator<A_Component>() {
         @Override
         public int compare(A_Component child1, A_Component child2) {
            return child1.id.compareTo((child2.id));
         }
      });
      return allChildren;
   }

   public String getID() {
      return id;
   }

   public boolean hasConnectorToParent() {
      return parent != null;
   }

   public boolean isRoot() {
      return isRoot;
   }

   public void setConnectorToParent(Connector connector) {
      parent = connector;
   }






}
