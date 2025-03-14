// DateTime

using System.Data;

DateTime emptyDateTime = new DateTime();
Console.WriteLine(emptyDateTime); // 1/1/0001 12:00:00 AM

// create DateTime with current Date and Time(local date and time, from the server)
DateTime currentDateTime =DateTime.Now;
Console.WriteLine(currentDateTime);

DateTime universalDateTime = DateTime.UtcNow; // UTC time
Console.WriteLine(universalDateTime);

// create DateTime with specific date and time
DateTime specificDateTime = new DateTime(1999, 07, 28);
Console.WriteLine(specificDateTime);

DateTime specificDateTime2 = new DateTime(2022, 12, 31, 23, 59, 59); // year, month, day, hour, minute, second
Console.WriteLine(specificDateTime2);

int day = currentDateTime.Day;
Console.WriteLine(day);

int month = currentDateTime.Month;
Console.WriteLine(month);

int year = currentDateTime.Year;
Console.WriteLine(year);

var dayOfTheWeek = currentDateTime.DayOfWeek;
Console.WriteLine(dayOfTheWeek);

DateTime firstDateTime = new DateTime(2000, 2, 3, 15, 55, 20);
DateTime secondDateTime = new DateTime(2005, 11, 3, 19, 28, 20);

var difference = secondDateTime - firstDateTime;
Console.WriteLine(difference); // 2117.03:33:00

int days = difference.Days;
int hours = difference.Hours;
int minutes = difference.Minutes;
Console.WriteLine(days);
Console.WriteLine(hours);
Console.WriteLine(minutes);

//get the date and time 5 days from now
DateTime fiveDaysAhed = currentDateTime.AddDays(5);
Console.WriteLine(fiveDaysAhed);

//get the date and time 5 days and 5 hours from now
DateTime fiveDaysAndFiveHoursAhead = currentDateTime.AddDays(5).AddHours(5);
Console.WriteLine(fiveDaysAndFiveHoursAhead);


// get the date and time 2 years and 3 months ago
DateTime threeMonthsAndTwoYearsAgo = currentDateTime.AddMonths(-3).AddYears(-2);
Console.WriteLine(threeMonthsAndTwoYearsAgo);

// formating datetime to string

string formattedDate = DateTime.Now.ToString("dd.MM.yyyy");  //11.03.2025
Console.WriteLine(formattedDate);

string anotherFormattedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy");
Console.WriteLine(anotherFormattedDate);