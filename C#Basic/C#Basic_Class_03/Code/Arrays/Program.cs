
int[] arrayOfInts = new int[3];

arrayOfInts[0] = 1;
arrayOfInts[1] = 6;
//arrayOfInts[2] = 13;

Console.WriteLine("First element " + arrayOfInts[0]);
Console.WriteLine("Third element " + arrayOfInts[2]);

//declare and initialize the array
// C# from the given values will see how many elements we have in the array 
string[] arrayOfStrings = new string[] { "Hello", "G6", "C#", "arrays", "Goodbye!" };

Console.WriteLine("Number of elements in the array: " + arrayOfStrings.Length);
Console.WriteLine( arrayOfStrings[3]);


short[] arrayOfShorts = new short[] { 1, 2, 5, 8 };
bool[] arayOfBools = new bool[] { false, true, false };

bool[] anotherArrayOfBools = new bool[2];
anotherArrayOfBools[0] = true;
anotherArrayOfBools[1] = false;

Console.WriteLine("Number of element in anotherArrayOfBools: " + anotherArrayOfBools.Length);

int indexOfEight = Array.IndexOf(arrayOfShorts, 2);


Console.WriteLine("Index of 8 in arrayOfShorts is: " + indexOfEight);
