// Eye of sauron class looking out for the agent of good and notify his
// followers.

import java.util.*;

public class EyeOfSauron extends Observable {
	private int men;
	private int elves;
	private int dwarves;
	private int hobbits;
	
	//post: empty constructor
	public EyeOfSauron() {	
	}
	
	// post: take the number of each enemy that was passed in the parameter
	//		  and then updates the amount of enemy that the eye sees. after
	//		  the eye would then update so that the count of enemies would update
	public void setEnemies(int hobbits, int elves, int dwarves, int men) {
		this.men = men;
		this.elves = elves;
		this.dwarves = dwarves;
		this.hobbits = hobbits;
		updateEnemies();
	}
	
	// post: update the enemies then notify the observers so that the observers
	//			would know how much enemies there are
	private void updateEnemies() {
		setChanged();
		notifyObservers();
	}
	
	// post: return the number of men seen
	public int getMen() {
		return men;
	}
	
	// post: return the number of elves seen
	public int getElves() {
		return elves;
	}
	
	// post: return the number of dwarves seen
	public int getDwarves() {
		return dwarves;
	}
	
	// post: return the number of hobbits seen
	public int getHobbits() {
		return hobbits;
	}
}
