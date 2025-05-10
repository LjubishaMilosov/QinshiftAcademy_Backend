using Polymorphism.Domain;
using Polymorphism.Domain.Service;

Pet firstPet = new Pet();
firstPet.Name = "First Pet";
firstPet.Eat();  // method from Pet class

Pet secondPet = new Cat();
secondPet.Name = "Lucy";
// secondPet.Age; // ERROR because secondPet is of type Pet(boxing)
secondPet.Eat(); // method from Cat class

Cat cat = new Cat();
cat.Eat(); //  from Cat class

Dog dog = new Dog();
dog.Name = "Sparky";
dog.Eat(); // from Dog class

List<Pet> ourPets = new List<Pet>();
ourPets.Add(firstPet);
ourPets.Add(cat);
ourPets.Add(dog);

foreach (Pet pet in ourPets)
{
    pet.Eat(); // in each iteration the method Eat will be called from the specific class( for cat it will be from Cat class, for dog it will be from Dog class, for firstPet from Pet class)
}

// Compiletime polymorphism
// the idea is that as long as the program knows which method to call, we can have as TransformManyBlock combinations as we need
// just the signature has to be different
PetService petService = new PetService();
petService.PetStatus();

petService.PetStatus("John", cat); // method with two params, first method
petService.PetStatus(cat, "John"); // method with two params, second method

petService.PetStatus(dog, "John"); // method with two params, first method
petService.PetStatus("John", dog); // method with two params, second method
