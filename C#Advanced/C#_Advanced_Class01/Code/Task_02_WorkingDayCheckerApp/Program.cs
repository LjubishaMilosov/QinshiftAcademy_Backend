using System;
using System.Globalization;

  
        // List of non-working days
        var nonWorkingDays = new[]
        {
            new DateTime(DateTime.Now.Year, 1, 1), 
            new DateTime(DateTime.Now.Year, 1, 7),  
            new DateTime(DateTime.Now.Year, 4, 20), 
            new DateTime(DateTime.Now.Year, 5, 1),
            new DateTime(DateTime.Now.Year, 5, 25), 
            new DateTime(DateTime.Now.Year, 8, 3), 
            new DateTime(DateTime.Now.Year, 9, 8),
            new DateTime(DateTime.Now.Year, 10, 12),
            new DateTime(DateTime.Now.Year, 10, 23),
            new DateTime(DateTime.Now.Year, 12, 8)
        };

        bool continueChecking = true;

        while (continueChecking)
        {
            Console.WriteLine("Enter a date (yyyy-MM-dd):");
            string input = Console.ReadLine();

            if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime enteredDate))
            {
                if (IsWorkingDay(enteredDate, nonWorkingDays))
                {
                    Console.WriteLine($"{enteredDate:yyyy-MM-dd} is a working day.");
                }
                else
                {
                    Console.WriteLine($"{enteredDate:yyyy-MM-dd} is not a working day.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
            }

            Console.WriteLine("Do you want to check another date? (yes/no):");
            string response = Console.ReadLine()?.Trim().ToLower();

            if (response != "yes")
            {
                continueChecking = false;
            }
        }

        Console.WriteLine("Thank you for using the application. Goodbye!");
    

    static bool IsWorkingDay(DateTime date, DateTime[] nonWorkingDays)
    {
        // Check if the date is a weekend
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            return false;
        }

        // Check if the date is in the list of non-working days
        foreach (var nonWorkingDay in nonWorkingDays)
        {
            if (date.Date == nonWorkingDay.Date)
            {
                return false;
            }
        }

        return true;
    }
