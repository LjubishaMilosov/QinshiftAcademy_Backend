using Exercise_01;
using Exercise_01.Models;

Dog dog1 = new Dog();
dog1.Id = 4;
dog1.Name = ""; // string.Empty
dog1.Color = "Brown";

dog1.Bark(); // Bark is a non-static method, so it can be called on an instance of the class

// Dog.Validate -> the method is static so we need to use the class to access it
if (Dog.Validate(dog1))
{
    DogShelter.Dogs.Add(dog1);
}

DogShelter.PrintAll(); // PrintAll is a static method, so it can be called on the class itself
