

Console.WriteLine("Please enter a number: ");
bool firstSuccess = int.TryParse(Console.ReadLine(), out int firstNumber);

if(firstSuccess)
{
    for(int i = 1; i <= firstNumber; i++)
    {
        Console.WriteLine(i);
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
    for (int i = secondNumber; i >= 1; i--)
    {
        Console.WriteLine(i);
    }
}
else
{
    Console.WriteLine("Invalid input");
}