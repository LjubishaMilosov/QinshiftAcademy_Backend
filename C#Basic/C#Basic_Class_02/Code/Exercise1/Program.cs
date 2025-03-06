//Declare two double variables
//Initialize them and divide them in a new variable
//Declare two integer variables
//Initialize them and divide them in a new variable
//Print the results in the console and compare

double firstDouble;
double secondDouble;

firstDouble = 5;
secondDouble = 1.3;
double doubleResult = firstDouble / secondDouble;
Console.WriteLine("double result: " + doubleResult);

int firstInt, secondInt;
firstInt = 9;
secondInt = 4;
int intResult = firstInt / secondInt;
Console.WriteLine("int result: " + intResult);

// when we divide two whole number, the result will always be a whole number
double doubleIntResult = firstInt / secondInt;
Console.WriteLine("int result: " + doubleIntResult);

// when we divide a full number with a decimal number, the result will be a decimal number
double differentTypesResult = firstInt / secondDouble;
Console.WriteLine("differentTypesResult: " + differentTypesResult);

//Extra -=- casting
double doubleIntCastResult = (double)firstInt / secondInt;
Console.WriteLine("doubleIntCastResult: " + doubleIntCastResult);

