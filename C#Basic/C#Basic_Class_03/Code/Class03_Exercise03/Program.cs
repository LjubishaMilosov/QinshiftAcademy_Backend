

Console.WriteLine("Please enter a number: ");
bool success = int.TryParse(Console.ReadLine(), out int number);

if(success)
{
    for(int i = 1; i <= number; i++)
    {
        if(i % 3 == 0 || i % 7 == 0)
        {
            continue;
        }
        Console.WriteLine(i);

        if (i == 100)
        {
            Console.WriteLine("The limit is reached");
            break;
        }
    }
}
else
{
    Console.WriteLine("Invalid input");
}