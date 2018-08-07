package graphics;

import animals.Animal;
import animals.Elephant;
import animals.Giraffe;
import animals.Turtle;

public class HerbivoreFactory implements AbstractZooFactory {


	private ZooPanel pan = null;
	private String color;
	private int size;
	private int x;
	private int y;
	private int vH;
	private int vS;
	
	public HerbivoreFactory(int size,int x,int y,int vH,int vS,String color,ZooPanel pan){
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
		if ("Giraffe".equals(type))
			animal = new Giraffe(size, x, y, vH, vS, color, pan);
		if("Elephant".equals(type))
			animal = new Elephant(size, x, y, vH, vS, color, pan);
		if("Turtle".equals(type))
			animal = new Turtle(size, x, y, vH, vS, color, pan);	
		return animal;
	}
}
