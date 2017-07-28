/******************************************************************************
*
*  The purpose of this program is to calculate a customer's water bill when
*  given their customer code, begining meter reading, and ending meter reading.
*
*  The formulas used to calculate the bills are explained at the CALCULATIONS
*  section.
*
******************************************************************************/

import java.util.Scanner;
import java.text.DecimalFormat;

public class Lab7
{
   /***************************************************************************
   *
   *  DECLARE CONSTANTS; for use in water bill calculations
   *
   ***************************************************************************/

   public static final double FLAT_R = 5, FLAT_C = 1000, FLAT_I_SUB4SUB4 =
                              1000, FLAT_I_SUB4OVER4 = 2000, PER_GAL_R =
                              0.0005, PER_GAL_C = 0.00025, PER_GAL_I = 0.00025,
                              METER_MAX = 999999999;

   public static void main(String [] args)
   {

      /************************************************************************
      *
      *  DECLARE VARIABLES AND OBJECTS
      *
      *  Note meter readings are taken in tenths of a gallon.
      *
      ************************************************************************/

      Scanner kb = new Scanner(System.in);

      /* Since we cannot bill partial cents, this decimal format puts the bill
      in a logical form. */
      DecimalFormat fmt = new DecimalFormat("#,###.00");

      int meterBegin, meterEnd;
      double gallonsUsed, bill;
      char custCode = '?';

      /************************************************************************
      *
      *  ACCEPT USER INPUT
      *
      ************************************************************************/

      System.out.println("Please enter the customer code:");
      custCode = kb.nextLine().charAt(0);

      System.out.println("Please enter the begining meter reading:");
      meterBegin = kb.nextInt();

      System.out.println("Please enter the ending meter reading:");
      meterEnd = kb.nextInt();

      kb.nextLine();

      /************************************************************************
      *
      *  CALCULATIONS:
      *
      *  Since meter readings are taken in tenths of a gallon, once the
      *  difference in the meters has been calculated we must divide by 10.0.
      *  Note that if we divide by 10 then integer arithmetic will occur and
      *  the results will be inaccurately truncated.
      *
      *  Since the meters max out at 999999999 we also must account for when
      *  it rolls over. Thus if the ending meter reading is less than the
      *  initial reading we know it has rolled over and total gallons used
      *  are equal to the meter's max reading minus the initial plus the final.
      *
      *  Residential customers have a fixed amount of $5 plus a price per
      *  gallon of $0.0005.
      *
      *  Commercial customers have a fixed rate of $1000 for under 4 million
      *  gallons and an additional price per gallon charge of $0.00025 for
      *  anything above that.
      *
      *  Industrial customers have a fixed rate of $1000 for under 4 million
      *  gallons, a different fixed rate of $2000 for between 4 and 10 million
      *  gallons, and an additional price per gallon charge of $0.00025 for
      *  anything over 10 million.
      *
      ************************************************************************/

      // *****Gallons Used*****
      if (meterBegin <= meterEnd)
         gallonsUsed = (meterEnd - meterBegin) / 10.0;
      else
         gallonsUsed = (METER_MAX - meterBegin + meterEnd) / 10.0;

      // *****Bill*****
      if (custCode == 'r' || custCode == 'R')
      {
         bill = FLAT_R + PER_GAL_R * gallonsUsed;
      } // End if
      else if (custCode == 'c' || custCode == 'C')
      {
         if (gallonsUsed <= 4000000)
         {
            bill = FLAT_C;
         } // End if
         else
         {
            bill = FLAT_C + PER_GAL_C * (gallonsUsed - 4000000);
         } // End else
      } // End else if
      else
      {
         if (gallonsUsed <= 4000000)
         {
            bill = FLAT_I_SUB4SUB4;
         } // End if
         else if (gallonsUsed <= 10000000)
         {
            bill = FLAT_I_SUB4OVER4;
         } // End else if
         else
         {
            bill = FLAT_I_SUB4OVER4 + PER_GAL_I * (gallonsUsed - 10000000);
         } // End else
      } // End else

      /************************************************************************
      *
      *  PRINT RESULTS
      *
      ************************************************************************/

      System.out.printf("The customer's code is: %c\n", custCode);

      System.out.printf("The customer's begining meter reading is: %d\n",
                        meterBegin);

      System.out.printf("The customer's ending meter reading is: %d\n",
                        meterEnd);

      System.out.printf("The customer used %.1f gallons of water.\n",
                        gallonsUsed);
      /* Since meters are read in tenths of a gallon it would be incorrect to
      print any additional digits. */

      System.out.printf("The customer's bill is: $%s\n", fmt.format(bill));

   } //end main
} // end class
