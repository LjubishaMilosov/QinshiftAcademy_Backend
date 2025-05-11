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

        //Read operations
        public void PrintAll()
        {
            foreach (T item in items)
            {
                // we can call GetInfo because T MUST inherit from BaseEntity, which means that the item has the method GetInfo
                Console.WriteLine(item.GetInfo());
            }
        }

        //Read
        public T GetById(int id)
        {
            //Select *
            //FROM Product/order
            // because T inherits from BaseEntity, T will always have a property Id
            // we can use the method FirstOrDefault because T is a List<T> and it has this method
            return items.FirstOrDefault(i => i.Id == id);
        }

        //Create
        public void Add(T item)
        {
            //Insert into Product/order
            items.Add(item);
            Console.WriteLine("The item was added");
        }

        //Remove
        public void Remove(int id)
        {
            //Delete from Product/order
            //T item = items.FirstOrDefault(i => i.Id == id); // this way or using GetById below
            T item = GetById(id);
            if (item != null)
            {
                items.Remove(item); // we pass the whole item object that we want to remove from the db
                Console.WriteLine("The item was removed");
            }
            else
            {
                Console.WriteLine("The item was not found");
            }
        }


    }

}
