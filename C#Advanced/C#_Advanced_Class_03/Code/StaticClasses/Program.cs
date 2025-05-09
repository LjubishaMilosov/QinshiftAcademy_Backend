using StaticClasses.Domain;
using StaticClasses.Domain.Enums;
using StaticClasses.Domain.Helpers;
using StaticClasses.Domain.Models;

Order order = new Order(0, "First order", "Our first order", OrderStatusEnum.Created);
Console.WriteLine(order.Description); // we access the non-static member using the object (instance) of the class
order.PrintTitle(); // we access the non-static member using the object (instance) of the class

//order.IsValid(); // this will not work because IsValid is a static method and we are trying to access it using
                 // the object (instance) of the class
Console.WriteLine(Order.IsValid(order)); // we access the static member using the class name

Console.WriteLine("Welcome to our ordering app");
Console.WriteLine("Please choose the number of your user:");

OrdersDb.PrintUsers(); // we access the static member using the class name
string input = Console.ReadLine();

//validation
int userChoice = TextHelper.ValidateInput(input);

//because our Orders is a tic list in a static class we need to access it by the class name
Order lastorder = OrdersDb.Orders.LastOrDefault();
if(lastorder != null)
{ 
    Console.WriteLine("The last Id of the order is: " + lastorder.Id);
}

if(userChoice == -1)
{
    Console.WriteLine("Invalid Input");
}
else
{
    User currentUser = OrdersDb.Users[userChoice - 1]; // the user choices ae order numbers from 1,2...while the indexes are 0,1...
    if (currentUser == null) // if the er entered a number, but a number that was not on the list()the number validation was ok but the choice was not correct
    {
        throw new Exception("User does not exist");
    }
    Console.WriteLine("Choose an option: ");
    Console.WriteLine("1. Print your orders");
    Console.WriteLine("2. Add new order");
    string optionInput = Console.ReadLine();

    int optionChoice = TextHelper.ValidateInput(optionInput);
    if (optionChoice == -1)
    {
        Console.WriteLine("Invalid Input");
    }
    else
    {
        if (optionChoice == 1)
        {
            currentUser.PrintOrders(); // User is a standard class and PrintOrders is a standard method
                                       // so we can access it using the object (instance) of the class
        }
        else if (optionChoice == 2)
        {
            // 1. enter data for the new order
            Console.WriteLine("Enter the title of the order: ");
            string titleInput = Console.ReadLine();
            Console.WriteLine("Enter the description of the order: ");
            string descriptionInput = Console.ReadLine();

            //2. validate the data
            if (string.IsNullOrEmpty(titleInput) || string.IsNullOrEmpty(descriptionInput))
            {
                throw new Exception("Title and Description must not be null");
            }
            else
            {
                //3. create the new order
                Order newOrder = new Order();
                newOrder.Title = titleInput;
                newOrder.Description = descriptionInput;
                newOrder.PrintTitle(); // PrintTitle is not a static method, so we need to access it using the object (instance) of the class
                Order.IsValid(newOrder); // IsValid is a static method, so we need to access it using the class name

                //4. add the new order to the user
                OrdersDb.InsertOrder(currentUser.Id, newOrder);
                
                Console.WriteLine("Successfully adde new order");
                
                currentUser.PrintOrders(); // User is a standard class and PrintOrders is a standard method
                                           // so we can access it using the object (instance) of the class
            }
        }
        
    }
}



//{
//    Console.WriteLine("Invalid Input");
//}
//    else
//{
//    Console.WriteLine($"You have chosen user {currentUser.Username}");
//    Console.WriteLine("Please choose the number of your order:");
//    int i = 1;
//    foreach (Order order1 in currentUser.Orders)
//    {
//        Console.WriteLine($"Order {i}: {order1.Title} \n");
//        i++;
//    }
//    string input2 = Console.ReadLine();
//    int orderChoice = TextHelper.ValidateInput(input2);
//    if (orderChoice == -1)
//    {
//        Console.WriteLine("Invalid Input");
//    }
//    else
//    {
//        Order currentOrder = currentUser.Orders[orderChoice - 1];
//        if (currentOrder == null)
//        {
//            Console.WriteLine("Invalid Input");
//        }
//        else
//        {
//            Console.WriteLine($"You have chosen order {currentOrder.Title}");
//            Console.WriteLine($"The status of the order is: {currentOrder.Status}");
//        }
//    }
//}
