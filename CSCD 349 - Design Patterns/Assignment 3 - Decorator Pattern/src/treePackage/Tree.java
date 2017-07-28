// Tree class

package treePackage;

public abstract class Tree {
	protected String description;
	
	// post: empty constructor
	public Tree() {
	}

	// post: constructor that pass a type of tree as the base
	public Tree(String treeType) {
		description = treeType;
	}
	
	// post:	returns description of whats on the tree
	public String getDescription() {
		return description;
	}
	
	// post: calls the cost class
	public abstract double cost();
}
