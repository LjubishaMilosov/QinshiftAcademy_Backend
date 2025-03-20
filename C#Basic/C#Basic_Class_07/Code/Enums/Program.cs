
using Enums;

int day = 5;

if(day == 5) // not a good practice, not clear
{
    Console.WriteLine();
}

if(day == (int)DayOfWeekEnum.Friday) // we need to convert(cast, get the value from the enum) the enum to int so that we can compare it to another int
{
    Console.WriteLine("Yaay it is Friday");
}


int roleNumber = 1;

if (roleNumber == (int)RoleEnum.Administrator)
{
    Console.WriteLine($"This is the {RoleEnum.Administrator.ToString()}");
}
else if (roleNumber == (int)RoleEnum.User)
{
    Console.WriteLine($"This is the {RoleEnum.User.ToString()}");
}


// (int)RoleEnum.Administrator;           // this way we get the value (number value) of the enum
// RoleEnum.Administrator.ToString();     // this way we get the name of the enum  

Console.ReadLine();