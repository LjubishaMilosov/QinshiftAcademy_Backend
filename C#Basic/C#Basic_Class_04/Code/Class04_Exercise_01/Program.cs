int Sum(int a, int b)
{
    return a + b;
}

int Substract(int a, int b)
{
    return a - b;
}


Console.WriteLine("Enter the first number:");
bool firstSucces = int.TryParse(Console.ReadLine(), out int firstNumber);

Console.WriteLine("Enter the second number:");
bool secondSucces = int.TryParse(Console.ReadLine(), out int secondNumber);

Console.WriteLine("Enter + or -");
string op = Console.ReadLine(); 

if(firstSucces && secondSucces)
{
    if(op == "+")
    {
        int sum = Sum(firstNumber, secondNumber);
        Console.WriteLine("The sum is: " + sum);
    }
    else if(op == "-")
    {
        int substract = Substract(firstNumber, secondNumber);
        Console.WriteLine("The substract is: " + substract);
    }
    else
    {
        Console.WriteLine("Invalid operator");
    }
}
else
{
    Console.WriteLine("Invalid input");
}