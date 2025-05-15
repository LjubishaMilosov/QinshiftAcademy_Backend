

using TryBeingFit.Domain.Models;

namespace TryBeingFit.Domain.DataBase
{
    public class DataBase<T> : IDataBase<T> where T : BaseEntity
    {
        //we mark the List private because we do not want anyone from outside to be able to access and modify th items.
        //we will want to use the methods to manipulate the list
        private List<T> items { get; set; } = new List<T>();
        public int Id { get; set; } 

        public DataBase()
        {
            items = new List<T>();
            Id = 1;  // we do not have the db identity, so will need to manually increment the id
        }
        public List<T> GetAll()
        {
            return items; // here we need to return the whole list, all the items SELECT * FROM T
        }

        public T GetById(int id)
        {
            T item = items.FirstOrDefault(x => x.Id == id); // here we need to return the item with the given id
            //validation
            if (item == null)
            {
                throw new NullReferenceException($"Entity wit id {id} was not found in the db");
            }
        }

        public int Insert(T item)
        {
          //  item.Id = LasUsedId; // here we need to set the id of the item to the current id and increment it for the next item
           // LastUsedId++;
           
            items.Add(item); // here we need to add the item to the list
            return item.Id;

        }

        public void RemoveById(int id)
        {
            T item = GetById(id);
            items.Remove(item); // here we need to remove the item from the list
        }

        public void Update(T entity)
        {
            // first we search if the item tha we want to update exists in out db, (our items list)
            // T item = items.FirstOrDefault(x => x.Id == entity.Id);  ??
            T item = GetById(entity.Id);

            // we have to find the index of the item that we want to replace and switch its value
            int indexOfElement = items.IndexOf(item); 
            items[indexOfElement] = entity; //on the place ofthe existing (index) item that we want to update, we put the new item
        }
    }
}
