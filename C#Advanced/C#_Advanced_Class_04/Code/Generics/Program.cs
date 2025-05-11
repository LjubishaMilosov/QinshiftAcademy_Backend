using Generics;
using Generics.Doman;
using Generics.Doman.Models;

List<string> strings = new List<string>() { "Hello", "G6", "bye" };
List<int> ints = new List<int>() { 1, 2, 3 };
List<bool> bools = new List<bool>() {true, false, true };

NonGenericHelper nonGenericHelper = new NonGenericHelper();
nonGenericHelper.PrintListOStrings(strings);
nonGenericHelper.PrintListOfIntegers(ints);
nonGenericHelper.PrintListOfBools(bools);

Console.WriteLine("=====================================");

// here we pass on the type that will be placed in the placeholder T in genericHelper
GenericHelper<string>.PrintList(strings);
GenericHelper<int>.PrintList(ints);
GenericHelper<bool>.PrintList(bools);

Console.WriteLine("=====================================");

GenericHelper<string>.PrintListInfo(strings);
GenericHelper<int>.PrintListInfo(ints);

// T will be replaced with product for this instance of GenericDb
GenericDb<Product> productsDb = new GenericDb<Product>();

// T will be replaced with order for this instance of GenericDb
GenericDb<Order> ordersDb = new GenericDb<Order>();

// GenericDb<int> orderDb = new GenericDb<int>(); ERROR-> int does not inherit from BaseEntity

Product product = new Product();
product.Id = 1;
product.Title = "Pizza";
product.Description = "Delicious pizza";
productsDb.Add(product);

productsDb.Add(new Product()
{
    Id = 2,
    Title = "Burger",
    Description = "Delicious burger"
});
productsDb.PrintAll();


Console.WriteLine("=====================================");

ordersDb.Add(new Order()
{
    Id = 1,
    OrderedBy = "Petko",
    Address = "Adress1"
});
ordersDb.PrintAll();
