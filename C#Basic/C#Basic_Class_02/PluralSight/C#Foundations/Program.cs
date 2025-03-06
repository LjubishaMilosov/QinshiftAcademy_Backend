//DateTime hireDate = new DateTime(2025, 3, 3, 14, 30, 0);
//Console.WriteLine("Hire date: " + hireDate);

//DateTime exitDate = new DateTime(2026, 1, 11);

//DateTime startDate = hireDate.AddDays(15);
//Console.WriteLine(startDate);

//DateTime currentDate = DateTime.Now;
//bool areWeInDst = currentDate.IsDaylightSavingTime();
//Console.WriteLine(areWeInDst);


//int age = 20;
//if(age < 18)
//{
//    Console.WriteLine("Too young to work");
//}
//    Console.WriteLine("Old enough to work");


//Console.WriteLine("Enter a value: ");
//int max = int.Parse(Console.ReadLine());
//int i = 0;
//while(i < max)
//{
//    Console.WriteLine(i);
//    i++;

//}
//Console.WriteLine("Loop finished");

//int i = 10;
//while(i > 0)
//{
//    Console.WriteLine(i);
//    i--;
//}

//Console.WriteLine("Chooose the action you want to do: ");
//Console.WriteLine("1. Add employee");
//Console.WriteLine("2. Update employee");
//Console.WriteLine("3. Delete employee");
//Console.WriteLine("99. Exit application");

//string selectedAction = Console.ReadLine();
//while (selectedAction != "99")
//  { 
//    switch(selectedAction)
//    {
//    case "1":
//        Console.WriteLine("Adding new employee");
//        break;
//    case "2":
//        Console.WriteLine("Updating employee");
//        break;
//    case "3":
//        Console.WriteLine("Deleting employee");
//        break;
//    default:
//        Console.WriteLine("Invalid selection");
//        break;
//    }
//    Console.WriteLine("Chooose the action you want to do: ");
//    Console.WriteLine("1. Add employee");
//    Console.WriteLine("2. Update employee");
//    Console.WriteLine("3. Delete employee");
//    Console.WriteLine("99. Exit application");
//    selectedAction = Console.ReadLine();

//}
//Console.WriteLine("Exiting application");

int i = 0;
int j = 0;
while (i <10)
{
    while(j < 10)
    { Console.WriteLine("i: " + i + " j: " + j);
        j++;
    }
    j = 0;
    i++;
}