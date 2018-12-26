package Enigma;

import java.util.Scanner;

/**
 * 
 * @author ranuzan
 * @class CompleteEnigma 
 * represent a Complete Enigma machine with all 5 rotors reflector and plugboard
 */

public class CompleteEnigma {
	
	Rotor rotor1;
	Rotor rotor2;
	Rotor rotor3;
	Rotor rotor4;
	Rotor rotor5;
	Reflector reflectorB;
	PlugBoard pb;
	CalibratedEnigma enigma;
	
	/**
	 * defult ctor builds the enigma machine variables with defult values
	 */
	CompleteEnigma()
	{
		BuildEnigma();
	}
	
	public void BuildEnigma()
	{
		System.out.println("BUILDING ENIGMA AND CALCUATING MUTATIONS");
		///////////////////---forward mutation------setng-off-notch-///
		rotor1 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ",1,1,'Q');
		rotor2 = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE",1,1,'E');
		rotor3 = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO",1,1,'V');
		rotor4 = new Rotor("ESOVPZJAYQUIRHXLNFTGKDCMWB",1,1,'J');
		rotor5 = new Rotor("VZBRGITYUPSDNHLXAWMJQOFECK",1,1,'Z');
		reflectorB = new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");	
		pb = new PlugBoard();
	}
	
	//Encrypt a single char
	public void Encrypt(char c)
	{
		 enigma.EncryptChar(c);
	}
	//Encrypts a string
	public void Encrypt(String s)
	{
		enigma.EncryptString(s);
	}
	
	
	//*****--------------ENIGMA MACHINE RUN EXAMPLES----------------*****//
	public void EncryptEnigma()
	{
		//adjusting rotor initial setting and offset
		rotor1.SetSettingAndOffset(1, 6);
		rotor2.SetSettingAndOffset(1, 4);
		rotor3.SetSettingAndOffset(1, 22);
		
		//putting machine together  
		enigma = new CalibratedEnigma(rotor3,rotor2,rotor1,pb,reflectorB);//rotor in ctor are right to left
		
		//encrypting message		
		Encrypt("ENIGMA");
	}
	public void DecryptEnigma()
	{
		//adjusting rotor initial setting and offset
		rotor1.SetSettingAndOffset(1, 6);
		rotor2.SetSettingAndOffset(1, 4);
		rotor3.SetSettingAndOffset(1, 22);
		
		//putting machine together  
		enigma = new CalibratedEnigma(rotor3,rotor2,rotor1,pb,reflectorB);//rotor in ctor are right to left
		
		//encrypting message
		Encrypt("QGELID");

	}
	public void EncryptKaxmnf()
	{
		//adjusting rotor initial setting and offset
		rotor1.SetSettingAndOffset(1, 17);
		rotor2.SetSettingAndOffset(1, 5);
		rotor3.SetSettingAndOffset(1, 22);
		
		//putting machine together  
		enigma = new CalibratedEnigma(rotor3,rotor2,rotor1,pb,reflectorB);//rotor in ctor are right to left
		
		//encrypting message
		Encrypt("KAXMNF");

	}
	public void EncryptTuring()
	{
		//adjusting rotor initial setting and offset
		rotor1.SetSettingAndOffset(1, 24);
		rotor2.SetSettingAndOffset(1, 5);
		rotor3.SetSettingAndOffset(1, 25);
		
		//putting machine together  
		enigma = new CalibratedEnigma(rotor3,rotor2,rotor1,pb,reflectorB);//rotor in ctor are right to left
		
		//encrypting message
		Encrypt("TURING");

	}

	public void EncryptPeace() 
	{	
		//adjusting rotor initial setting and offset
		rotor1.SetSettingAndOffset(3, 19);
		rotor2.SetSettingAndOffset(8, 4);
		rotor4.SetSettingAndOffset(6, 9);
		
		//putting machine together  
		enigma = new CalibratedEnigma(rotor4,rotor2,rotor1,pb,reflectorB);//rotor in ctor are right to left
		
		//encrypting message
		Encrypt("PEACE");

	}
	public void EncryptPeaceWithPB() 
	{	
		//adjusting rotor initial setting and offset
		rotor1.SetSettingAndOffset(3, 19);
		rotor2.SetSettingAndOffset(8, 4);
		rotor4.SetSettingAndOffset(6, 9);
		
		//Connecting plugBoard
		pb = new PlugBoard("ATCERL");
		
		//putting machine together  
		enigma = new CalibratedEnigma(rotor4,rotor2,rotor1,pb,reflectorB);//rotor in ctor are right to left
		
		//encrypting message
		Encrypt("PEACE");

	}

	public void EncryptDor() {

		//adjusting rotor initial setting and offset
		rotor2.SetSettingAndOffset(19, 3);
		rotor5.SetSettingAndOffset(9, 15);
		rotor4.SetSettingAndOffset(24, 14);

		//Connecting plugBoard
		pb = new PlugBoard("ZUHLCQWMOAPYEBTRDNVI");
		
		//putting machine together  
		enigma = new CalibratedEnigma(rotor4,rotor5,rotor2,pb,reflectorB);//rotor in ctor are right to left
		
		//encrypting message
		Encrypt("DOR");


	}

	public void EncryptMLD() {
		//adjusting rotor initial setting and offset
		rotor2.SetSettingAndOffset(19, 3);
		rotor5.SetSettingAndOffset(9, 15);
		rotor4.SetSettingAndOffset(24, 14);
		
		//Connecting plugBoard
		pb = new PlugBoard("ZUHLCQWMOAPYEBTRDNVI");
		
		//putting machine together  
		enigma = new CalibratedEnigma(rotor4,rotor5,rotor2,pb,reflectorB);//rotor in ctor are right to left
		
		//encrypting message
		Encrypt("MLD");

	}

	public void DecryptTask5()
	{
		//setting SIX 
		//offset CON -->encrypt MLD output DOR 
		//offset DOR-->set machine and decrypt message without id group
		rotor2.SetSettingAndOffset(19, 4);
		rotor5.SetSettingAndOffset(9, 15);
		rotor4.SetSettingAndOffset(24, 18);
		pb = new PlugBoard("ZUHLCQWMOAPYEBTRDNVI");
		
		enigma = new CalibratedEnigma(rotor4,rotor5,rotor2,pb,reflectorB);//rotor in ctor are right to left
		

		Encrypt("UMDPQ");//GROUP
		Encrypt("CUAQN");//SOUTH
		Encrypt("LVVSPIA");//COMMAND
		Encrypt("RKCT");//FROM
		Encrypt("TRJ");//GEN
		Encrypt("QKCFPT");//PAULUS
		Encrypt("O");//X

		Encrypt("KRGOZ");//SIXTH
		Encrypt("XALD");//ARMY
		Encrypt("RL");//IS
		Encrypt("PUHAUZSOS");//ENCIRCLED
		Encrypt("Z");//X
		
		Encrypt("FSUGWFNFD");//OPERATION
		Encrypt("ZCUG");//BLAU
		Encrypt("VEXUUL");//FAILED
		Encrypt("Q");//X
		
		Encrypt("YXOTCYRP");//COMMENCE
		Encrypt("SYGGZH");//RELEF
		Encrypt("QMAGPZDKC");//OPERATION
		Encrypt("KGOJMMYYDDH");//IMMEDIATELY
	
	}
	public void AcceptUserInput()
	{
		String s;
		boolean test=false;
		int choice1=0,choice2=0,choice3=0;
		Rotor R=null ,L=null , M=null;
		Scanner reader = new Scanner(System.in);
		
		
		//**************------building rotors---------**************//
		
		
		//left rotor
		while(test==false)
		{
		System.out.println("pick left rotor (1-5)");
		choice1 = reader.nextInt();
		if(choice1>0 && choice1 <6)
			test=true;
			L = NumToRotor(choice1);
		}
		test = false;
		
		
		//middle rotor
		while(test==false)
		{
		System.out.println("pick middle rotor (1-5)");
		choice2 = reader.nextInt();
		if((choice2>0 && choice2 <6)&&choice1!=choice2)
			test=true;
			M = NumToRotor(choice2);
		}
		test = false;
		
		
		//right rotor
		while(test==false)
		{
		System.out.println("pick right rotor (1-5)");
		choice3 = reader.nextInt();
		if((choice3>0 && choice3 <6)&&choice3!=choice2 && choice3!=choice1)
			test=true;
			R = NumToRotor(choice3);
		}
		test = false;
		
		System.out.println("rotor numbers are "+choice1+" "+choice2+" "+choice3);
		//left rotor setting and offset
		System.out.println("enter left rotor setting");
		choice1 = GetUserNumInRange(1,26);
		System.out.println("enter left rotor offset");
		choice2 = GetUserNumInRange(1,26);
		L.SetSettingAndOffset(choice1, choice2);
		
		//middle rotor setting and offset

		System.out.println("enter middle rotor setting");
		choice1 = GetUserNumInRange(1,26);
		System.out.println("enter middle rotor offset");
		choice2 = GetUserNumInRange(1,26);
		//System.out.println("middle rotor choice 1 and 2 :" +choice1+" "+choice2);
		M.SetSettingAndOffset(choice1, choice2);

		//right rotor setting and offset
		System.out.println("enter right rotor setting");
		choice1 = GetUserNumInRange(1,26);
		System.out.println("enter right rotor offset");
		choice2 = GetUserNumInRange(1,26);
		
		System.out.println(R==M);
		R.SetSettingAndOffset(choice1, choice2);

		
		while(test==false)
		{
			System.out.println("enter plug board string (even string only) for empty string enter 0");
			s = reader.nextLine();
			s = reader.nextLine();
			if(s.charAt(0)=='0')
			{
				test=true;
				pb = new PlugBoard();
			}
			
			else if(s.length()%2==0)
			{
				test=true;
				pb = new PlugBoard(s);
			}
		}
		

		enigma = new CalibratedEnigma(R, M, L, pb, reflectorB);
		
		
		System.out.println("enter string to be encrypted");
		s = reader.nextLine();
		
		reader.close();
		


		enigma.EncryptString(s);
		
		
	}
	public Rotor NumToRotor(int choice)
	{
		switch (choice)
		{
		case 1:
			return rotor1;
		case 2:
			return rotor2;
		case 3:
			return rotor3;
		case 4:
			return rotor4;
		case 5:
			return rotor5;
		default:
			return null;
		}
	}
	public int GetUserNumInRange(int min,int max)
	{
		int num=-1;
		Scanner reader1 = new Scanner(System.in);
		boolean test = false;
		while(test ==false)
		{
			System.out.println("enter a number between "+min+" and "+max);
			num = reader1.nextInt();
			if(num<=max && num>=min)
				test =true;
			else
				System.out.println("num picked is out of range");
		}
		
		return num;
	}

}
