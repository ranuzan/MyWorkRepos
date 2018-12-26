package Enigma;

public class Main 
{
	
	public static boolean SANITYCHECK=true;
	
	
	public static void main(String[] args) {

		CompleteEnigma CE = new CompleteEnigma();

		
		// TASK 4 complete enigma run examples
		/*
		CE.EncryptEnigma();// turns "ENIGMA" -> "QGELID"
		CE.DecryptEnigma();// turns "QGELID" -> "ENIGMA"
		CE.EncryptKaxmnf();// turns "KAXMNF" -> "ENIGMA"
		CE.EncryptTuring();// turns "TURING" -> "ACELKT"
		CE.EncryptPeace();// turns "PEACE" -> "ISWAR"
		CE.EncryptPeaceWithPB();// turns "PEACE" -> "IRJZU"
		CE.EncryptDor();// turns "DOR" -> "MLD"
		CE.EncryptMLD();// turns "MLD" -> "DOR"
		*/
		

		// TASK 5 - double encryption
		 //CE.DecryptTask5();

		// TASK 6 - performance test
		 //histogram();
		 
		 //User input machine build
		 //CE.AcceptUserInput();
	}

	public static void histogram() {
		for (int i = 0; i < 10000; i++) {
			CompleteEnigma CE = new CompleteEnigma();
			CE.EncryptPeaceWithPB();
		}
	}
}


