package treePackage;

public class Ruffles extends DecorateDecorator {
	
	private Tree tree;
	
	// post: constructor that pass in a tree
	public Ruffles(Tree tree) {
		this.tree = tree;
	}
	
	// post: returns the description of this class' decoration and add
	//			it onto whats already on the tree
	public String getDescription() {
		return tree.getDescription() + ", Ruffles";
	}
	
	// post: return the cost for the tree so far with the cost of this decoration
	public double cost() {
		return 1 + tree.cost();
	}
	
}
