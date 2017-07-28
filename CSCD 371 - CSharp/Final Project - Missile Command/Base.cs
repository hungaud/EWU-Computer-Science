using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissileCommand {
   class Base {
      int ammo;
      bool destoryed;

      public Base(int num) {
         this.ammo = num;
         this.destoryed = false;
      }

      private void Destroy() {
         this.destoryed = true;
         this.ammo = 0;
      }
   }
}
