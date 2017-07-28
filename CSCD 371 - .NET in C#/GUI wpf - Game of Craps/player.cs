using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps {
   public class Player {

      private bool isBetting;
      private int betAmount;

      public Player() {
         isBetting = false;
      }

      public Player(bool check) {
         isBetting = true;

      }
      
      public bool isBet() {
         return isBetting;
      }

      public int balance {
         get {
            return betAmount;
         }
         set {
            betAmount = value;
         }
      }

   }
}
