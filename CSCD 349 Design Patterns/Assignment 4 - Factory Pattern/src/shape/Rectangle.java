// concrete rectangle class

package shape;

public class Rectangle extends Shape implements Comparable<Shape> {

	public Rectangle(int height, int width, String type) {
		super(height, width, type);
	}
	
	@Override
	public double calculateArea() {
		return height * width;
	}
}
