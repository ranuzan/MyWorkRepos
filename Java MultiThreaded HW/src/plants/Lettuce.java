package plants;

import graphics.ZooPanel;

public class Lettuce extends Plant {
	
	private static Lettuce instance = null;
	
	private Lettuce(ZooPanel pan) {
		super(pan);
		loadImages("lettuce");
	}
	public static Lettuce getInstance(){
		if (instance == null) 
			synchronized (Lettuce.class){ 
				if (instance == null) 
					instance = new Lettuce(pan);		
			}
		return instance;			
	}
}
