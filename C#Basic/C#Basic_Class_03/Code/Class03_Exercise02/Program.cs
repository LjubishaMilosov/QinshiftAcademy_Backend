//Get an input number from the console
//Print all even numbers starting from 2
//Get another input number from the console
//Print all odd numbers starting from 1

Console.WriteLine("Please enter a number: ");
bool firstSuccess = int.TryParse(Console.ReadLine(), out int firstNumber);

if (firstSuccess)
{
    for (int i = 2; i <= firstNumber; i+=2)
    {
        Console.WriteLine(i);
    }
    for (int i = 2; i <= firstNumber; i++)
    {
        if (i % 2 == 0)
        {
            Console.WriteLine(i);
        }
    }
}
else
{
    Console.WriteLine("Invalid input");
}

Console.WriteLine("Please enter another number: ");
bool secondSuccess = int.TryParse(Console.ReadLine(), out int secondNumber);

if (secondSuccess)
{
    for(int i = 1; i<=secondNumber; i +=2)
    {
        Console.WriteLine(i);
    }
    for (int i = 1; i <= secondNumber; i++)
    {
        if (i % 2 != 0)
        {
            Console.WriteLine(i);
        }
    }
} 
else
{
    Console.WriteLine("Invalid input");
}