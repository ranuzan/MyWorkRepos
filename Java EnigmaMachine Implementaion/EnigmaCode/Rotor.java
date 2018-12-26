package Enigma;
/**
 * 
 * @author ranuzan
 * @class Rotor 
 * represent a Rotor in an enigma machine
 * Alphabet string is a utility string 
 * forwardMutation represent the forward Mutation in the enigma machine rotor
 * reverseMutation represent the reverse Mutation in the enigma machine rotor
 * ringSetting represent the initial ring setting of the rotor
 * ringOffset represent the initial ring offset of the rotor
 * notch represent the turnover notch of the rotor
 */
public class Rotor {
	

	private String forwardMutation;
	private String reverseMutation;
	private int ringSetting=-1;
	private int ringOffset=-1;
	private char notch = '*';
	
	public static final int NUM_OF_LETTERS=26;//util
	public String Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";//util
	/**
	 * rotor ctor
	 * @param mutation - forwards mutation
	 * @param ringset - initial ring setting
	 * @param ringoff - initial ring offset
	 * @param ntch - initial notch turnover
	 */
	Rotor(String mutation , int ringset , int ringoff,char ntch)
	{
		char[] reverseMutationArray = new char[NUM_OF_LETTERS] ;//array for building reverse mutation
		if(Main.SANITYCHECK) 
		{
			if(mutation.length()!=NUM_OF_LETTERS)//input test
				System.out.println("wrong mutation length");
			for(int i =0 ;i<mutation.length();i++)
			{
				char c = mutation.charAt(i);
				StringBuilder s = new StringBuilder(mutation);
				if(Character.isLetter(c))
				{
					if(Character.isLowerCase(c))
						s.setCharAt(i,Character.toUpperCase(c));
				}
				else System.out.println("there can only be letters in mutation string");
			}
			for (int i = 0; i < mutation.length(); i++) 
			{	
	            for (int j = i + 1; j < mutation.length(); j++) 
	                if (mutation.charAt(i) == mutation.charAt(j)) 
	    				System.out.println("duplicate charchters in mutation string");
			}
			
		}
			
		//assigning given values
		this.ringOffset = ringoff;		this.ringSetting = ringset;		
		this.notch = ntch;				this.forwardMutation = mutation;
		
		//building reverse mutation
		for(int i = 0; i<NUM_OF_LETTERS ; i++)
		{
			char currentLetter = this.forwardMutation.charAt(i);
			reverseMutationArray[CharToNum(currentLetter)-1] = Alphabet.charAt(i);
		}
		this.reverseMutation = String.valueOf(reverseMutationArray)	;
	}
	/**
	 * Permutation function calculates the rotor output for a given char input
	 * @param c given char input
	 * @return resulting char from the forward mutation
	 */
	public char Permutation(char c)
	{			
		return this.forwardMutation.charAt(c-65);
	}
	
	/**
	 * ReversePermutation function calculates the rotor output for a given char input
	 * @param c given char input
	 * @return resulting char from the reverse mutation
	 */
	public char ReversePermutation(char c)
	{
		return this.reverseMutation.charAt(c-65);
	}
	
	/**
	 * Encrypt function calculates the rotor output for a given char input using formula  P(A+B-C)-B+
	 * @param c given char input
	 * @param forward - if 1 forward mutaion 0 for reverse
	 * @return resulting char from the formula and  mutation
	 */
	public char Encrypt(char c ,boolean forward)
	{
		int numResult = c-64;//changing char to its index (example A->1)
		
		//result =A+B-C
		numResult = (numResult + this.ringOffset - this.ringSetting)%NUM_OF_LETTERS; 
		numResult=FixNegetive(numResult);
		
		//p(result)
		char charResult;
		if(forward) {
			 charResult = Permutation(this.Alphabet.charAt(numResult-1));}
		else //reverse
			charResult = ReversePermutation(this.Alphabet.charAt(numResult-1));
		
		
		int charIndex =  CharToNum(charResult);//result char to int
		
		//result-B+C
		numResult = (charIndex - (this.ringOffset) + (this.ringSetting))%NUM_OF_LETTERS; 
		numResult=FixNegetive(numResult);
			
		return NumToChar(numResult);
	}
	
	/**
	 * CheckNotch function check if notch is needed on next translation
	 * @return boolean value notch needed or not
	 */
	public boolean CheckNotch()
	{		
		if(NumToChar(this.ringOffset) == this.notch)
			return true;
		return false;
	}

	/**
	 * AdvenceOffset function increment the offset by 1
	 */
	public void AdvenceOffset()
	{
		this.ringOffset++;
		
		if(this.ringOffset>NUM_OF_LETTERS)
		{
			this.ringOffset=1;
		}
	}
	
	
	/**
	 * SetSettingAndOffset function sets value to ring offset and setting
	 * @param setting - ring setting value to be set
	 * @param offset  - ring offset  value to be set
	 */
	public void SetSettingAndOffset(int setting , int offset)
	{
		this.ringOffset = offset;
		this.ringSetting = setting;
	}
	
	/*---------------------UTILITY FUNCTIONS-------------------------------*/
	//transforms a number to a matching char
	public char NumToChar(int n)
	{
		if(n>NUM_OF_LETTERS || n< 1)
			return '0';
		return this.Alphabet.charAt(n-1);
	}
	//transforms a char to a matching number
	public int CharToNum(char c)
	{
		return c-64;
	}
	//fixes a negative number back to a positive number so % operation is possible 
	private int FixNegetive(int num) {
		if(num<=0)
			num = NUM_OF_LETTERS+num;
		return num;
	}
	public void PrintRotor()
	{
		System.out.println("setting is:"+this.ringSetting+" offset is:"+this.ringOffset);
	}

}
