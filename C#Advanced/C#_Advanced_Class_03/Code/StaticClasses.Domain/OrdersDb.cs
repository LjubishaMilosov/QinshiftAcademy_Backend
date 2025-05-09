using StaticClasses.Domain.Enums;
using StaticClasses.Domain.Models;
namespace StaticClasses.Domain
{
    // This static class simulates a database for orders
    // It is not a real database, but it is used to demonstrate the concept of static classes
    // can be accessed from anywhere 
    // and it is used to store data that is shared across the application
    // It is not a good practice to use static classes for data storage
    // but it is used here to demonstrate the concept of static classes
    // and how they can be used to store data that is shared across the application
   
    public static class OrdersDb
    {
        // these list simulate a real data base
        // all members need to be static
        public static List<Order> Orders { get; set; }
        public static List<User> Users { get; set; }
        public static int lastOrderId = 5; // this is used to generate new order ids

        // static constructor, all members  must be static
        static OrdersDb()
        {
            // initialize the list
            Orders = new List<Order>()
            {
                new Order(1, "book of books", "best book ever ", OrderStatusEnum.Delivered),
                new Order(2, "keyboard", "mechanical", OrderStatusEnum.DeliveryInProcess),
                new Order(3, "shoes", "waterproof", OrderStatusEnum.DeliveryInProcess),
                new Order(4, "set of pens", "ordinary blue pens", OrderStatusEnum.Processing),
                new Order(5, "sticky notes", "yellow", OrderStatusEnum.Problem)
            };
            Users = new List<User>()
            {
                new User(10, "PetkoP", "Adres1"),
                new User(11, "StefanS", "Adres2")
            };
            // add orders to users
            Users[0].Orders.Add(Orders[0]);
            Users[0].Orders.Add(Orders[1]);
            Users[0].Orders.Add(Orders[2]);
            Users[1].Orders.Add(Orders[3]);
            Users[1].Orders.Add(Orders[4]);
        }
        // this method is used to print all orders, must be static
        public static void PrintUsers()
        {
            int i = 1;
            foreach (User user in Users)
            {
                Console.WriteLine($"User {i}: {user.Username} \n");
                i++;
            }
        }

        public static void InsertOrder(int userId, Order order)
        {
            // simulates that the DB generates an Id, it should be +1 from the last order
            lastOrderId++;
            order.Id = lastOrderId;

            // this method is used to insert a new order
            // it is not a good practice to use static classes for data storage
            // but it is used here to demonstrate the concept of static classes
            // and how they can be used to store data that is shared across the application
            Orders.Add(order);

            // add the order to the user

            // validate that the user with userId exists
            User userFromDb = Users.FirstOrDefault(x => x.Id == userId);
            if (userFromDb != null)
            {
                // add the order to the user
                userFromDb.Orders.Add(order);
            }
            else
            {
                throw new Exception("User does not exist");
            }
        }
    }
}
