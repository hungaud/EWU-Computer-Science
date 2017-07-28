package treePackage;

public class Star extends DecorateDecorator {

	private Tree tree;
	
	 private Star(Tree tree) {
		this.tree = tree;
	}
	
	// post: static method that passed in a tree. it uses the singleton pattern
	//			to check if there's already a star, if there is, it wont add on
	//			another star, but instead let the user know. if it doesnt have one
	// 		then it will create a new star object to add onto the tree.
	public static Tree getStar(Tree tree) {
		if(!tree.getDescription().contains("a Star")) {
			tree = new Star(tree);
		} else {
			System.out.println("You tried to add on another star; Tree already has one!");
		}
		return tree;
	}
	
	// post: returns the description of this class' decoration and add
	//			it onto whats already on the tree
	public String getDescription() {
		return tree.getDescription() + ", a Star";
	}
	
	// post: return cost of tree + cost of this decoration
	public double cost() {
		return 4 + tree.cost();
	}
}
