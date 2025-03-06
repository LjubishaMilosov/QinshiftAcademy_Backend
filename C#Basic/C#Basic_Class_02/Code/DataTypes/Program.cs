Console.WriteLine("======== Data Types! =================");

int firstIntVariable = 5555; // declaration and initialization

Console.WriteLine("firstIntVariable: " + firstIntVariable); // concatenation

short firstShortVariable = 5; // declaration and initialization

//interpolation:
Console.WriteLine($"firstShortVariable: {firstShortVariable}, firstIntVariable: {firstIntVariable}");

// int firstIntVariable = 4444; // Error - can not redeclare variable with the same name

firstIntVariable = 7; // reassigning value to the variable
Console.WriteLine("firstIntVariable: " + firstIntVariable);

//Decimal Numbers

float firstFloatVariable = 1.567f; // we need to ise f or F at the end of the number

double firstDoubleVariable = 1.567; // by default, double is used for decimal numbers
Console.WriteLine($"firstDoubleVariable: {firstDoubleVariable}");

// char
char firstCharVariable = 'A';
Console.WriteLine($"firstCharVariable: {firstCharVariable}");

// firstCharVariable = 'aaa'; // too many characters
// firstCharVariable = "A"; // Error - can not use double quotes for char

// string
string firstStringVariable = "Hello, World!";
Console.WriteLine($"firstStringVariable: {firstStringVariable}");

string singleCharacterString = "A"; // this is a string, not a char because of double quotes

// bool
bool firstBoolVariable = true;
Console.WriteLine($"firstBoolVariable: {firstBoolVariable}");

// number
int number = 5;
Console.WriteLine($"number: {number}");
number = 7;
Console.WriteLine($"number: {number}");

// number = "7"; // Error - can not assign string to int    
// number = 7.5; // Error - can not assign double to int


// implicitly typed variables take the type of the first value assigned to them
var secondNumber = 5;
secondNumber = 777;
//secondNumber = "777"; // Error - can notchange the type of variable / assign string to int

string secondVariable = "Hello, World!";

DateTime dateTime = DateTime.Now;
Console.WriteLine($"current tim e: {dateTime}");

// operators

int sum = 5 + 7;
Console.WriteLine($"sum: {sum}");

sum += 90;
Console.WriteLine($"sum: {sum}"); // 102

//Console.WriteLine(testVariable); // we can not use the variable before declaring it
int testVariable;
//Console.WriteLine(testVariable); // we can not use the variable before initializing it/giving a value
testVariable = 5;
Console.WriteLine(testVariable); // we can use it now

sum++; // increment by 1      sum = sum +1;        sum+=1;


int secondSum = sum; // we can use the value of another variable if it is of the same type
//string StringSum = sum; // Error - can not assign int to string/different data types

