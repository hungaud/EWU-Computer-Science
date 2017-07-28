using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand {
   public abstract class ObjectType {
      Point pos;
      Point size;

      public Rectangle Bounds {
         get {
            return new Rectangle(pos.X, pos.Y, size.X, size.Y);
         }
      }

      public Point getSize {
         get {
            return this.size;
         }
      }

      public float Distance(Point pos, Point to) {
         return (float) Math.Sqrt(Math.Pow(pos.X - to.X, 2) + Math.Pow(pos.Y - to.Y, 2));
      }

      //public abstract void Update(List<ObjectType> objects);
   }
}
