package s17cs350task1;

/**
 * Created by Hung Auduong on 5/30/2017.
 */
public abstract class A_Exporter {

   private boolean exportClosed = false;
   private boolean componentClosed = true;
   private StringBuilder exportString = new StringBuilder();

   public A_Exporter() {}

   void append(String s) {
      exportString.append(s);
   }

   abstract void addPoint(String id, Point3D point);

   abstract void closeComponentNode(String id);

   public void closeExport() {
      if(exportClosed) {
         throw new TaskException("Export is already closed.");
      }
      exportClosed = true;
   }

   public void setComponentClosed(boolean close) {
      componentClosed = close;
   }

   public String export() {
      if(!exportClosed) {
         throw new TaskException("Export is not closed yet.");
      }
      return exportString.toString();
   }

   public boolean isClosed() {
      return exportClosed;
   }

   public boolean isComponentClosed() {
      return componentClosed;
   }

   abstract void openComponentNode(String id);

   abstract void openComponentNode(String id, String idParent);
}
