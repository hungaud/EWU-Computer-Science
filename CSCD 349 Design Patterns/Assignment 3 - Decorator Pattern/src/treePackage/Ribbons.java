package treePackage;

public class Ribbons extends DecorateDecorator {
	
	private Tree tree;
	
	public Ribbons(Tree tree) {
		this.tree = tree;
	}
	
	// post: returns the description of this class' decoration and add
	//			it onto whats already on the tree
	public String getDescription() {
		return tree.getDescription() + ", Ribbons";
	}
	
	public double cost() {
		return 2 + tree.cost();
	}
}
