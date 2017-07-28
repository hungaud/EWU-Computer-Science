using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps {
   public class Die {
      int die1;
      int die2;
      int sum;

      public int dieRoll1 {
         get {
            return die1;         
         }
      }

      public int dieRoll2 {
         get {
            return die2;
         }
      }

      public int getSum {
      
      get {
            return sum;
         }
      }

      public void roll() {
         Random r = new Random();
         this.die1 = r.Next(1, 7);
         this.die2 = r.Next(1, 7);
         this.sum = die1 + die2;
      }

   }
}
