using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MissileCommand {
   class Missile : ObjectType {
      double targetX;
      double targetY;

      double startX;
      double startY;

      double currentX;
      double currentY;

      float speed;
      double dX = 0;
      double dY = 0;
      int launchTime;
      Color color;
      Color headColor;
      bool split;
      bool destoryed;




      public Missile(double toX, double toY, double posX, double posY, float speed, Color color, Color headColor, int launchTime, bool split) {
         targetX = toX;
         targetY = toY;
         startX = posX;
         startY = posY;
         this.launchTime = launchTime;

         this.speed = speed;
         this.color = color;
         this.headColor = headColor;
         this.split = split;
         this.destoryed = false;
         this.currentX = posX;
         this.currentY = posY;

         dX = (targetX - startX) / 200;
         dY = (targetY - startY) / 200;
      }



      public double getStartX {
         get {
            return startX;
         }

      }
      public double getStartY {
         get {
            return startY;
         }
      }


      public double getTargetX {
         get {
            return targetX;
         }
      }

      public double getTargetY {
         get {
            return targetY;
         }
      }

      public double currX {
         get {
            return currentX;
         }
      }
      public double currY {
         get {
            return currentY;
         }
      }

      public double slopeX {
         get {
            return dX;
         }
         set {
            dX = value;
         }
      }

      public double slopeY {
         get {
            return dY;
         }
         set {
            dY = value;
         }
      }

      public int getLaunchTime {
         get {
            return launchTime;
         }
      }

      public bool isDestroyed {
         get {
            return destoryed;
         }
      }

      public Color getColor {
         get {
            return color;
         }
      }

      public Color getHeadColor {
         get {
            return headColor;
         }
      }

    

      public void updateSlope() {
         currentX += dX * speed;
         currentY += dY * speed;
      }




      public void Destroy() {
         this.destoryed = true;
         //make explosion
      }
   }
}
