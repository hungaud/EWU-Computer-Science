// Hung Auduong
// 10/04/16
// CSCD 349
// LAB 2
//
// This class test the Sauron's eye

public class TestSauronEye {
		
	public static void main(String[] args) {
		
		int numHobbits = 1;
		int numElves = 1;
		int numDwarves = 2;
	   int numMen = 0;
		
		EyeOfSauron eye = new EyeOfSauron();
      BadGuy saruman = new BadGuy(eye, "Saruman");
      BadGuy witchKing= new BadGuy(eye, "Witch King");
        
      eye.setEnemies(numHobbits, numElves, numDwarves, numMen); 
      saruman.defeated(); 
        
      numHobbits = 6;
      numElves = 66;
      numDwarves = 55;
      numMen = 5;
      eye.setEnemies(numHobbits, numElves, numDwarves, numMen); 

    }
}


