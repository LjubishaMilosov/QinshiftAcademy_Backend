namespace Enums
{
    public enum DayOfWeekEnum  //we change the name of our enum and we usuall add Enum at the end of the name
    {
        //if we don't specify the value of the first enum, we will have value zero
        Monday = 1,
        Tuesday, // the next value will have the previous enum value + 1
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
