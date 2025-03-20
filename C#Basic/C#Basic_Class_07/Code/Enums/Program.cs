
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


