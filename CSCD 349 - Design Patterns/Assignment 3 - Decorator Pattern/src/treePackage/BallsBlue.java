package treePackage;

public class BallsBlue extends DecorateDecorator {
	private Tree tree;
	
	// post: constructor that has a tree object passed into into it and sets
	//			the tree.
	public BallsBlue(Tree tree) {
		this.tree = tree;
	}
	
	// post: returns the description of this class' decoration and add
	//			it onto whats already on the tree
	public String getDescription() {
		return tree.getDescription() + ", Blue Balls";
	}
	
	public double cost() {
		return 2 + tree.cost();
	}
}
