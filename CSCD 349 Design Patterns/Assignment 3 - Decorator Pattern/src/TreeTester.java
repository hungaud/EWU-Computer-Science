// Hung Auduong
// 10/12/16
// CSCD 349
// LAB 3
//
// This class test the tree decorating assignment

import treePackage.*;

public class TreeTester {

		public static void main(String[] args) {
			Tree mytree = new ColoradoBlueSpruce();
			mytree = Star.getStar(mytree);
			mytree = new Ruffles(mytree);
			mytree = Star.getStar(mytree); //this is problematic and should not be permitted
			
			mytree = new Ruffles(mytree);
			printtree(mytree);
			
		}
		
		public static void printtree(Tree mytree) {
			System.out.println(mytree.getDescription() + " cost $" + String.format("%.2f", mytree.cost()));
		}
}
