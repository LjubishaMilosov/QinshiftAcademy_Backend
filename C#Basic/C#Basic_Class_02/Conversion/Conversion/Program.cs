// Type.parse(value)
Console.WriteLine("====== Type.parse(value) =============");
string numberString = "20";

int parsedIntString = int.Parse(numberString);
Console.WriteLine(parsedIntString.GetType()); // Output: System.Int32

double parsedDouble = double.Parse("92.3");
Console.WriteLine(parsedDouble.GetType()); // Output: System.Double

string wrongString = "G6";
//int wrongStringParse = int.Parse(wrongString);  //System.FormatException: The input string 'G6' was not in a correct format.




// Convert.ToType(value)
Console.WriteLine("====== Convert.ToType(value) =============");

short number  = Convert.ToInt16(numberString); 
Console.WriteLine(number.GetType());    // Output: System.Int16

int numberInt = Convert.ToInt32(numberString);
Console.WriteLine(numberInt.GetType()); // Output: System.Int32

//int wrongStringConvert = Convert.ToInt32(wrongString);       //System.FormatException: 'The input string 'G6' was not in a correct format.'
//Console.WriteLine(wrongStringConvert);
//Console.WriteLine(wrongStringConvert.GetType());

int nullConvert = Convert.ToInt32(null);     
Console.WriteLine(nullConvert);   // 0
Console.WriteLine(nullConvert.GetType());  // System.Int32




//Type.TryParse(value)
Console.WriteLine("====== Type.TryParse(value) =============");

int parsedValue;  // we need to declare a vriable where we will store the parsed value

bool success = int.TryParse(numberString, out parsedValue);
Console.WriteLine(parsedValue);  // 20
Console.WriteLine(success);  // true


bool secondSuccess = int.TryParse("G6", out int secondParsedValue);
Console.WriteLine(secondParsedValue);  // 0
Console.WriteLine(secondSuccess);  // false


Console.WriteLine("Enter your group number:");  
string input = Console.ReadLine();

bool inputSuccess = int.TryParse(input, out int parsedGroupNumber);
if(inputSuccess)
{
    Console.WriteLine("Hello from G" + parsedGroupNumber);
}
else
{
    Console.WriteLine("Wrong Input! You didn't enter a number!");
}
