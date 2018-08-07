package graphics;

import animals.Animal;

public interface AbstractZooFactory {
	
	public Animal produceAnimal(String type);
}
