package course;
import java.util.*;

public class Course implements Iterable<Student> {
	private ArrayList<Student> list;
	
	public Course() {
		list = new ArrayList<Student>();
	}
	
	// post: add student into the list
	public void add(Student student) {
		list.add(student);
	}
	
	// post: return new CourseIterator inner class
	public Iterator<Student> iterator() {
		return new CourseIterator();
	}
	
	private class CourseIterator implements Iterator<Student> {
		private int position;
		
		public CourseIterator() {
			position = 0;
		}

		// post: check if there was another student next to the list
		@Override
		public boolean hasNext() {
			if(position >= list.size() || list.get(position) == null) {
				return false;
			} else {
				return true;
			}
		}

		// post: increment the index after saving the current student, then returns that
		//			student in the list
		@Override
		public Student next() {
			Student next = list.get(position);
			position++;
			return next;
		}
	}
}
