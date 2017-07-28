using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand {
   class Explosion : ObjectType {

      private bool destroyed;
      private int size;

      private int x;
      private int y;


      public Explosion(int posX, int posY) {
         x = posX;
         y = posY;
         this.destroyed = false;
         this.size = 2;
      }

      public int getX() {
         return x;
      }

      public int getY() {
         return y;
      }

      public bool isDestroy {
         get {
            return destroyed;
         }
         set {
            this.destroyed = value;
         }
      }

      public bool Contains(Rectangle rect) {
         Point center = new Point(this.Bounds.Width / 2, this.Bounds.Height / 2);
         if (rect.Contains(center))
            return true;
         Point upperLeft = new Point(rect.X, rect.Y);
         Point upperRight = new Point(rect.X + rect.Width, rect.Y);
         Point lowerLeft = new Point(rect.X, rect.Y + rect.Height);
         Point lowerRight = new Point(rect.X + rect.Width, rect.Y + rect.Height);


         //Point center = Bounds.Center;

         if (Distance(upperLeft, center) < this.getSize.X / 2)
            return true;
         if (Distance(upperRight, center) < this.getSize.X / 2)
            return true;
         if (Distance(lowerLeft, center) < this.getSize.X / 2)
            return true;
         if (Distance(lowerRight, center) < this.getSize.X / 2)
            return true;

         return false;
      }

      public int getSizeWH() {
         return this.size;
      }

      public void setSize(int size) {
         this.size = size;
      }

      


   }
}
