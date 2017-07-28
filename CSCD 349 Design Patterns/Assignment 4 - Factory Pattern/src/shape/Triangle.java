// concrete triangle class

package shape;

public class Triangle extends Shape implements Comparable<Shape> {

	public Triangle(int height, int width, String type) {
		super(height, width, type);
	}

	@Override
	public double calculateArea() {
		return (height * width) / 2;
	}
}
