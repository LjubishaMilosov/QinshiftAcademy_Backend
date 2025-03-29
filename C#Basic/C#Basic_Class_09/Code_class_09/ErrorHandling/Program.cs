try
{
    // in try block we write the code that we want to be ecuted and that might throw an error
    Console.WriteLine("Enter a number: ");
    string input = Console.ReadLine();

    int number = int.Parse(input); //if we enter a wrong input, this line will throw an exception

    // this line will be executed only if the lines above don't throw an error
    // otherwise we will be redirected to the catch block
    Console.WriteLine(number);
}
catch(Exception ex)
{
    //the catch block will be executed only if an exception is thrown in the try block
    Console.WriteLine("The input you entered was not a correct number");
    Console.WriteLine(ex.Message);
}
finally
{
    // the finally block will be executed no matter what
    Console.WriteLine("This is the finally block");
}

// THROWING AN EXCEPTION

try
{
    Console.WriteLine("Please enter 'a' or 'b': ");
    string character = Console.ReadLine();
    if(character.ToLower() == "a" || character.ToLower() == "b")
    {
        Console.WriteLine("You entered the correct character");
    }
    else
    {
        throw new Exception("User did enter a or b");
    }

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}