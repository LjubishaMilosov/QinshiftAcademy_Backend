//Methods

// method wit no params and no return values
// void represents that the method does not return anything
void Printmessage()
{
    Console.WriteLine("hello from our first method");   
}

Printmessage();

// method with string param and no return values
void Greeting(string name)
{
    Console.WriteLine("Hello, " + name);
}
Greeting("G6"); // expects a string
                // Greeting(10); - error -> expects a string
                // Greeting(); - error -> expects a string

void PrintInfo(string name, int age)
{
    Console.WriteLine("Name: " + name + " Age: " + age);
}
PrintInfo("Tijana", 25);


// return values

string GetMessage()
{
    return "Hello from GetMessage()";
}
string message = GetMessage();
Console.WriteLine(message);
Console.WriteLine(GetMessage());


string CheckIfItIsTheWeekend(bool isWeekened)
{
    if (isWeekened)
    {
        return "It is the weekend";
    }
    else
    {
        return "It is not the weekend";
    }
}

string weekendMessage = CheckIfItIsTheWeekend(false);
Console.WriteLine(weekendMessage);
Console.WriteLine(CheckIfItIsTheWeekend(true));