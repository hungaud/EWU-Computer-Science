package treePackage;

public class Lights extends DecorateDecorator {
	
	private Tree tree;
	
	// post: constructor that has a tree object passed into into it and sets
	//			the tree.
	public Lights(Tree tree) {
		this.tree = tree;
	}
	
	// post: returns the description of this class' decoration and add
	//			it onto whats already on the tree
	public String getDescription() {
		return tree.getDescription() + ", Lights";
	}
	
	public double cost() {
		return 5 + tree.cost();
	}
}
