public class GameCharacterSlash extends GameCharacter {
	
	public GameCharacterSlash() {
		this.chosenGuitar = new Gibson();
		this.chosenSolo = new Fire();
	}
	
	public void display() {
		System.out.println("Guitars are like women -Slash");
	}
}
