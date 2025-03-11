//Strings

using System.Security.Cryptography.X509Certificates;

string message = "We are learning about stings";
string academy = "Qinshift";

//concatenation
string firstMessage = message + " at " + academy;
Console.WriteLine(firstMessage);

//interpolation
string secondMessage = $"{message} at {academy}";
Console.WriteLine(secondMessage);

int year = 2025;
string thirdMessage = $"Welcome to {academy} in {year} year";
Console.WriteLine(thirdMessage);


// formatting strings
string fourthMessage = string.Format("Welcome to {0} in {1} year!", academy, year);
Console.WriteLine(fourthMessage);

// escape characters
string escapeCharacters = "We are learning \"C#\" at \"Qinshift\"";
  
string firstString = "Check your c:\\drive";

string secondString = "We wil have \"fair\" elections";

// \n means new line
string thirdString = "This is first line. \n This is second line";
Console.WriteLine(thirdString);

string driveMessage = @"Check your C:|drive and D:\drive"; // "Check your C:\\drive and your D:\\drive";
Console.WriteLine(driveMessage);

string quotesString = @"We will have ""fair"" elections";
Console.WriteLine(quotesString);

string percentString = string.Format("{0:P} participated in the elections", 0.75);
Console.WriteLine(percentString);

string phoneNumber = string.Format("{0:+389##-###-###}", 70123456);  // +38970-123-456
Console.WriteLine(phoneNumber);

Console.ReadLine();