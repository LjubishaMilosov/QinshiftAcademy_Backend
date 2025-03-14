//String Methods

using System;

string ourString = "    We are learning C# and it is FUN and EASY. Okay maybe just FUN.        ";
Console.WriteLine(ourString);

string lowerCaseString = ourString.ToLower();
string uppperCaseString = ourString.ToUpper();
Console.WriteLine(uppperCaseString);
Console.WriteLine(lowerCaseString);

// length of the string
Console.WriteLine("The length of our string is: " + ourString.Length);

// we use Split() method to split the string into an array of strings. a separator is needed to split the string
string[] splittedString = ourString.Split('.');
Console.WriteLine(splittedString.Length); // ourString has been split into 3 strings
Console.WriteLine(splittedString[0]);
Console.WriteLine(splittedString[1]);
Console.WriteLine(splittedString[2]);

//Replace
string stringWithDots = "Hello. from. G6";
string replacedStringWithoutDots = stringWithDots.Replace(".", "");
string replacedStringWithQuestionMarks = stringWithDots.Replace(".", "?");
Console.WriteLine(stringWithDots);
Console.WriteLine(replacedStringWithoutDots);
Console.WriteLine(replacedStringWithQuestionMarks);

//startsWith
string test = "Test";
// returns a boolean whether the string starts with the given string or not
bool startsWithTest = test.StartsWith("Te"); // we can send as many characters as we need
Console.WriteLine(startsWithTest); // true

bool startsWith2 = test.StartsWith("te");
Console.WriteLine(startsWith2); // false

//IndexOf
int indexOfFun = ourString.IndexOf("FUN");
int indexOfJs = ourString.IndexOf("JS");
Console.WriteLine(indexOfFun);
Console.WriteLine(indexOfJs);

// contains
bool containsFun = ourString.Contains("FUN"); // true
bool containsJS = ourString.Contains("JS"); // false
Console.WriteLine(containsFun);
Console.WriteLine(containsJS);

//Trim method removes all leading and trailing white-space characters from the current String object.
string trimmedString = ourString.Trim();
Console.WriteLine(trimmedString);



//Substring
string substring = ourString.Substring(6, 16); // take the substring staring from index 5  and the 16 characters
Console.WriteLine(substring);

// toCharArray
char[] charArray = ourString.ToCharArray();
foreach (char c in charArray)
{
    Console.WriteLine(c);
}

// Split() method can be used to split the string into an array of strings. a separator is needed to split the string 
//in our example, the string is split into an array of words using the white space separator
string[] words = ourString.Split(" ");
foreach (string word in words)
{
    Console.WriteLine(word);
}

Console.ReadLine();