// concrete Circle class

package shape;

public class Circle extends Shape implements Comparable<Shape> {

	public Circle(int diameter, String type) {
		super(diameter, diameter, type);
	}

	@Override
	public double calculateArea() {
		return Math.PI * height * width;
	}
}
