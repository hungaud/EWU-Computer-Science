// Hung Auduong
// CSCD 350 Software Engineering
// Dan Tappan
// LAB 1

package s17cs350task1;

public class Connector implements Cloneable {

   private A_Component childComponent;
   private A_Component parentComponent;
   private Point3D offsetFromParentBox;

   public Connector(A_Component childComponent, Point3D offsetFromParentBox) {
      if(childComponent == null) {
         throw new TaskException("ChildBox is null when creating a connector");
      }
      if(offsetFromParentBox == null) {
         throw new TaskException("OffsetFromParentBox is null when creating a connector");
      }
      if(childComponent.isRoot()) {
         throw new TaskException("childbox can not be a rootbox");
      }
      this.childComponent = childComponent;
      this.offsetFromParentBox = offsetFromParentBox;
      childComponent.setConnectorToParent(this);
   }

   public Connector clone() throws CloneNotSupportedException {
      Connector cloneChild = (Connector) super.clone();
      cloneChild.childComponent = childComponent.clone();
      cloneChild.parentComponent = null;
      cloneChild.offsetFromParentBox = new Point3D(offsetFromParentBox.getX(), offsetFromParentBox.getY(), offsetFromParentBox.getZ());
      return cloneChild;
   }


   public A_Component getComponentChild() {
      return this.childComponent;
   }

   public Point3D getOffsetFromParent() {
      return this.offsetFromParentBox;
   }

   public A_Component getComponentParent() {
      if(hasComponentParent()) {
         return parentComponent;
      } else {
         throw new TaskException("Box does not have a parentComponent");
      }
   }

   public boolean hasComponentParent() {
      return parentComponent != null;
   }

   public void setParentComponent(A_Component parentComponent) {
      if(parentComponent == null) {
         throw new TaskException("ParentBox is null when trying to set as Parent box");
      }

      this.parentComponent = parentComponent;
   }

}
