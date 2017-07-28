// concrete square class

package shape;

public class Square extends Shape implements Comparable<Shape> {

	public Square(int height, int width, String type) {
		super(height, width, type);
	}

	@Override
	public double calculateArea() {
		return height * width;
	}
}
