// Simple factory class to direct which shape is being created.
package shape;

public class ShapeFactory {
	
	public static Shape createShape(int height, int width, String type) {
		if(type.equalsIgnoreCase("square")) {
			return new Square(height, width, "Square");
		} else if(type.equalsIgnoreCase("rectangle")) {
			return new Rectangle(height, width, "Rectangle");
		} else if(type.equalsIgnoreCase("triangle")) {
			return new Triangle(height, width, "Triangle");
		} else if(type.equalsIgnoreCase("circle")) {
			return new Circle(height, "Circle");
		} else {
			return null;
		}
	}
}
