//Arrays
using System.Collections;

Console.WriteLine("===========Arrays===============");
int[] intArray = new int[3];
string[] stringArray = new string[] {"Hello", "Bye"};  // 2 elements

foreach (string str in stringArray)
{
    Console.WriteLine(str);
}

// ArrayList -> acepts all types, can have mixed array lists, does not have a constraint about number of elements
Console.WriteLine("===========ArrayList===============");
ArrayList arryList = new ArrayList();  // empty array list
ArrayList secondArrayList = new ArrayList() { "Hello", 5, true };  // mixed array list
secondArrayList.Add("Bye");
secondArrayList.Remove(5);  // we send the value of the element we want removed
secondArrayList.RemoveAt(0);  // we send the index of the element we want removed

//  in each iteration, item wil have the appropriate data type => var will take the data type dependiong on the value of the element
foreach (var item in secondArrayList)
{
    Console.WriteLine(item);
}

for(int i = 0; i < secondArrayList.Count; i++)  // Count => number of elements in the array list
{
    Console.WriteLine(i.ToString() + ". " + secondArrayList[i]);
}

// List => all memebers must be of the same type. does not have constrains regarding the number of elements
Console.WriteLine("===========List===============");

List<int> emptyListOfInts = new List<int>();  // empty list of ints
List<string> listOfStrings = new List<string>();  // empty list of strings
List<int> listOfInts = new List<int>() {2, 4, 6 };  // list of ints 
listOfInts.Add(5);  // add element to the list
listOfInts.Add(-19);
listOfInts.Remove(4);  // remove element with value 4 from the list
listOfInts.RemoveAt(0);  // remove element with index zero  (at index/position 0) from the list
Console.WriteLine(listOfInts[2]);  // access element at index 2
Console.WriteLine($"Number of elements in list of ints: {listOfInts.Count}");

foreach(int number in listOfInts)
{
    Console.WriteLine(number);
}

// Dictionary - works with key value pair
Console.WriteLine("===========Dictionary===============");
// we are tlling the dictionary that its keys will be of data type ints and its values of data type strings
Dictionary<int, string> products = new Dictionary<int, string>()  // in Dictionary we don't have indices
{
    {111, "potato"},
    {222, "milk"},
    {333, "bread"}
};

Console.WriteLine(products[222]);  // access value by key

products.Add(444, "tea");  // add new key value pair
products[111] = "coffee";  // change value of key 111
Console.WriteLine(products[111]);  // coffee
bool keyExists =  products.ContainsKey(222);  // check if key exists, returns true or false whether the products dictionary contains the key
Console.WriteLine(keyExists);  // true
products.Remove(333);  // remove key value pair with key 333

Console.WriteLine(products.Count);

// var-> is key value pair
foreach (var item in products)
{
    Console.WriteLine(item.Key + " - " + item.Value);
}

// Queue - first in first out
Console.WriteLine("===========Queue===============");
Queue<int> queue = new Queue<int>();
queue.Enqueue(5);  // add 5 to the end of the queue
queue.Enqueue(19); // add 19 to the end of the queue
queue.Enqueue(100);  // add 100 to the end of the queue

int firstElement = queue.Dequeue();  // removes and returns first element from the queue
Console.WriteLine(firstElement);  // 5
int readFirstElement = queue.Peek();  // only returns the value of first element in the queue without removing it
Console.WriteLine(readFirstElement);  // 19

foreach(int item in queue)
{
    Console.WriteLine(item);
}
Console.WriteLine(queue.Count);


// STACK -LIFO (last in first out)
Console.WriteLine("===========Stack===============");

Stack<string> stack = new Stack<string>();
stack.Push("Hello");  // add element to the stack\
stack.Push("welcome"); 
stack.Push("bye");

string lastElement = stack.Pop();  // REMOVE and RETURN the last element from the stack (bye)
Console.WriteLine(lastElement);  // bye

string currentLastElement = stack.Peek();  // only returns the value of the last element in the stack without removing it
Console.WriteLine(currentLastElement);  // welcome

Console.WriteLine(stack.Count);

foreach(string item in stack)
{
    Console.WriteLine(item);
}