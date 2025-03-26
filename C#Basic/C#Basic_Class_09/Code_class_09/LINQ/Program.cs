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

// all dogs whose name starts with L 
List<Dog> dogsStartingWithL = dogs.Where(d => d.Name.StartsWith("L") || d.Name.StartsWith("l")).ToList();


List<Dog> dogsDoesNotStartingWithL = dogs.Where(d => !d.Name.StartsWith("L") && !d.Name.StartsWith("l")).ToList();

Console.WriteLine("============Starts with L ===============");
foreach(Dog dog in dogsStartingWithL)
{
    Console.WriteLine(dog.Name);
}

Console.WriteLine("============DOes Not Start with L ===============");
foreach (Dog dog in dogsDoesNotStartingWithL)
{
    Console.WriteLine(dog.Name);
}


// Find the first dog older than two
//First Way
Dog firstDogOlderThanTwo1 = dogs.Where(d => d.Age > 2).FirstOrDefault(); // gets all dogs older than 2 and then returns the first one

// Second Way
Dog firstDogOlderThanTwo2 = dogs.FirstOrDefault(d => d.Age > 2); // gets the firt dog older than 2

//  Dog dogWithNameOnA = dogs.First(d => d.Name.StartsWith("A")); // this will throw an error: Secuence contains no matching element 

Dog dogWithNameOnA = dogs.FirstOrDefault(d => d.Name.StartsWith("A"));
if(dogWithNameOnA == null)
{
    Console.WriteLine("No dog with name starting with A");
}
else
{
    Console.WriteLine(dogWithNameOnA.Name);
}
