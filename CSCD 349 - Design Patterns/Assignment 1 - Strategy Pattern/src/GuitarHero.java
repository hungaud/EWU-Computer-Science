// Hung Auduong
// 9/26/16
// Thomas Capaul
// Strategy Pattern
//
// Main class of Guitar Hero. You can pick any of the 3 guitarist. each of those guitarist have
// a default guitar and solo. which could be change.

public class GuitarHero {

	// post: different type of test to show the 3rd playable character with
   // default guitar and default solo. which can be changed to any other
   // guitar or solo behavior
	public static void main(String[] args) {
		GameCharacter player1 = new GameCharacterSlash(); 
		GameCharacter player2 = new GameCharacterHendrix();
     
		player1.display();
		player2.display();
		player1.playGuitar();
		player2.playGuitar();
		player1.playSolo();
		player2.playSolo();
		player1.setGuitar(new Fender());
		player1.playGuitar();
		
		GameCharacter player3 = new GameCharacterYoung();
		player3.display();
		player3.playGuitar();
		player3.playSolo();
		player3.setSolo(new Fire());
		player3.playSolo();
        
        
        
	}

}
