// Lambda expressions

List<string> names = new List<string>
{
    "Alice",
    "Bob",
    "Petko",
    "Charlie"
};

string foundBob = names.Find(name => name.ToLower() == "Bob".ToLower());

// Func => is used to store a method that returns a value and can have params or no params
// we are reading from left to right(Func<int, string, bool>) that means that we have a finction
// with two params and a return type. The return type here will be bool. The first param is int and the second param is string

// Func ALWAYS has a return type, so this is a function that has no params and returns a value of type int
                        // we have params, then an arrow, then the body of the method
Func<int> sumOfTwoAndFive = () => 2 + 5;
Console.WriteLine(sumOfTwoAndFive);

// we are storing anonymous method that takes one param of type List<string> and returns a bool
Func<List<string>, bool> checkIfListIsEmpty = (list) => list.Count == 0;
bool isEmpty = checkIfListIsEmpty(names); // we use the name that we stored the anonymous method in, to call it


// two params int and return type int
Func<int, int, int> sum = (a, b) => a + b;
Console.WriteLine(sum(2, 5)); // we call the method and pass the params

// if we have many lines of code in the body of the method, we use {}
// two params intand a return type bool
Func<int, int, bool> isFirstNumberLarger = (a, b) =>
{
    if(a > b)
    {
        return true;
    }
    else
    {
        return false;
    }
};

List<int> ints = new List<int>() {2, 5, 6, 7, 8};
List<int> secontListOfInts = new List<int>() { 3, 5, 6, 46, 8, 9 };

Func<int, bool> checkEven = x => x % 2 == 0;

//List<int> evenNumbers = ints.Where()....
List<int> evenNumbers = ints.Where(checkEven).ToList(); // we use the name that we stored the anonymous method in, to call it
// we can reuse the checkEven method, so that we don't  nedd to write the check logic each time
List<int> evenNumbersFromSecondInts = secontListOfInts.Where(checkEven).ToList(); 

// one param string and return type bool
Func<string, bool> statsWithJ = x => x.StartsWith("J");

List<string> namesStartingWithJ = names.Where(statsWithJ).ToList(); // we use the name that we stored the anonymous method in, to call it


// Action - Action is ALWAYS VOID

// We have no params here and no return type because Action is always void

Action sayHello = () => Console.WriteLine("Hello");
sayHello(); // we call the method and pass the params

Action<string> printRed = x =>
{
    Console.ForegroundColor = ConsoleColor.Red; // we set the color of the text to red
    Console.WriteLine(x);
    Console.ResetColor();
};
// we call the method and pass the params
printRed("Hello");

Action<string, ConsoleColor> printColor = (x, color) =>
{
    Console.ForegroundColor = color; // we set the color of the text to red
    Console.WriteLine(x);
    Console.ResetColor();
};
// we call the method and pass the params
printColor("We are learning C#", ConsoleColor.Green);