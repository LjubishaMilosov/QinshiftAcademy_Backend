using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Implementation
{
    public class ToDoRepository : IRepository<ToDo>
    {
        public void Create(ToDo entity)
        {
            if (entity == null)
            {
                throw new Exception("ToDo item cannot be null");
            }
            entity.Id = StaticDb.Todos.Count + 1; //assign a new id
            StaticDb.Todos.Add(entity); //add the new todo to the static db
        }

        public void Delete(int id)
        {
            // first we need to find the entity that we want to remove and then remove it
            ToDo todoFromDb = StaticDb.Todos.FirstOrDefault(todo => todo.Id == id);
            if(todoFromDb != null)
            {
                StaticDb.Todos.Remove(todoFromDb); //if we successfully found the entity, remove the todo from the static db
            }
        }

        public List<ToDo> GetAll()
        {
            return StaticDb.Todos; //return all todos from db
        }

        public ToDo GetById(int id)
        {
            return StaticDb.Todos.FirstOrDefault(todo => todo.Id == id);
        }

        public void Update(ToDo entity)
        {
            if(entity == null)
            {
                throw new Exception("Entity cannot be null");
            }
            ToDo toDoFromDb = GetById(entity.Id);
            int index = StaticDb.Todos.IndexOf(toDoFromDb);
            StaticDb.Todos[index] = entity; //update the todo in the static db
        }
    }
}
