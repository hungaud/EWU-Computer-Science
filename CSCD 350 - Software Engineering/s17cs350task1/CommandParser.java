package s17cs350task1;

import s17cs350project.command.A_Command;

import java.awt.*;

/**
 * Created by HungA on 6/1/2017.
 */
/*

package s17cs350project.parser;

      import s17cs350project.command.*;

*/

public class CommandParser {


   private static String r_id = "[0-9a-zA-Z_]+";
   private static String r_literal = "\'[\\w\\s\\.\\_]*\'";
   private static String r_realNumber = "[-+]?\\d*(.\\d*)?";
   private static String r_listNums = "\\{(\\s*\\[\\s*" + r_realNumber + "\\s+" + r_realNumber + "\\s+" + r_realNumber + "\\s*\\]\\s*)+\\}";

   private static String r_createComponent = "(?i)^CREATE\\s+(ROOT)?\\s+COMPONENT\\s+" + r_id + "\\s+SIZE\\s+WIDTH\\s+" + r_realNumber + "\\s+HEIGHT\\s+" + r_realNumber + "\\s+DEPTH\\s+" + r_realNumber + "\\s*$";
   private static String r_createThrusterFixed = "(?i)^CREATE\\s+MAIN\\s+THRUSTER\\s+" + r_id + "\\s+AT\\s+OFFSET\\s+\\([\\s*]?" + r_realNumber + "\\s+" + r_realNumber + "\\s+" + r_realNumber + "[\\s*]?\\)\\s+ON\\s+SURFACE\\s+(TOP|BOTTOM|LEFT|RIGHT|FRONT|BACK)\\s+WITH\\s+ORIENTATION\\s+(UPWARD|DOWNWARD|LEFTWARD|RIGHTWARD|FORWARD|BACKWARD)\\s+USING\\s+FIXED\\s+POWER\\s+" + r_realNumber + "\\s+RATE\\s+" + r_realNumber + "\\s*$";
   private static String r_createThrusterVariable = "(?i)^CREATE\\s+MAIN\\s+THRUSTER\\s+" + r_id + "\\s+AT\\s+OFFSET\\s+\\([\\s*]?" + r_realNumber + "\\s+" + r_realNumber + "\\s+" + r_realNumber + "[\\s*]?\\)\\s+ON\\s+SURFACE\\s+(TOP|BOTTOM|LEFT|RIGHT|FRONT|BACK)\\s+WITH\\s+ORIENTATION\\s+(UPWARD|DOWNWARD|LEFTWARD|RIGHTWARD|FORWARD|BACKWARD)\\s+USING\\s+VARIABLE\\s+POWER\\s+MIN\\s+" + r_realNumber + "\\s+MAX\\s+" + r_realNumber + "\\s+RATE\\s+" + r_realNumber + "\\s*$";
   private static String r_createVernierThruster = "(?i)^CREATE\\s+VERNIER\\s+THRUSTER\\s+" + r_id + "\\s+AT\\s+OFFSET\\s+\\([\\s*]?" + r_realNumber + "\\s+" + r_realNumber + "\\s+" + r_realNumber + "[\\s*]?\\)\\s+ON\\s+SURFACE\\s+(TOP|BOTTOM|LEFT|RIGHT|FRONT|BACK)\\s+WITH\\s+ORIENTATION\\s+(UPWARD|DOWNWARD|LEFTWARD|RIGHTWARD|FORWARD|BACKWARD)\\s+USING\\s+POWER\\s+" + r_realNumber + "\\s+RATE\\s+" + r_realNumber + "\\s*$";

   private static String r_createStaticConnector = "(?i)^CREATE\\s+STATIC\\s+CONNECTOR\\s+" + r_id + "\\s+FROM\\s+" + r_id + "\\s+TO\\s+" + r_id + "\\s+WITH\\s+OFFSET\\s+\\([\\s*]?" + r_realNumber + "\\s+" + r_realNumber + "\\s+" + r_realNumber + "[\\s*]?\\)(\\s+ALLOW\\s+(DISCONNECTION|RECONNECTION)?\\s*(RECONNECTION|DISCONNECTION)?)?\\s*$";
   private static String r_buildMainThrusterGroup = "(?i)^BUILD\\s+MAIN\\s+THRUSTER\\s+GROUP\\s+" + r_id + "\\s+WITH\\s+(THRUSTER|THRUSTERS)\\s+" + r_id + "(\\s+" + r_id + ")+\\s*$";
   private static String r_buildVernierThrusterGroup = "(?i)^BUILD\\s+VERNIER\\s+THRUSTER\\s+GROUP\\s+" + r_id + "\\s+WITH\\s+(THRUSTER|THRUSTERS)\\s+" + r_id + "(\\s+" + r_id + ")+\\s*$";
   private static String r_addThrusterGroups = "(?i)^ADD\\s+THRUSTER\\s+(GROUP|GROUPS)\\s+(\\s*" + r_id + ")+\\s+TO\\s+" + r_id + "\\s*$";

   private static String r_fireThrusterGroup = "(?i)^FIRE\\s+THRUSTER\\s+GROUP\\s+" + r_id + "\\s+FOR\\s+" + r_realNumber + "\\s+(SECOND|SECONDS)\\s*(\\s+AT\\s+THRUST\\s+" + r_realNumber + ")?\\s*$";
   private static String r_extendStrut = "(?i)^EXTEND\\s+STRUT\\s+" + r_id + "\\s*$";
   private static String r_retractStrut = "(?i)^RETRACT\\s+STRUT\\s+" + r_id + "\\s*$";
   private static String r_disconnectStrut = "(?i)^DISCONNECT\\s+STRUT\\s+" + r_id + "\\s*$";
   private static String r_reconnectStrut = "(?i)^RECONNECT\\s+STRUT\\s+" + r_id + "\\s+TO\\s+" + r_id + "\\s*$";
   private static String r_generateFlightPathFromFile = "(?i)^GENERATE\\s+FLIGHT\\s+PATH\\s+(using\\s*\\[\\s*[+|-][x|y|z]\\s+[+|-][x|y|z]\\s+[+|-][x|y|z]\\s*\\]\\s+)?from\\s+" + r_literal + "\\s+WITH\\s+ATTITUDE\\s+RATE\\s+" + r_realNumber + "\\s+MOTION\\s+RATE\\s+" + r_realNumber + "\\s*$";

   private static String r_forceAttitude = "(?i)^@FORCE\\s+ATTITUDE\\s+ON\\s+" + r_id + "\\s+TO\\s+(PITCH|ROLL|YAW)\\s+" + r_realNumber + "\\s+(PITCH|ROLL|YAW)\\s+" + r_realNumber + "\\s+(PITCH|ROLL|YAW)\\s+" + r_realNumber + "\\s*$";
   private static String r_forceAttitudeChangeRate = "(?i)^@FORCE\\s+ATTITUDE\\s+RATE\\s+ON\\s+" + r_id + "\\s+TO\\s+(PITCH|ROLL|YAW)\\s+" + r_realNumber + "\\s+(PITCH|ROLL|YAW)\\s+" + r_realNumber + "\\s+(PITCH|ROLL|YAW)\\s+" + r_realNumber + "\\s*$";
   private static String r_configClock = "(?i)^@CONFIG\\s+CLOCK\\s+" + r_realNumber + "\\s+" + r_realNumber + "\\s*$";
   private static String r_wait = "(?i)^@WAIT\\s+" + r_realNumber + "\\s*$";
   private static String r_load = "(?i)^@LOAD\\s+" + r_literal + "\\s*$";
   private static String r_commit = "(?i)^@COMMIT\\s*$";
   private static String r_exit = "(?i)^@EXIT\\s*$";
   private static String r_pause = "(?i)^@PAUSE\\s*$";
   private static String r_resume = "(?i)^@RESUME\\s*$";
   private static String r_dump = "(?i)^@DUMP\\s+COMPONENT\\s+" + r_id + "\\s+" + r_literal + "\\s*$";

   private static String r_createDynamicConnector = "(?i)^CREATE\\s+DYNAMIC\\s+CONNECTOR\\s+" + r_id + "\\s+FROM\\s+" + r_id + "\\s+TO\\s+" + r_id + "\\s+WITH\\s+OFFSET\\s+ALPHA\\s+\\([\\s*]?" + r_realNumber + "\\s+" + r_realNumber + "\\s+" + r_realNumber + "[\\s*]?\\)\\s+BETA\\s+\\([\\s*]?" + r_realNumber + "\\s+" + r_realNumber + "\\s+" + r_realNumber + "[\\s*]?\\)\\s+EXTENT\\s+INITIAL\\s+" + r_realNumber + "\\s+SPEED\\s+" + r_realNumber + "\\s*(\\s+ALLOW\\s+(DISCONNECTION|RECONNECTION)?\\s*(RECONNECTION|DISCONNECTION)?)?\\s*$";
   private static String r_forcePosition = "(?i)^@FORCE\\s+POSITION\\s+ON\\s+" + r_id + "\\s+TO\\s+\\(\\s*(_|" + r_realNumber + ")\\s*(_|" + r_realNumber + ")\\s*(_|" + r_realNumber + ")\\s*\\)\\s*$";
   private static String r_forceMotionVector = "(?i)^@FORCE\\s+MOTION\\s+VECTOR\\s+ON\\s+" + r_id + "\\s+TO\\s+\\[\\s*(_|" + r_realNumber + ")\\s*(_|" + r_realNumber + ")\\s*(_|" + r_realNumber + ")\\s*(_|" + r_realNumber + ")\\]\\s*$";
   private static String r_generateFlightPath = "(?i)^GENERATE\\s+FLIGHT\\s+PATH\\s+(using\\s*\\[\\s*[+|-][x|y|z]\\s+[+|-][x|y|z]\\s+[+|-][x|y|z]\\s*\\]\\s+)?from\\s+" + r_listNums + "\\s+WITH\\s+ATTITUDE\\s+RATE\\s+" + r_realNumber + "\\s+MOTION\\s+RATE\\s+" + r_realNumber + "\\s*$";


   private String commands;
   private CommandController controller;

   public CommandParser(CommandController controller, String commands){
      if(controller == null)
        //throw new RunTimeException("Controller was null");
      if(commands == null)
         //throw new RunTimeException("Commands was null");

      this.commands = commands;
      this.controller = controller;
   }

   public A_Command parse(){
      return null;
   }


}













