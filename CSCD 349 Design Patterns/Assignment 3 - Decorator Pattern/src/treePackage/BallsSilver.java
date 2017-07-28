package treePackage;

public class BallsSilver extends DecorateDecorator {
	
	private Tree tree;
	
	// post: constructor that has a tree object passed into into it and sets
	//			the tree.
	public BallsSilver(Tree tree) {
		this.tree = tree;
	}
	
	// post: get the description of the tree so far and add on 
	//			the decoration of this class onto the tree;
	public String getDescription() {
		return tree.getDescription() + ", Silver Balls";
	}
	
	// post: return the cost of the tree so far added onto the cost of this decoration
	public double cost() {
		return 3 + tree.cost();
	}
}
