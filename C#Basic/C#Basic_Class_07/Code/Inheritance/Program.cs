using Inheritance.Models;

Animal animal = new Animal();
animal.Name = "test animal";
animal.Type = "Test type";
//animal.Age => ERROR => protected property (
// animal.id => ERROR => private property

animal.PrintInfo();

// animal.PrintAge(); ==> ERORR => does not exist in Animal, only in Cat class

Cat cat = new Cat();
cat.Name = "Lucy";
cat.Type = "Cat";
cat.IsLazy = true;
cat.PrintAge();  // call the implementation from the Cat class


cat.PrintInfo();

Dog dog = new Dog("Rex", "Brown");
dog.PrintInfo();  // it will call the PrintInfo method from the animal class( we haven't overriden that method in the Dog class

Dog newDog = new Dog();
Console.ReadLine();