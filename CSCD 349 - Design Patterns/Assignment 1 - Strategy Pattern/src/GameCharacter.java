// Abstract class for characters, guitars, and solos.

public abstract class GameCharacter {
	protected Guitar chosenGuitar;
	protected Solo chosenSolo;
	
	// post: empty constructor
	public GameCharacter() {
	}
	
	// post: print out a unique line for each characters
	public void display() {
	}
	
	// post: choose the guitar
	public void playGuitar() {
		chosenGuitar.playTheGuitar();
	}
	
	// post: choose the solo
	public void playSolo() {
		chosenSolo.playTheSolo();
	}
	
	// post: set the character's guitar to another guitar aside from the default one
	public void setGuitar(Guitar g) {
		chosenGuitar = g;
	}
	
	// post: set the character's solo act to another solo aside from the default one
	public void setSolo(Solo s) {
		chosenSolo = s;
	}
}
