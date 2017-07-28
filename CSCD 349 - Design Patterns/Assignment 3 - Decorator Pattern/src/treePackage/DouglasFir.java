package treePackage;

public class DouglasFir extends Tree {

	// post: constructor that describe what tree is use
	public DouglasFir() {
		description = "Douglas Fir decorated with";
	}
	
	// post: returns the cost of this tree;
	public double cost() {
		return 30;
	}
}
