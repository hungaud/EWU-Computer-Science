public class GameCharacterHendrix extends GameCharacter {
	
	public GameCharacterHendrix() {
		this.chosenGuitar = new Fender();
		this.chosenSolo = new Jump();
	}
	
	public void display() {
		System.out.println("Excuse me while I kiss the sky -Jimmy Hendrix");
	}
}
