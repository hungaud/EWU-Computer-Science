package s17cs350task1;

/**
 * Created by Hung Auduong on 5/30/2017.
 */
public class ExporterXML extends A_Exporter {

   public ExporterXML() {
      //super();
      append("<components>\n");
   }

   @Override
   void addPoint(String id, Point3D point) {
      if(id == null || point == null) {
         throw new TaskException("addPoint id/ point is null.");
      }
      if(isClosed()) {
         throw new TaskException("export is closed");
      }
      append("\t\t<point id=" + id + " x=" + point.getX() + " y=" + point.getY() + " z=" + point.getZ() + "/>\n");
   }

   @Override
   void closeComponentNode(String id) {
      if(id == null) {
         throw new TaskException("closeComponentNode id is null.");
      }
      if(isClosed()) {
         throw new TaskException("Component is closed in closeComponentNode");
      }
      //setComponentClosed(true);
      append("</components>\n");

   }

   @Override
   public void closeExport() {
      append("</components>");
      super.closeExport();
   }

   @Override
   void openComponentNode(String id) {
      if(id == null) {
         throw new TaskException("open id is null.");
      }
      if(isClosed()) {
         throw new TaskException("Component is closed in openComponentNode");
      }
      append("<component id=\"" + id + "isRoot=\"true\">");
   }

   @Override
   void openComponentNode(String id, String idParent) {
      if(id == null || idParent == null) {
         throw new TaskException("open id/ parentid is null.");
      }
      if(isClosed()) {
         throw new TaskException("Component is closed in openComponentNode2");
      }
      append("<component id=\"" + id + "\" isRoot=\"false\" parent-id=\"" + idParent + "\">");
   }
}
