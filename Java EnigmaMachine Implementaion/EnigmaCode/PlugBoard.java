package Enigma;
/**
 * 
 * @author ranuzan
 * @class PlugBoard 
 * represent a PlugBoard in an enigma machine
 * connections represent the connection in the enigma machine plugboard
 * numOfConnections represent the number of connection in the enigma machine plugboard
 */


public class PlugBoard {
	
	private char [][] connections = new char[10][2];
	private int numOfConnections=0;
	
	/**
	 * defult ctor a no connection plugboard
	 */
	PlugBoard()
	{
		for(int i = 0 ; i<10;i++)//inting all array values to '0'
		{
			for(int j=0; j<2; j++)
			{
				connections [i][j] = '0';
			}
		}
	}
	/**
	 * string ctor makes the connections in the plugboard according to input string
	 * @param connection - represent connections in the plugboard
	 */
	PlugBoard(String connection)//connections should be in format of "ABCD" - AB   CD
	{
		if (Main.SANITYCHECK) 
		{
			if (connection.length() % 2 != 0)// input test
				System.out.println("connection string must be even len");


			if (this.numOfConnections > 10)// input test
				System.out.println("CONNECTION STRING TOO LONG CAN ONLY MAKE 10 CONNECTIONS");

			for (int i = 0; i < connection.length() - 1; i++)// testing connection string
			{
				for (int j = i + 1; j < connection.length(); j++) {
					if (i == j)// input test
						System.out.println("same letter cant be connected twice");
				}
			}
		}
		
		numOfConnections = connection.length() / 2;// getting number of connections
		for(int i=0; i<connection.length(); i+=2)//building the connections array
		{
			this.connections[i/2][0] = connection.charAt(i);
			this.connections[i/2][1] = connection.charAt(i+1);
		}

		
	}
	/**
	 * @param c - a char input to check if needs to be changed in PB
	 * @return returns the result of the plugboard
	 */
	public char Encrypt(char c)
	{
		if(this.connections[0][0] == '0')//case no connections
			return c;
		
		for(int i =0 ;i<numOfConnections;i++)
		{
			if(c == this.connections[i][0])
				return this.connections[i][1];
			if(c == this.connections[i][1])
				return this.connections[i][0];
		}
		return c;
	}
	public void SetConnection(String connections)
	{
		
	}

}
