
using Exercise_02;

//  Dog dog1 = new Dog();

Console.WriteLine("Enter the dog's name: ");
string name = Console.ReadLine();
//  dog1.Name = Console.ReadLine();

Console.WriteLine("Enter the dog's race: ");    
string race = Console.ReadLine();

// dog1.Race = Console.ReadLine();

Console.WriteLine("Enter the dog's color: ");
string color = Console.ReadLine();

// dog1.Color = Console.ReadLine();

Dog dog = new Dog(name, race, color);

Console.WriteLine("Choose an action: \n 1. Feed the dog \n 2. Play with the dog \n 3. Chase its tail");

void DogOptions(Dog dog, int option)
{
    switch (option)
    {
        case 1:
            Console.WriteLine(dog.Eat());
            break;
        case 2:
            Console.WriteLine(dog.Play());
            break;
        case 3:
            Console.WriteLine(dog.ChaseTail());
            break;
        default:
            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
            break;
    }
}

int result; // we need to declare it outside the while lop to be able to use it
while (!int.TryParse(Console.ReadLine(), out result)) //We initialize  result in the while loop condition
{
    Console.WriteLine("You have entered a wrong option");
    Console.WriteLine("Choose an action: \n 1. Feed the dog \n 2. Play with the dog \n 3. Chase its tail");
}

DogOptions(dog, result);


//string choice;
//bool validChoice = false;

//while (!validChoice)
//{
//    Console.WriteLine("Choose an action: \n 1. Feed the dog \n 2. Play with the dog \n 3. Chase its tail");
//    choice = Console.ReadLine();

//    switch (choice)
//    {
//        case "1":
//            Console.WriteLine(dog.Eat());
//            validChoice = true;
//            break;
//        case "2":
//            Console.WriteLine(dog.Play());
//            validChoice = true;
//            break;
//        case "3":
//            Console.WriteLine(dog.ChaseTail());
//            validChoice = true;
//            break;
//        default:
//            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
//            break;
//    }
//}