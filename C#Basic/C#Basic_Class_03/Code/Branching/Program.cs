// if- else

int firstNumber = 5;
int secondNumber = 6;
if(firstNumber == secondNumber)
{
    Console.WriteLine("The numbers are equal");
}
else
{
    Console.WriteLine("The numbers are not equal");
}

if(firstNumber > secondNumber)
{
    Console.WriteLine("The first number is greater than the second number");
}
else if (firstNumber < secondNumber)
{
    Console.WriteLine("The first number is less than the second number");
}
else
{
    Console.WriteLine("The numbers are not equal");
}
// SWITCH

Console.WriteLine("Please enter a number between 1 and 7");
//int day;
//string input = Console.ReadLine();
//bool success = int.TryParse(input), out day);
bool success = int.TryParse(Console.ReadLine(), out int day);

if(success)
{
    // this is the case when the parsing was successful
    switch(day)
    {
        case 1:
            Console.WriteLine("Monday");
            break;
        case 2:
        case 3:  
        case 4:
        case 5:
            Console.WriteLine("Working day but at least it's not Monday!");
            break;
        case 6:
        case 7:
            Console.WriteLine("It's the Weekend");
            break;
        default:
            Console.WriteLine("Invalid input!Please enter a number between 1 and 7");
            break;
    }
}
else
{
    Console.WriteLine("Invalid input!Please enter a number between 1 and 7");
}