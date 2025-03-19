using Inheritance.Models;

Animal animal = new Animal();
animal.Name = "test animal";
animal.Type = "Test type";
//animal.Age => ERROR => protected property (
// animal.id => ERROR => private property

animal.PrintInfo();

// animal.PrintAge(); ==> ERORR => does not exist in Animal, only in Cat class