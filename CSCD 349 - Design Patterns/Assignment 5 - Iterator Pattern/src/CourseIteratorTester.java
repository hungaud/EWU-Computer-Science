// Hung Auduong
// CSCD 349
// Lab 5
//
// Iterator pattern with courses and students.
//


import course.*;
import java.util.Iterator;

class CourseIteratorTester {
	
	public static void main(String[] args) {
		Course course = new Course();
		course.add(new Student("Chad"));
		course.add(new Student("Tyrone"));
		course.add(new Student("Pablo"));
		course.add(new Student("Hung"));
		System.out.println("Test using ForEach loop \n");
		for (Student s : course) {
			System.out.println(s.getName());
		}
		System.out.println("\nIteration Test \n");
		Iterator<Student> itr = course.iterator();
		while (itr.hasNext()) {
			System.out.println(itr.next().getName());
		}
	}
}