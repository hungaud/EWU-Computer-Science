package s17cs350task1;
import s17cs350project.command.*;
import s17cs350project.component.thruster.A_Thruster;
import s17cs350project.datatype.*;
import s17cs350project.datatype.Dimension3D;
import s17cs350project.datatype.Point3D;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;

/**
 * Created by HungA on 6/8/2017.
 */
public class HungParser {

      public static void main(String[] args) {
         CommandController controller = new CommandController();
         String command =  "@WAIT 111\n";
        // private static String r_wait = "(?i)^@WAIT\\s+" + r_realNumber + "\\s*$";


         //createComponent(command);
         //createVernierThruster(command);
         //fireThruster(command);
         //disconnectStrut(command);
         //generateFlightPathFile(command);
         //metaForceAttitude(command);
         //metaConfigClock(command);
         //metaWait(command);

      }

      // 1
      private A_Command createComponent (String command) {
         boolean isRoot = false;
         String str[] = command.split("(?i) COMPONENT");
         String root[] = str[0].split("\\s+");
         if(root.length > 1 && root[1].equalsIgnoreCase("true"))
            isRoot = true;

         String id = str[1].split("(?i) SIZE")[0].trim();;
         str = str[1].split("(?i) WIDTH");
         str = str[1].split("(?i) Height");
         double width = Double.parseDouble(str[0].trim());
         str = str[1].split("(?i) DEPTH");
         double height = Double.parseDouble(str[0].trim());
         double depth = Double.parseDouble(str[1].trim());
         Dimension3D size = new Dimension3D(width, height, depth);
         return new CommandCreateComponent(id, size, isRoot);
      }

      // 4
      private A_Command createVernierThruster(String command) {
         String str[] = command.split("(?i) THRUSTER");
         str = str[1].split("(?i) AT");
         String id = str[0].trim();
         str = str[1].split("\\( ", 2);
         str = str[1].split(" \\)", 2);
         double x = Double.parseDouble(str[0].split("\\s+")[0].trim());
         double y = Double.parseDouble(str[0].split("\\s+")[1].trim());
         double z = Double.parseDouble(str[0].split("\\s+")[2].trim());
         Point3D position = new Point3D(x, y, z);

         str = str[1].split("(?i) SURFACE");
         String tempSurface = str[1].split("(?i) WITH")[0].trim().toLowerCase();
         str = str[1].split("(?i) ORIENTATION");
         String tempOrientation = str[1].split("(?i) USING")[0].trim().toLowerCase();
         str = str[1].split("(?i) THRUST", 2);

         double thrust = Double.parseDouble(str[1].split("(?i) RATE")[0].trim().toLowerCase());
         double rate = Double.parseDouble(str[1].split("(?i) RATE")[1].trim().toLowerCase());

         //System.out.println(id + " " + x + " " + y + " " + z + " " + tempSurface + " " + tempOrientation + " " + thrust + " " + rate);
         A_Thruster.E_Surface surface;
         A_Thruster.E_Orientation orientaiton;
         switch(tempSurface) {
            case "top":       surface = A_Thruster.E_Surface.TOP;
                              break;
            case "bottom":    surface = A_Thruster.E_Surface.BOTTOM;
                              break;
            case "left":      surface = A_Thruster.E_Surface.LEFT;
                              break;
            case "right":     surface = A_Thruster.E_Surface.RIGHT;
                              break;
            case "front":     surface = A_Thruster.E_Surface.FRONT;
                              break;
            default:          surface = A_Thruster.E_Surface.BACK;
         }
         switch(tempOrientation) {
            case "upward":    orientaiton = A_Thruster.E_Orientation.UPWARD;
                              break;
            case "downward":  orientaiton = A_Thruster.E_Orientation.DOWNWARD;
                              break;
            case "leftward":  orientaiton = A_Thruster.E_Orientation.LEFTWARD;
                              break;
            case "rightward": orientaiton = A_Thruster.E_Orientation.RIGHTWARD;
                              break;
            case "forward" :  orientaiton = A_Thruster.E_Orientation.FORWARD;
                              break;
            default:          orientaiton = A_Thruster.E_Orientation.BACKWARD;
         }
         return new CommandCreateVernierThruster(id, position, surface, orientaiton, new Percent(rate), new Thrust(thrust));
      }

   // 10
   private A_Command fireThruster(String command) {
      String str[] = command.split("(?i) GROUP");
      str = str[1].split("(?i) FOR");
      String id = str[0].trim();
      str = str[1].trim().split("\\s+", 2);
      Double seconds = Double.parseDouble(str[0].trim());
      if(str.length > 1) {
         String checkThrust[] = str[1].split("(?i) THRUST");
         double thrust = Double.parseDouble(checkThrust[1].trim().split("\\s+")[0]);
         return new CommandFireThruster(id, new Time(seconds), new Thrust(thrust));
      }
      return new CommandFireThruster(id, new Time(seconds));
   }

   // 13
   private A_Command disconnectStrut(String command) {
      return new CommandDisconnectStrut(command.split("(?i) STRUT")[1].trim());
   }

   //16
   private A_Command generateFlightPathFile(String command) {
      String str[] = command.split("(?i) FROM");
      CommandGeneratePath.E_Axis axisA, axisB, axisC;
      axisA = CommandGeneratePath.E_Axis.X_PLUS;
      axisB = CommandGeneratePath.E_Axis.Y_PLUS;
      axisC = CommandGeneratePath.E_Axis.Z_PLUS;

      if(str[0].toLowerCase().contains("using")){
         String change = str[0].trim().split("[\\[\\]]")[1];
         String axisA_s = change.split(" ")[0].toLowerCase().trim(); // Used this part from Dyllon,
         String axisB_s = change.split(" ")[1].toLowerCase().trim(); // should it be "\\s+" instead of
         String axisC_s = change.split(" ")[2].toLowerCase().trim(); // " " for the split? or is the " " suffficient?
         System.out.println(axisA_s + " " + axisB_s + " " + axisC_s);
         axisA = convertToAxis(axisA_s);
         axisB = convertToAxis(axisB_s);
         axisC = convertToAxis(axisC_s);
      }

      str = str[1].split("'", 2);
      String file = str[1].split("'")[0].trim();
      str = str[1].split("(?i) RATE", 2);
      str = str[1].split("(?i) MOTION");
      double attitudeRate = Double.parseDouble(str[0].trim());
      double motionRate = Double.parseDouble(str[1].split("(?i) RATE")[1].trim());
      return new CommandGeneratePath(axisA, axisB, axisC, file, attitudeRate, motionRate);
   }

   private CommandGeneratePath.E_Axis convertToAxis(String str){
      switch(str){
         case "+x":  return CommandGeneratePath.E_Axis.X_PLUS;
         case "-x":  return CommandGeneratePath.E_Axis.X_MINUS;
         case "+y":  return CommandGeneratePath.E_Axis.Y_PLUS;
         case "-y":  return CommandGeneratePath.E_Axis.Y_MINUS;
         case "+z":  return CommandGeneratePath.E_Axis.Z_PLUS;
         default  :  return CommandGeneratePath.E_Axis.Z_MINUS;
      }
   }

   // 17
   private A_Command metaForceAttitude(String command) {
      double yaw = 0.0, pitch = 0.0, roll = 0.0;
      String str[] = command.split("(?i) ON");
      str = str[1].split("(?i) TO");
      String id = str[0].trim();
      if(str[1].toLowerCase().contains("yaw")) {
         str = str[1].split("(?i) yaw");
         yaw = Double.parseDouble(str[1].trim().split(" ")[0]);
      }
      if(str[1].toLowerCase().contains("pitch")) {
         str = str[1].split("(?i) pitch");
         pitch = Double.parseDouble(str[1].trim().split(" ")[0]);
      }
      if(str[1].toLowerCase().contains("roll")) {
         str = str[1].split("(?i) roll");
         roll = Double.parseDouble(str[1].trim().split(" ")[0]);
      }
      return new CommandMetaForceAttitude(id, new Attitude(yaw, pitch, roll));
   }

   // 18
   private A_Command metaForceAttitudeRate(String command) {
      double yaw = 0.0, pitch = 0.0, roll = 0.0;
      String str[] = command.split("(?i) ON");
      str = str[1].split("(?i) TO");
      String id = str[0].trim();
      if(str[1].toLowerCase().contains("yaw")) {
         str = str[1].split("(?i) yaw");
         yaw = Double.parseDouble(str[1].trim().split(" ")[0]);
      }
      if(str[1].toLowerCase().contains("pitch")) {
         str = str[1].split("(?i) pitch");
         pitch = Double.parseDouble(str[1].trim().split(" ")[0]);
      }
      if(str[1].toLowerCase().contains("roll")) {
         str = str[1].split("(?i) roll");
         roll = Double.parseDouble(str[1].trim().split(" ")[0]);
      }
      return new CommandMetaForceAttitudeRate(id, new Attitude(yaw, pitch, roll));
   }

   // 21
   private A_Command metaConfigClock(String command) {
      String[] str = command.split("\\s+");
      double rate = Double.parseDouble(str[2].trim());
      double step = Double.parseDouble(str[3].trim());
      System.out.println(step + " " + rate);
      return new CommandMetaConfigClock(new Time(rate), new Time(step));
   }

   // 22
   private A_Command metaWait(String command) {
      double deltaTime = Double.parseDouble(command.split("\\s+")[1].trim());
      return new CommandMetaWait(new Time(deltaTime));
   }

}
