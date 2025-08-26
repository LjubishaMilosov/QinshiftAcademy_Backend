using Microsoft.EntityFrameworkCore;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Implementation
{
    public class NoteRepository : IRepository<Note>
    {
        // to communicate to db, the repository needs an instance of the DbContext
        private NotesAppDbContext _dbContext;

        // we inject the DbContext through the constructor
        // in the constructor NoteRepository, we set the private field _dbContext
        // to the instance of NotesAppDbContext that is passed in
        public NoteRepository(NotesAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Note entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetAll()
        {
            // SELECT * from notes
            //From Notes N
            // JOIN Users U on N.UserId = U.Id - we need this join in order to access the data for the users
            return _dbContext
                 .Notes
                 .Include(n => n.User) // we join Notes table with the users table in order to be able to access info about the users
                 .ToList();
        }

        public Note GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
        {
            throw new NotImplementedException();
        }
    }
}
