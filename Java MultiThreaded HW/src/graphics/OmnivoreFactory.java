package graphics;

import animals.Animal;
import animals.Bear;

public class OmnivoreFactory implements AbstractZooFactory {

	private ZooPanel pan = null;
	private String color;
	private int size;
	private int x;
	private int y;
	private int vH;
	private int vS;
	
	public OmnivoreFactory(int size,int x,int y,int vH,int vS,String color,ZooPanel pan){
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
		if ("Bear".equals(type))
			animal = new Bear(size, x, y, vH, vS, color, pan);
		return animal;
	}


}
