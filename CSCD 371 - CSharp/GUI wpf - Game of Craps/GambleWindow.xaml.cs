using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Craps {
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window {
      private int balance;
      Player p;

      public Window1(Player p) {
         InitializeComponent();
         this.p = p;
      }


      private void reset() {
         betBox.Text = "";
      }

      public int getBalance {
         get {
            return balance;
         }
      }

      private void button_Click(object sender, RoutedEventArgs e) {
         int parsedValue;
         if (int.TryParse(betBox.Text, out parsedValue) && int.Parse(betBox.Text) > 0) {
            balance = int.Parse(betBox.Text);
            p.balance = balance;
            this.Close();
         } else {
            MessageBox.Show("Please put a valid input!");
         }
      }
   }
}
