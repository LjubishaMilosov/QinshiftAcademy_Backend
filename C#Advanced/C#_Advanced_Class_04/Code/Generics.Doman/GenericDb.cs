using Generics.Doman.Models;

namespace Generics.Doman
{
    //GenericDb can work with any type but that type has to be eithr BaseEntity or it has to inherit from BaseEntity
    public class GenericDb<T> where T : BaseEntity
    {
        private List<T> items;
        public GenericDb()
        {
            items = new List<T>();
        }

        public void PrintAll()
        {
            foreach (T item in items)
            {
                // we can call GetInfo because T MUST inherit from BaseEntity, which means that the item has the method GetInfo
                Console.WriteLine(item.GetInfo());
            }
        }

    }
    
}
