Dictionary<string, long> phoneBook = new Dictionary<string, long>()
{    
    {"Petko",  070123123},  // the leading 0 will not be printed, if we want to see the 0, we need to make the phone number a string
    {"Nikola", 070456456},
    {"Stefan", 070789789},
    {"Ana",    070147147},
    {"marko",  070258258}
};

Console.WriteLine("Enter a name: ");
string input = Console.ReadLine();  // if we only click enter it will have the value of an empty string


// if ((input == null || input == ''))       // '' --> means empty string
// '' != ' '  // the first one is an empty string and the second one is a space character
{
    
}
if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("Invalid input");
}
else
{
    // One way:
    bool isFound = false;
    foreach (var phone in phoneBook)
    {
        if (phone.Key.ToLower() == input.ToLower())
        {
            isFound = true;
            Console.WriteLine(phone.Value);
            break; // we do not need to iterate anymore if we found the name  as the key must be unique
        }
    }
    if(!isFound)
    {
        Console.WriteLine("No phone number found in the phone book");
    }

    // Second way:
    if (phoneBook.ContainsKey(input)) // check if the dictionary contains a record with a key that is the same as the input
    {
        Console.WriteLine($"The phone number of {input} is {phoneBook[input]}");
    }
    else
    {
        Console.WriteLine("No phone number found in the phone book");
    }



}

