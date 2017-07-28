//bad guys class

import java.util.*;

public class BadGuy implements Observer{
	private EyeOfSauron eye;
	private String antagonist;

	// post: takes in the eye of sauron and the name of the bad guy who
	// 		sides with sauron and then add this observer into the list of
	//			observers that will be notified of how many agent of goods
	//			that was seen by the eye
	public BadGuy(EyeOfSauron eye, String antagonist) {
		this.eye = eye;
		this.antagonist = antagonist;
		eye.addObserver(this);
	}
	
	// post: updates the amount of each good guys
	@Override
	public void update(Observable o, Object arg) {
		if(o instanceof EyeOfSauron) {
			display();
		}
	}
	
	// post: the observer is no longer being updated on how many good guys
	//			there are thus being "defeated"
	public void defeated() {
		eye.deleteObserver(this);
		System.out.println(antagonist + " was defeated!");
	}
	
	// post: display a message of how many of good guys there are in respect 
	//			to the observer
	public void display() {
		System.out.println(antagonist + " knows there are " + eye.getHobbits() + " Hobbits, "
						  		+ eye.getElves() + " eleves, " + eye.getDwarves() + " dwarves, "
						  		+ eye.getMen() + " men");
	}

}
