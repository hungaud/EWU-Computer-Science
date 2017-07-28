// Hung Auduong
// CSCD 349
// Lab 4
//
// refactoring the code to a factory pattern with shapes.
//

import java.util.*;
import shape.*;


public class ShapeTester {

	public static void main(String[] args) {
		ArrayList<Shape> shapes = new ArrayList<Shape>();
		try {
			shapes.add(ShapeFactory.createShape(5, 5,"Circle"));
			shapes.add(ShapeFactory.createShape(5, 10, "Triangle"));
			shapes.add(ShapeFactory.createShape(5, 6, "Triangle"));
			shapes.add(ShapeFactory.createShape(9, 2, "rectangle"));
			shapes.add(ShapeFactory.createShape(1, 9, "rectangle"));
			shapes.add(ShapeFactory.createShape(4, 4, "circle"));
			shapes.add(ShapeFactory.createShape(11, 11, "square"));
			shapes.add(ShapeFactory.createShape(5, 5, "square"));
		}
		catch(Exception e) {
			System.err.println(e);
		}
		System.out.println("Before the sorting: " + "\n");
		for(Shape shape: shapes) {
			System.out.println(shape.getName() + " has an area of " + shape.calculateArea());
		}
		System.out.println("\n" + "After the sorting: " + "\n");
		Collections.sort(shapes);
		for(Shape shape: shapes) {
			System.out.println(shape.getName() + " has an area of " + shape.calculateArea());
		}
		
	}
	
}
