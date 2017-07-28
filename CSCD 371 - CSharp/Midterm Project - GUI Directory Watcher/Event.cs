using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject {
   public class Event {

      public string EventHappened {
         get; 
         set;
      }

      public string Extension {
         get; 
         set;
      }

      public string Name {
         get; 
         set;
      }

      public string OldName {
         get; 
         set;
      }

      public string Time {
         get;
         set;
      }

      public string Location {
         get; 
         set;
      }

      public Event() {
         EventHappened = "";
         Extension = "";
         Name = "";
         OldName = "";
         Time = "";
         Location = "";
      }
   }
}
