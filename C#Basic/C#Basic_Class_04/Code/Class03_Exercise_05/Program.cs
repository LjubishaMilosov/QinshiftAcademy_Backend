//Declare a new array of integers with 5 elements
//Initialize the array elements with values from input
//Sum all the values and print the result in the console

using System;

int[] ourIntArray = new int[5];  // here e only tell it that ourIntArray will have 5 elements

for(int i = 0; i < ourIntArray.Length; i++)
{
    Console.WriteLine("Please enter a value for index: " i);
    
    bool success = int.TryParse(Console.ReadLine(), out ourIntArray[i]); // hre if the parse is not successful, it will put  the vlue 0 in ourIntArray[i]

    //string input = Console.ReadLine();
    //bool success2 = int.TryParse(input, out int number);

    //if (success2)
    //{
    // ourIntArray[i] = number;
    //}
    //else
    //{
    //Console.WriteLine("WrongInput!");
    // break;
    //}
}

int sum = 0;
foreach (var (int item in ourIntArray)
{
    sum += sum;
}
Console.WriteLine("The sum is: " + sum);