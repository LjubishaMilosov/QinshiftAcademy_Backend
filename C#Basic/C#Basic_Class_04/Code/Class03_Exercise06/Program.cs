//Create an array with names
//Give an option to the user to enter a name from the keyboard
//After entering the name put it in the array
//Ask the user if they want to enter another name(Y / N)
//Do the same process over and over until the user enters N
//Print all the names after user enters N
//
//string[] names = new string[0];  // empty array -> 0 represents the number of elments
//string names2 = new string[] { };  // empty array

//int i = 0;

//while(true)
//{
//    Console.WriteLine("Enter a name: ");
//    string name = Console.ReadLine();

//    // we need to change the size of our array
//    Array.Resize(ref names, names.Length + 1);  // we are increasing the size of the array by 1
//    names[i] = name;
//    i++;

//    // names[names.Length - 1] = name;  // -. another way- withouth using counter: names.length - 1 is always the index of the last element

//    Console.WriteLine("Do you want to enter asnother name (Y/N?)");
//    string input = Console.ReadLine();
//    if(input == "n" || input == "N")
//    {
//        break;
//    }   
//}


string[] names = new string[0];  // empty array -> 0 represents the number of elements
int i = 0;
string input;

do
{
    Console.WriteLine("Enter a name: ");
    string name = Console.ReadLine();

    Array.Resize(ref names, names.Length + 1);  // we are increasing the size of the array by 1
    names[i] = name;
    i++;

    Console.WriteLine("Do you want to enter another name (Y/N?)");
    input = Console.ReadLine();
}
while (input != "n" && input != "N");

