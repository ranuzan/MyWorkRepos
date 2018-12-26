package Enigma;

/**
 * 
 * @author ranuzan
 * @class Reflector 
 * represent a Calibrated Enigma machine with all the parts adjusted and in place 
 */
public class CalibratedEnigma {
	
	Rotor rightRotor;
	Rotor middleRotor;
	Rotor leftRotor;
	Reflector reflector;
	PlugBoard plugBoard;
	
	/**
	 * 
	 * @param right - right rotor of the enigma machine
	 * @param middle - middle rotor of the enigma machine
	 * @param left - left rotor of the enigma machine
	 * @param pb - plugBoard of the enigma machine
	 * @param ref - reflector of the enigma machine
	 */
	CalibratedEnigma(Rotor right , Rotor middle, Rotor left , PlugBoard pb , Reflector ref)
	{
		rightRotor = right;
		middleRotor = middle;
		leftRotor = left;
		plugBoard = pb;
		reflector = ref;
	}
	
	/**
	 * CheckStepping function checks if turnover notch is needed 
	 */
	public void CheckStepping()//implementing given stepping algorithm 
	{
		if(rightRotor.CheckNotch() || middleRotor.CheckNotch())
		{
			if(middleRotor.CheckNotch())
				leftRotor.AdvenceOffset();
			middleRotor.AdvenceOffset();
		}
		rightRotor.AdvenceOffset();
	}
	
	/**
	 * @param c - a char input to check if needs to be changed in PB
	 * @return returns the result of the entire machine char encryption using all its parts
	 */
	public char Encrypt(char c)
	{
		char result;
		CheckStepping();//check notches
		
		//calculate result going Plugboard->RIGHT->MIDDLE->LEFT->REFLECTOR->LEFT->MIDDLE->RIGHT->Plugboard
		result = plugBoard.Encrypt(c);
		result = rightRotor.Encrypt(result,true);
		result = middleRotor.Encrypt(result,true);
		result = leftRotor.Encrypt(result,true);
		result = reflector.Encrypt(result);
		result = leftRotor.Encrypt(result,false);
		result = middleRotor.Encrypt(result,false);
		result = rightRotor.Encrypt(result,false);
		result = plugBoard.Encrypt(result);
		return result;
	}

	public void EncryptChar(char c)
	{
		 System.out.printf("%c",Encrypt(c));
	}
	
	public void EncryptString(String s) 
	{
		for(int i = 0 ; i<s.length();i++)
			{
				 System.out.printf("%c",Encrypt(s.charAt(i)));
			}
		System.out.printf("\n");
			
	}

}
