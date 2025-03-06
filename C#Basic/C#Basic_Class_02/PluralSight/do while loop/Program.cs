string selectedAction;

do
{
    Console.WriteLine("Chooose the action you want to do: ");
    Console.WriteLine("1. Add employee");
    Console.WriteLine("2. Update employee");
    Console.WriteLine("3. Delete employee");
    Console.WriteLine("99. Exit application");
    selectedAction = Console.ReadLine();

    switch (selectedAction)
    {
        case "1":
            Console.WriteLine("Adding new employee");
            break;
        case "2":
            Console.WriteLine("Updating employee");
            break;
        case "3":
            Console.WriteLine("Deleting employee");
            break;
        default:
            Console.WriteLine("Invalid selection");
            break;
    }
} while (selectedAction != "99") ;
    Console.WriteLine("Exiting application");
