using LINQ;

List<Dog> dogs = new List<Dog>()
{
    new Dog("Sparky", 1),
    new Dog("Butch", 2),
    new Dog("Hera", 3),
    new Dog("Luna", 1),
    new Dog("Lucy", 2),
    new Dog("Buck", 4),
};

// Find all dogs whose name has more tha 4 chaacters
// thi does not change the original list
List<Dog> dogsWithNameLongerThan4 = dogs.Where(x => x.Name.Length > 4).ToList();
Console.WriteLine("============ORIGINAL LIST===============");
foreach (Dog dog in dogs)
{
    Console.WriteLine(dog.Name);
}
Console.WriteLine("============LONGER THAN 4 ===============");
foreach (Dog dog in dogsWithNameLongerThan4)
{
    Console.WriteLine(dog.Name);
}