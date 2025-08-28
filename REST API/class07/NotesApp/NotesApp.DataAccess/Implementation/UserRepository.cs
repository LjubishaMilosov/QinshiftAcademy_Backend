using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Implementation
{
    public class UserRepository : IRepository<User>
    {
        // to communicate to db, the repository needs an instance of the DbContext
        private readonly NotesAppDbContext _dbContext;

        // we inject the DbContext through the constructor
        // in the constructor UserRepository, we set the private field _dbContext to the instance of NotesAppDbContext that is passed in
        public UserRepository(NotesAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
            // we don't use Include() here because we don't have any navigation properties in the User entity
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
