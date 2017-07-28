package s17cs350task1;

import java.io.InputStream;
import java.io.IOException;
import java.util.*;

public class WaypointPlanner
{
   // NESTED COORDINATES CLASS
   public static class Coordinates {

      double first, second, third;

      public Coordinates(final double first, final double second, final double third) {
         this.first = first;
         this.second = second;
         this.third = third;
      }

      @Override
      public String toString()
      {
         return "(" + this.first + " " + this.second + " " + this.third + ")";
      }

      private double calcSubDistance(Coordinates c, E_AxisCombinationNeutral axes) {
         double result = 0.0;
         switch(axes) {
            case FIRST:
               result = Math.abs(c.first - first);
               break;
            case SECOND:
               result = Math.abs(c.second - second);
               break;
            case THIRD:
               result = Math.abs(c.third - third);
               break;
            case FIRST_SECOND:
               result = Math.sqrt(Math.pow(c.first - first, 2) + Math.pow(c.second - second, 2));
               break;
            case FIRST_THIRD:
               result = Math.sqrt(Math.pow(c.first - first, 2) + Math.pow(c.third - third, 2));
               break;
            case SECOND_THIRD:
               result = Math.sqrt(Math.pow(c.second - second, 2) + Math.pow(c.third - third, 2));
               break;
            case FIRST_SECOND_THIRD:
               result = Math.sqrt(Math.pow(c.first - first, 2) + Math.pow(c.second - second, 2) + Math.pow(c.third - third, 2));
               break;
         }
         return result;
      }

   }

   // NESTED ENUMS
   public static enum E_AxisCombinationNeutral {
      FIRST, FIRST_SECOND, FIRST_SECOND_THIRD, FIRST_THIRD, SECOND, SECOND_THIRD, THIRD;
   }

   public static enum E_AxisNative {
      X_MINUS(-1), X_PLUS(1), Y_MINUS(-1), Y_PLUS(1), Z_MINUS(-1), Z_PLUS(1);

      private int value;

      private E_AxisNative(final int value){this.value = value;}

      protected boolean isSameAxis(E_AxisNative other){
         if((this == X_MINUS || this == X_PLUS) && (other == X_MINUS || other == X_PLUS)) return true;
         else if((this == Y_MINUS || this == Y_PLUS) && (other == Y_MINUS || other == Y_PLUS)) return true;
         else if((this == Z_MINUS || this == Z_PLUS) && (other == Z_MINUS || other == Z_PLUS)) return true;

         // axes are distinct
         return false;
      }

      protected int getTransform(){return this.value;}
   }

   public static enum E_Unit {
      FEET, KILOMETERS, METERS, MILES;
   }

//OUTER CLASS CODE

   // static constants
   private static final double FEET_TO_MILES = 0.000189394;
   private static final double FEET_TO_METERS = 0.3048;
   private static final double FEET_TO_KILOMETERS = 0.0003048;
   private static final double FEET_TO_FEET = 1;
   private static final double METERS_TO_FEET = 3.28084;
   private static final double METERS_TO_MILES = 0.000621371;
   private static final double METERS_TO_KILOMETERS = 0.001;
   private static final double METERS_TO_METERS = 1;
   private static final double MILES_TO_FEET = 5280;
   private static final double MILES_TO_METERS = 1609.34;
   private static final double MILES_TO_KILOMETERS = 1.60934;
   private static final double MILES_TO_MILES = 1;
   private static final double KILOMETERS_TO_FEET = 3280.84;
   private static final double KILOMETERS_TO_METERS = 1000;
   private static final double KILOMETERS_TO_MILES = 0.621371;
   private static final double KILOMETERS_TO_KILOMETERS = 1;

   //OUTER CLASS CODE

   // member variables
   private E_AxisNative axisA, axisB, axisC;
   private E_Unit unitNative;

   private List<Coordinates> coordinatesCanon;
   private List<Coordinates> coordinatesNative;

   // ehst

   // constructor
   public WaypointPlanner(E_AxisNative axisA, E_AxisNative axisB, E_AxisNative axisC, E_Unit unitNative, InputStream instream) {
      if(axisA == null) throw new RuntimeException("axisA passed to WayPointPlanner constructor was null");
      if(axisB == null) throw new RuntimeException("axisB passed to WayPointPlanner constructor was null");
      if(axisC == null) throw new RuntimeException("axisC passed to WayPointPlanner constructor was null");
      if(unitNative == null) throw new RuntimeException("unitNative passed to WayPointPlanner constructor was null");
      if(instream == null) throw new RuntimeException("Input stream was null");

      checkForDistinctAxes(axisA, axisB, axisC);

      this.axisA = axisA;
      this.axisB = axisB;
      this.axisC = axisC;
      this.unitNative = unitNative;

      this.coordinatesCanon = new ArrayList<Coordinates>();
      this.coordinatesNative = new ArrayList<Coordinates>();
      // new line

      Scanner fin = new Scanner(instream);
      // read in points from file
      String[] line;
      while(fin.hasNext()) {
         line = fin.nextLine().split(",");
         double first = Double.parseDouble(line[0].trim());
         double second = Double.parseDouble(line[1].trim());
         double third = Double.parseDouble(line[2].trim());

         Coordinates temp = convertAxes(first, second, third, axisA, axisB, axisC, unitNative);
         coordinatesCanon.add(temp);
         coordinatesNative.add(new Coordinates(first, second, third));
      }
      // close inputstream
      try{
         instream.close();
      }catch(IOException e){
         System.out.println("Error closing input stream");
      }
   }

   private void checkForDistinctAxes(E_AxisNative axisA, E_AxisNative axisB, E_AxisNative axisC){
      if(axisA.isSameAxis(axisB) || axisA.isSameAxis(axisC) || axisB.isSameAxis(axisC))
         throw new RuntimeException("Axes must be distinct");
   }

   private Coordinates convertAxes(double first, double second, double third, E_AxisNative axisA, E_AxisNative axisB, E_AxisNative axisC, E_Unit unitNative){
      double x, y ,z;

      // transform axes
      if(axisA == E_AxisNative.X_PLUS || axisA == E_AxisNative.X_MINUS){
         x = first * axisA.getTransform();
      }else if(axisA == E_AxisNative.Y_PLUS || axisA == E_AxisNative.Y_MINUS){
         x = second * axisA.getTransform();
      }else{ // axisA equals Z_PLUS OR Z_MINUS
         x = third * axisA.getTransform();
      }

      if(axisB == E_AxisNative.X_PLUS || axisB == E_AxisNative.X_MINUS){
         y = first * axisB.getTransform();
      }else if(axisB == E_AxisNative.Y_PLUS || axisB == E_AxisNative.Y_MINUS){
         y = second * axisB.getTransform();
      }else{ // axisA equals Z_PLUS OR Z_MINUS
         y = third * axisB.getTransform();
      }

      if(axisC == E_AxisNative.X_PLUS || axisC == E_AxisNative.X_MINUS){
         z = first * axisC.getTransform();
      }else if(axisC== E_AxisNative.Y_PLUS || axisC == E_AxisNative.Y_MINUS){
         z = second * axisC.getTransform();
      }else{ // axisA equals Z_PLUS OR Z_MINUS
         z = third * axisC.getTransform();
      }

      // convert units
      if(unitNative == E_Unit.FEET){
         x *= FEET_TO_METERS;
         y *= FEET_TO_METERS;
         z *= FEET_TO_METERS;
      }else if(unitNative == E_Unit.MILES){
         x *= MILES_TO_METERS;
         y *= MILES_TO_METERS;
         z *= MILES_TO_METERS;
      }else if(unitNative == E_Unit.KILOMETERS){
         x *= KILOMETERS_TO_METERS;
         y *= KILOMETERS_TO_METERS;
         z *= KILOMETERS_TO_METERS;
      } // else no conversion is necessary

      return new Coordinates(x, y, z);
   }

   // getter methods
   public E_AxisNative getAxisA() {
      return this.axisA;
   }

   public E_AxisNative getAxisB() {
      return this.axisB;
   }

   public E_AxisNative getAxisC() {
      return this.axisC;
   }

   public E_Unit getUnitNative() {
      return this.unitNative;
   }

   // control methods
   public double calculateDistance(E_AxisCombinationNeutral axes, boolean isCanonicalElseNative, E_Unit unit) {
      if(axes == null) throw new RuntimeException("axes passed was null");
      if(unit == null) throw new RuntimeException("unit passed was null");

      double distance = 0.0;

      List<Double> distances = calculateDistances(axes, isCanonicalElseNative, unit);
      for(Double d: distances)
         distance += d;

      return distance;
   }

   public List<Double> calculateDistances(E_AxisCombinationNeutral axes, boolean isCanonicalElseNative, E_Unit unit) {
      if(axes == null) throw new RuntimeException("axes passed was null");
      if(unit == null) throw new RuntimeException("unit passed was null");
      ArrayList<Double> distance = new ArrayList<>();
      List<Coordinates> tempCoords = getCoordinates(isCanonicalElseNative, unit);
      for(int i = 0; i < tempCoords.size() - 1; i++) {
         distance.add(tempCoords.get(i).calcSubDistance(tempCoords.get(i + 1), axes));
      }
      return distance;
   }



   public List<Coordinates> getCoordinates(boolean isCanonicalElseNative, E_Unit unit)
   {
      if(unit == null) throw new RuntimeException("unit passed was null");

      List coords = new ArrayList<Coordinates>();
      if(isCanonicalElseNative)
      {
         switch(unit)
         {
            case FEET: coords = convertUnits(coordinatesCanon, METERS_TO_FEET);
               break;
            case METERS: coords = convertUnits(coordinatesCanon, METERS_TO_METERS);
               break;
            case MILES: coords = convertUnits(coordinatesCanon, METERS_TO_MILES);
               break;
            case KILOMETERS: coords = convertUnits(coordinatesCanon, METERS_TO_KILOMETERS);
         }
      }
      else
      {
         switch (getUnitNative())
         {
            case METERS:switch(unit)
            {
               case FEET: coords = convertUnits(coordinatesNative, METERS_TO_FEET);
                  break;
               case METERS: coords = convertUnits(coordinatesNative, METERS_TO_METERS);
                  break;
               case MILES: coords = convertUnits(coordinatesNative, METERS_TO_MILES);
                  break;
               case KILOMETERS: coords = convertUnits(coordinatesNative, METERS_TO_KILOMETERS);
            }
               break;
            case FEET:  switch(unit)
            {
               case FEET: coords = convertUnits(coordinatesNative, FEET_TO_FEET);
                  break;
               case METERS: coords = convertUnits(coordinatesNative, FEET_TO_METERS);
                  break;
               case MILES: coords = convertUnits(coordinatesNative, FEET_TO_MILES);
                  break;
               case KILOMETERS: coords = convertUnits(coordinatesNative, FEET_TO_KILOMETERS);
            }
               break;
            case MILES: switch(unit)
            {
               case FEET: coords = convertUnits(coordinatesNative, MILES_TO_FEET);
                  break;
               case METERS: coords = convertUnits(coordinatesNative, MILES_TO_METERS);
                  break;
               case MILES: coords = convertUnits(coordinatesNative, MILES_TO_MILES);
                  break;
               case KILOMETERS: coords = convertUnits(coordinatesNative, MILES_TO_KILOMETERS);
            }
               break;
            case KILOMETERS: switch(unit)
            {
               case FEET: coords = convertUnits(coordinatesNative, KILOMETERS_TO_FEET);
                  break;
               case METERS: coords = convertUnits(coordinatesNative, KILOMETERS_TO_METERS);
                  break;
               case MILES: coords = convertUnits(coordinatesNative, KILOMETERS_TO_MILES);
                  break;
               case KILOMETERS: coords = convertUnits(coordinatesNative, KILOMETERS_TO_KILOMETERS);
            }
               break;
         }
      }
      return coords;
   }

   private List convertUnits(List inList, double conversion)
   {
      List<Coordinates> convertedList = new ArrayList<Coordinates>();
      double newFirst, newSecond, newThird;
      for(int x = 0; x < inList.size(); x++)
      {
         Coordinates coord = (Coordinates)inList.get(x);
         newFirst = coord.first * conversion;
         newSecond = coord.second * conversion;
         newThird = coord.third * conversion;
         convertedList.add(new Coordinates(newFirst, newSecond, newThird));
      }
      return convertedList;
   }





}