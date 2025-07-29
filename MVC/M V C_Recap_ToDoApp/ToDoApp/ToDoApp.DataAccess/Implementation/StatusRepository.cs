using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Implementation
{
    public class StatusRepository : IRepository<Status>
    {
        public void Create(Status entity)
        {
            if (entity == null)
            {
                throw new Exception("Status item cannot be null");
            }
            entity.Id = StaticDb.Statuses.Last().Id + 1; //here we are sure that there is at least one category
            StaticDb.Statuses.Add(entity);
        }

        public void Delete(int id)
        {
            // first we need to find the entity that we want to remove and then remove it
            Status status = StaticDb.Statuses.FirstOrDefault(status => status.Id == id);
            if (status != null)
            {
                StaticDb.Statuses.Remove(status); //if we successfully found the entity, remove the status from the static db
            }
        }

        public List<Status> GetAll()
        {
            return StaticDb.Statuses; // return all statuses from the static db
        }

        public Status GetById(int id)
        {
            return StaticDb.Statuses.FirstOrDefault(status => status.Id == id);
        }

        public void Update(Status entity)
        {
            if (entity == null)
            {
                throw new Exception("Status cannot be null");
            }
            Status status = GetById(entity.Id);
            int index = StaticDb.Statuses.IndexOf(status);
            StaticDb.Statuses[index] = entity;
        }
    }
}
