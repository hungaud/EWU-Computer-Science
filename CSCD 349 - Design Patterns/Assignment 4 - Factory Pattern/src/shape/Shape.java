// abstract shape class
package shape;

public abstract class Shape implements Comparable<Shape> {
	
	protected int height;
	protected int width;
	protected String name;
	
	
	// post: constructor for shape class
	public Shape(int height, int width, String name) {
		this.height = height;
		this.width = width;
		this.name = name;
	}

   // post: calculate the area of the shape so we can sort later
	public abstract double calculateArea();
	
   // post: return the name of the Shape object so we can sort later
	public String getName() {
		return name;
	}
	
   // post: compare this shape object to the other shape object.
   //       it first compares them by name, if they are the same
   //       name then it will compare both by the area.
	public int compareTo(Shape other) {
		if(!this.name.equals(other.getName())) {
			return this.name.compareTo(other.getName());
		}
		return (int) (this.calculateArea() - other.calculateArea());
		
	}
}
