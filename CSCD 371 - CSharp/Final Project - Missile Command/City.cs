using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissileCommand {
   class City : ObjectType {

      private bool destroyed;
      private double x;
      private double y;

      public City(double x, double y) {
         this.x = x;
         this.y = y;
         this.destroyed = false;
      }

      public double getX {
         get {
            return x;
         }
      }
      public double getY {
         get {
            return y;
         }
      }

      public bool isDestroy {
         get {
            return destroyed;
         }
         set {
            this.destroyed = value;
         }
      }


   }
}
