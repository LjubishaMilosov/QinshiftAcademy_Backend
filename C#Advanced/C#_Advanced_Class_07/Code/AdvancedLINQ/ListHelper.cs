using AdvancedLINQ.Domain.Models;

namespace AdvancedLINQ
{
    public static class ListHelper
    {
        public static void PrintSimple<T>(this List<T> list)
        {
            //Description: This method prints the elements of a list of any type.
            // It uses a foreach loop to iterate through the list and print each element.
            // It is a generic method that can be used with any type of list.
            // It is used to display the contents of the list to the console.
            Console.WriteLine($"Printing {list.Count} items");
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintEntities<T>(this List<T> list) where T : BaseEntity
        {
            // Description: This method prints the elements of a list of type T, where T is a subclass of BaseEntity.
            // It uses a foreach loop to iterate through the list and call the PrintInfo method on each element.

            Console.WriteLine($"Printing {list.Count} items");
            foreach (T item in list)
            {
                item.PrintInfo();
            }
        }
    }
}
