//Create an ATM application. A customer should be able to authenticate with card number and pin and should be greeted with a message greeting them by full name.
//After that they can choose one of the following:

//Balance checking - This should print out the current balance of money on their account
//Cash withdrawal - This should try and withdraw cash from the users account and print a message.
//If it has enough it should print a success message that contains the money withdrawn and the balance of money after the withdrawal
//Cash deposit - This should deposit cash on the account and give a message with the new balance of money on the account after the deposit.
//In order for the ATM app to work we need Customers.
//This ATM asks for the number ( string ) of the card and searches through the customers if a card like that exists.
//After that it asks for a pin. If the Pin matches that customer a welcome message is shown and the customer can now choose the options.

//Example
//Welcome to the ATM app
//Please enter your card numer:
//> 1234 - 1234 - 1234 - 1234
//Enter Pin:
//> 4325
//Welcome Bob Bobsky!
//What would you like to do:
//Check Balance
//Cash Withdrawal
//Cash Deposit
//> 2
//You withdrew 250$. You have 400$ left on your account.
//Thank you for using the ATM app.

//Bonus: The balance and pin should not be public

//Bonus: The ATM card number to be a number instead of a string. The user should still input 1234-1234-1234-1234.

//Bonus: When the Customer finishes with a transaction a question must pop up if the Customer wants to do another action.
//If not it should print a goodbye message and show up the login menu again.

//Bonus: Add an option to register a new card in the system that store the customer in the system if the card number is not used for any other customer

using class06_workshop_exercise_03;

//Customer[] customers = new Customer[]
//        {
//            new Customer(1234123412341234, 4325, "Ivan Ivanovski", 784),
//            new Customer(1111222233334444, 1234, "Jovan Jovanovski", 1200),
//            new Customer(5555666677778888, 5678, "Ile Ilievski", 331)
//        };

//while (true)
//{
//    Console.WriteLine("Welcome to the ATM app");
//    Console.WriteLine("Please enter your card number (format: 1234-1234-1234-1234):");
//    string cardNumberInput = Console.ReadLine().Replace("-", "");
//    if (!long.TryParse(cardNumberInput, out long cardNumber))
//    {
//        Console.WriteLine("Invalid card number format.");
//        continue;
//    }

//    Console.WriteLine("Enter Pin:");
//    if (!int.TryParse(Console.ReadLine(), out int pin))
//    {
//        Console.WriteLine("Invalid pin format.");
//        continue;
//    }

//    //Customer customer = customers.FirstOrDefault(c => c.CardNumber == cardNumber && c.Pin == pin);
//    //if (customer == null)
//    //{
//    //    Console.WriteLine("Invalid card number or pin.");
//    //    continue;
//    //}

//    Customer customer = FindCustomer(cardNumber, pin);
//    if (customer == null)
//    {
//        Console.WriteLine("Invalid card number or pin.");
//        continue;
//    }

//    Console.WriteLine($"Welcome {customer.FullName}!");

//    bool exit = false;
//    while (!exit)
//    {
//        Console.WriteLine("What would you like to do:");
//        Console.WriteLine("1. Check Balance");
//        Console.WriteLine("2. Cash Withdrawal");
//        Console.WriteLine("3. Cash Deposit");
//        Console.WriteLine("4. Exit");

//        string choice = Console.ReadLine();
//        switch (choice)
//        {
//            case "1":
//                Console.WriteLine($"Your current balance is: ${customer.GetBalance()}");
//                break;
//            case "2":
//                Console.WriteLine("Enter amount to withdraw:");
//                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
//                {
//                    if (customer.Withdraw(withdrawAmount))
//                    {
//                        Console.WriteLine($"You withdrew ${withdrawAmount}. You have ${customer.GetBalance()} left on your account.");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Insufficient funds.");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Invalid amount.");
//                }
//                break;
//            case "3":
//                Console.WriteLine("Enter amount to deposit:");
//                if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
//                {
//                    customer.Deposit(depositAmount);
//                    Console.WriteLine($"You deposited ${depositAmount}. Your new balance is ${customer.GetBalance()}.");
//                }
//                else
//                {
//                    Console.WriteLine("Invalid amount.");
//                }
//                break;
//            case "4":
//                exit = true;
//                break;
//            default:
//                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
//                break;
//        }

//        if (!exit)
//        {
//            Console.WriteLine("Press any key to try again or X to exit!");
//            if (Console.ReadLine().ToUpper() == "X")
//            {
//                exit = true;
//            }
//        }
//    }

//    Console.WriteLine("Thank you for using the ATM app. Goodbye!");
//}
//Customer FindCustomer(long cardNumber, int pin)
//{
//    return customers.FirstOrDefault(c => c.CardNumber == cardNumber && c.Pin == pin);
//}



Customer[] customers = new Customer[]
   {
        new Customer(1234123412341234, 4325, "Ivan Ivanovski", 784m),
        new Customer(1111222233334444, 1234, "Jovan Jovanovski", 1200m),
        new Customer(5555666677778888, 5678, "Ile Ilievski", 331m)
   };

    while (true)
    {
        Console.WriteLine("Welcome to the ATM app");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register a new card");
        Console.WriteLine("3. Exit");

        string initialChoice = Console.ReadLine();
        switch (initialChoice)
        {
            case "1":
                Login();
                break;
            case "2":
                RegisterNewCard();
                break;
            case "3":
                Console.WriteLine("Thank you for using the ATM app. Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                break;
        }
    }


void Login()
{
    Console.WriteLine("Please enter your card number (format: 1234-1234-1234-1234):");
    string cardNumberInput = Console.ReadLine().Replace("-", "");
    if (!long.TryParse(cardNumberInput, out long cardNumber))
    {
        Console.WriteLine("Invalid card number format.");
        return;
    }

    Console.WriteLine("Enter Pin:");
    if (!int.TryParse(Console.ReadLine(), out int pin))
    {
        Console.WriteLine("Invalid pin format.");
        return;
    }

    Customer customer = FindCustomer(cardNumber, pin);
    if (customer == null)
    {
        Console.WriteLine("Invalid card number or pin.");
        return;
    }

    Console.WriteLine($"Welcome {customer.FullName}!");

    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("What would you like to do:");
        Console.WriteLine("1. Check Balance");
        Console.WriteLine("2. Cash Withdrawal");
        Console.WriteLine("3. Cash Deposit");
        Console.WriteLine("4. Exit");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine($"Your current balance is: ${customer.GetBalance()}");
                break;
            case "2":
                Console.WriteLine("Enter amount to withdraw:");
                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                {
                    if (customer.Withdraw(withdrawAmount))
                    {
                        Console.WriteLine($"You withdrew ${withdrawAmount}. You have ${customer.GetBalance()} left on your account.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
                break;
            case "3":
                Console.WriteLine("Enter amount to deposit:");
                if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                {
                    customer.Deposit(depositAmount);
                    Console.WriteLine($"You deposited ${depositAmount}. Your new balance is ${customer.GetBalance()}.");
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
                break;
            case "4":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                break;
        }

        if (!exit)
        {
            Console.WriteLine("Press any key to try again or X to exit!");
            if (Console.ReadLine().ToUpper() == "X")
            {
                exit = true;
            }
        }
    }

    Console.WriteLine("Thank you for using the ATM app. Goodbye!");
}

void RegisterNewCard()
{
    Console.WriteLine("Enter new card number (format: 1234-1234-1234-1234):");
    string cardNumberInput = Console.ReadLine().Replace("-", "");
    if (!long.TryParse(cardNumberInput, out long cardNumber))
    {
        Console.WriteLine("Invalid card number format.");
        return;
    }

    if (customers.Any(c => c.CardNumber == cardNumber))
    {
        Console.WriteLine("Card number already exists. Please try again.");
        return;
    }

    Console.WriteLine("Enter Pin:");
    if (!int.TryParse(Console.ReadLine(), out int pin))
    {
        Console.WriteLine("Invalid pin format.");
        return;
    }

    Console.WriteLine("Enter Full Name:");
    string fullName = Console.ReadLine();

    Console.WriteLine("Enter Initial Balance:");
    if (!decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
    {
        Console.WriteLine("Invalid balance format.");
        return;
    }

    Array.Resize(ref customers, customers.Length + 1);
    customers[customers.Length - 1] = new Customer(cardNumber, pin, fullName, initialBalance);

    Console.WriteLine("New card registered successfully!");
}

Customer FindCustomer(long cardNumber, int pin)
{
    return customers.FirstOrDefault(c => c.CardNumber == cardNumber && c.Pin == pin);
}
