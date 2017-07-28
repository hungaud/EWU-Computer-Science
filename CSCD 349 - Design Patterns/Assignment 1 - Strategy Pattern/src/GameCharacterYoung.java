public class GameCharacterYoung extends GameCharacter {
	
	public GameCharacterYoung() {
		 this.chosenGuitar = new GibsonFlyingV();
		 this.chosenSolo = new Smash();
	}
	
	public void display() {
		System.out.println("I just go where the guitar takes me -Angus Young");
	}
}
