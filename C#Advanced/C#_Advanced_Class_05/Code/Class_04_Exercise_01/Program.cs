
using Class_04_Exercise_01.Domain;
using Class_04_Exercise_01.Domain.Models;

PetStore<Dog> dogPetStore = new PetStore<Dog>();
dogPetStore.Pets.Add(new Dog("Sparky", 3, "Bacon", true));
dogPetStore.Pets.Add(new Dog("Lucy", 5, "Meat", true));

Console.WriteLine("Dog pets in our store: ");
dogPetStore.PrintPets();

//boxing
PetStore<Pet> petStore = new PetStore<Pet>();
petStore.Pets.Add(new Dog("Sparky", 3, "Bacon", true));
petStore.Pets.Add(new Cat("Lucy", 2, 9, true));
petStore.Pets.Add(new Fish("Bella", 1, "orange", 6));

Console.WriteLine("Welcome to our pet store");
petStore.PrintPets();


Console.WriteLine("=====================================================");
Console.WriteLine("Please enter the name of the pet you want to buy");
petStore.BuyPet("Bella");
petStore.PrintPets();