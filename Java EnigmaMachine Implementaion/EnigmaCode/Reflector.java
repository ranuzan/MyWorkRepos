package Enigma;

/**
 * 
 * @author ranuzan
 * @class Reflector 
 * represent a Reflector in an enigma machine
 * Mutation represent the forward and reverse Mutation in the enigma machine reflector
 */
public class Reflector {
	
	private String Mutation;

	
	/**
	 * ctor that accept the reflector symetric mutation and assign it to the mutation field
	 * @param symmetricMutation - represent a mutation of a reflector
	 */
	Reflector(String symmetricMutation)
	{
		if(Main.SANITYCHECK) 
		{
			if(symmetricMutation.length()!=Rotor.NUM_OF_LETTERS)//input test
				System.out.println("wrong mutation length");
			for(int i =0 ;i<symmetricMutation.length();i++)
			{
				char c = symmetricMutation.charAt(i);
				StringBuilder s = new StringBuilder(symmetricMutation);
				if(Character.isLetter(c))
				{
					if(Character.isLowerCase(c))
						s.setCharAt(i,Character.toUpperCase(c));
				}
				else System.out.println("there can only be letters in mutation string");
			}
			for (int i = 0; i < symmetricMutation.length(); i++) 
			{	
	            for (int j = i + 1; j < symmetricMutation.length(); j++) 
	                if (symmetricMutation.charAt(i) == symmetricMutation.charAt(j)) 
	    				System.out.println("duplicate charchters in mutation string");
			}
		}
		
		this.Mutation = symmetricMutation;		
	}
	
	/**
	 * output function calculates the reflector output for a given char input
	 * @param c given char input
	 * @return resulting char from the mutation
	 */
	public char Encrypt(char c)
	{
		return Mutation.charAt(c-65);	
	}
}
