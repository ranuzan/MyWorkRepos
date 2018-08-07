package graphics;

import animals.Animal;
import animals.Lion;

public class CarnivoreFactory implements AbstractZooFactory {
	private ZooPanel pan = null;
	private String color;
	private int size;
	private int x;
	private int y;
	private int vH;
	private int vS;
	
	public CarnivoreFactory(int size,int x,int y,int vH,int vS,String color,ZooPanel pan){
		this.pan = pan;
		this.color=color;
		this.size=size;
		this.x=x;
		this.y=y;
		this.vH=vH;
		this.vS=vS;
	}
	@Override
	public Animal produceAnimal(String type) {
		Animal animal = null;
		if ("Lion".equals(type))
			animal = new Lion(size, x, y, vH, vS, color, pan);
		return animal;
	}

}
