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
//First dog with age 1 whose name starts with L
Dog dogAgedOneStartingWithL = dogs.FirstOrDefault(d => d.Age == 1 && (d.Name.StartsWith("L") || d.Name.StartsWith("l")))  ;

Console.WriteLine("============SELECT===============");

//get all dog names
List<string>dogNames = dogs.Select(d => d.Name).ToList();

//take the names of all dogs aged 2
// List<string> dogsnamesAged2 = dogs.Select(d => d.Name)Where(     // here we are working with IEnumerable<string>
                                                                     // (we have only the name so we can not use Where to filetr by age -
                                                                   // string does not have 'age' property)

List<string> dogsnamesAged2 = dogs.Where(d => d.Age == 2).Select(d => d.Name).ToList();

List<string>namesOfDogsAged2SatrtsWithL = 
    dogs  // here we have the whole List<dog>
       .Where(x => x.Age ==2)  // here we have IEnumerable<dog> with only dogs aged 2
       .Select(x=>x.Name)  // here we have IEnumerable<string> with only names of dogs aged 2
       .Where(x => x.StartsWith("L") || x.StartsWith("l")) // here we have IEnumerable<string> with only names of dogs aged 2 and starting with L
       .ToList(); // here we have List<string> with only names of dogs aged 2 and starting with L

Dog lastDogAged1 = dogs.Last(d => d.Age == 1); // gets the last dog aged 1 -> this might throw an error

Dog lastDogAged1BetterOption = dogs.LastOrDefault(d => d.Age == 1); // gets the last dog aged 1 or null if there is no dog aged 1