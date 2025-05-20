using LINQExercise.Domain.Enums;
using LINQExercise.Domain.Models;

List<Dog> dogs = new List<Dog>()
{
    new Dog("Charlie", "Black", 3, BreedEnum.Collie), // 0
    new Dog("Buddy", "Brown", 1, BreedEnum.Doberman),
    new Dog("Max", "Olive", 1, BreedEnum.Plott),
    new Dog("Archie", "Black", 2, BreedEnum.Mutt),
    new Dog("Oscar", "White", 1, BreedEnum.Mudi),
    new Dog("Toby", "Maroon", 3, BreedEnum.Bulldog), // 5
    new Dog("Ollie", "Silver", 4, BreedEnum.Dalmatian),
    new Dog("Bailey", "White", 4, BreedEnum.Pointer),
    new Dog("Frankie", "Gray", 2, BreedEnum.Pug),
    new Dog("Jack", "Black", 5, BreedEnum.Dalmatian),
    new Dog("Chanel", "Black", 1, BreedEnum.Pug), // 10
    new Dog("Henry", "White", 7, BreedEnum.Plott),
    new Dog("Bo", "Maroon", 1, BreedEnum.Boxer),
    new Dog("Scout", "Olive", 2, BreedEnum.Boxer),
    new Dog("Ellie", "Brown", 6, BreedEnum.Doberman),
    new Dog("Hank", "Silver", 2, BreedEnum.Collie), // 15
    new Dog("Shadow", "Silver", 3, BreedEnum.Mudi),
    new Dog("Diesel", "Brown", 4, BreedEnum.Bulldog),
    new Dog("Abby", "Black", 1, BreedEnum.Dalmatian),
    new Dog("Trixie", "White", 8, BreedEnum.Pointer), // 19
};

List<Person> people = new List<Person>()
{
    new Person("Nathanael", "Holt", 20, Job.Choreographer),
    new Person("Rick", "Chapman", 35, Job.Dentist),
    new Person("Oswaldo", "Wilson", 19, Job.Developer),
    new Person("Kody", "Walton", 43, Job.Sculptor),
    new Person("Andreas", "Weeks", 17, Job.Developer),
    new Person("Kayla", "Douglas", 28, Job.Developer),
    new Person("Richie", "Campbell", 19, Job.Waiter),
    new Person("Soren", "Velasquez", 33, Job.Interpreter),
    new Person("August", "Rubio", 21, Job.Developer),
    new Person("Rocky", "Mcgee", 57, Job.Barber),
    new Person("Emerson", "Rollins", 42, Job.Choreographer),
    new Person("Everett", "Parks", 39, Job.Sculptor),
    new Person("Amelia", "Moody", 24, Job.Waiter)
    { Dogs = new List<Dog>() {dogs[16], dogs[18] } },
    new Person("Emilie", "Horn", 16, Job.Waiter),
    new Person("Leroy", "Baker", 44, Job.Interpreter),
    new Person("Nathen", "Higgins", 60, Job.Archivist)
    { Dogs = new List<Dog>(){dogs[6], dogs[0] } },
    new Person("Erin", "Rocha", 37, Job.Developer)
    { Dogs = new List<Dog>() {dogs[2], dogs[3], dogs[19] } },
    new Person("Freddy", "Gordon", 26, Job.Sculptor)
    { Dogs = new List<Dog>() {dogs[4], dogs[5], dogs[10], dogs[12], dogs[13] } },
    new Person("Valeria", "Reynolds", 26, Job.Dentist),
    new Person("Cristofer", "Stanley", 28, Job.Dentist)
    { Dogs = new List<Dog>() {dogs[9], dogs[14], dogs[15] } }
};