using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.EFImplementation
{
    public class EFStatusRepository : IRepository<Status>
    {
        private readonly ToDoAppDbContext _dbContext;

        public EFStatusRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CRUD methods for accessing the db
        public void Create(Status entity)
        {
            _dbContext.Status.Add(entity); // Add the new status entity to the DbSet
            _dbContext.SaveChanges(); // Save changes to the database
        }

        public void Delete(int id)
        {
            var status = GetById(id);
            if (status != null)
            {
                _dbContext.Status.Remove(status); // Remove the status entity from the DbSet
                _dbContext.SaveChanges(); // Save changes to the database
            }
        }

        public List<Status> GetAll()
        {
            return _dbContext.Status
                .ToList(); // Retrieve all status entities from the database
        }

        public Status GetById(int id)
        {
            return _dbContext.Status
                .FirstOrDefault(s => s.Id == id); // Retrieve a status entity by its ID
        }

        public void Update(Status entity)
        {
            _dbContext.Status.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
