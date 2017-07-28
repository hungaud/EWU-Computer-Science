package treePackage;

public class LEDs extends DecorateDecorator {
	
	private Tree tree;
	
	// post: constructor that has a tree object passed into into it and sets
	//			the tree.
	public LEDs(Tree tree) {
		this.tree = tree;
	}
	
	// post: returns the description of this class' decoration and add
	//			it onto whats already on the tree
	public String getDescription() {
		return tree.getDescription() + ", LEDs";
	}
	
	public double cost() {
		return 10 + tree.cost();
	}
}
