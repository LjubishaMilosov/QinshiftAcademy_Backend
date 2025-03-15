﻿//Create a method called NumberStats that accepts a number. This method should:
//Find out if the number is negative or positive
//Find out if the number is odd or even
//Find out if the number is decimal or integer
//After finding all the stats it should print them like this:
//Stats for number: 25
//Positive
//Integer
//Odd
//The number should be entered in the console by the user.
//Bonus: Validate if the user is entering a number
//Bonus: Ask the user to press Y to try again or X to exit

void NumberStats(double number)
{
    bool isNegative = number < 0 ? true : false;
    bool isDecimal = number % 1 > 0 ? true : false;
    bool isEven = number % 2 == 0 ? true : false;

    Console.WriteLine($"stats for number {number}");
    Console.WriteLine(string.Format("{0}", isNegative ? "Negative" : "Positive"));
    Console.WriteLine(string.Format("{0}", isDecimal ? "Decimal" : "Integer"));
    Console.WriteLine(string.Format("{0}", isEven ? "Even" : "Odd"));
}

bool UserInterface()
{
    Console.WriteLine("Enter a number");
    double number;
    bool isNumber = double.TryParse(Console.ReadLine(), out number);
    if (!isNumber)
    {
        Console.WriteLine("Please enter a valid number");
        return false;
    }
    NumberStats(number);
    Console.WriteLine("Press any key to try again or X to exit!");

    if (Console.ReadLine().ToUpper() == "X")
    {
        return true;
    }
    return false;
}

while (!UserInterface()) ;


//while (!UserInterface()) ;

// void NumberStats(double number)
//{
//    bool isNegative = number < 0;
//    bool isDecimal = number % 1 != 0;
//    bool isEven = number % 2 == 0;

//    Console.WriteLine($"Stats for number: {number}");
//    Console.WriteLine(isNegative ? "Negative" : "Positive");
//    Console.WriteLine(isDecimal ? "Decimal" : "Integer");
//    Console.WriteLine(isEven ? "Even" : "Odd");
//}

// bool UserInterface()
//{
//    Console.WriteLine("Enter a number:");
//    double number;
//    bool isNumber = double.TryParse(Console.ReadLine(), out number);
//    if (!isNumber)
//    {
//        Console.WriteLine("Please enter a valid number.");
//        return false;
//    }

//    NumberStats(number);

//    Console.WriteLine("Press any key to try again or X to exit.");
//    string choice = Console.ReadLine().ToUpper();
//    return choice == "X";
//}
