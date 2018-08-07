package plants;

import graphics.ZooPanel;

public class Cabbage extends Plant {
	
	private static Cabbage instance = null;
	
	private Cabbage(ZooPanel pan) {
		super(pan);
		loadImages("cabbage");
	}
	public static Cabbage getInstance(){
		if (instance == null) 
			synchronized (Cabbage.class){ 
				if (instance == null) 
					instance = new Cabbage(pan);		
			}
		return instance;			
	}
}
