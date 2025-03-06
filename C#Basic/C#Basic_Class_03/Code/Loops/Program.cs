// FOR

for(int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

for (; ; )
{
    Console.WriteLine("Enter x to exit the loop");
    string input = Console.ReadLine();

    if (input == "x" || input == "X")
    {
        break;
    }
    else
    {
        Console.WriteLine($"Input was {input}");
    }
}


//  print all numbers from 1 to 7, except 5 and exit after it gets to 7

for(int i = 0; i <= 10; i++)
{
    if (i == 5)
    {
        continue;  // it skips the current iteration and goes back to i++
    }
    Console.WriteLine("I: " + i);
    if(i == 7)
    {
        break;  // it breaks the for loop(exits the loop
    }
}


// WHILE

int counter = 0;

while(counter <=5)
{
    Console.WriteLine("Counter: " + counter);
    counter++;// we need to change the value of counter in order not enter an infinite loop
}

while(true) // infinite loop
{
    Console.WriteLine("Enter x to exit the loop");
    string input = Console.ReadLine();
    if (input == "x" || input == "X")
    {
        break;
    }
    else
    {
        Console.WriteLine($"Input was {input}");
    }
}


// use While, count 1-10, skip 3 and 5

int number = 1;
while(number <= 10)
{
    if(number == 3 || number == 5)
    {
        // carefull, put the code for incrementing(moving forward) before continue so we don't enter an infinite loop
        number++;
        continue; // everything after continue is not executed in the current iteration
    }
    Console.WriteLine("Number: " + number);
    number++;
}

// DO WHILE

do
{
    Console.WriteLine("This will be executed at least once");   
} while (false);