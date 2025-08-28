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
            _dbContext.Notes.Add(entity);
            //_dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Note entity)
        {
            _dbContext.Notes.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Note> GetAll()
        {
            // SELECT * from notes
            //From Notes N
            // JOIN Users U on N.UserId = U.Id - we need this join in order to access the data for the users
            return _dbContext
                 .Notes
                 .Include(n => n.User) // we join Notes table with the users table in order to be able to access info about the users
                                       // we use join dut to lazy loading being disabled
                                       // we use Include method to specify the related entity to include in the query results
                 .ToList();
        }

        public Note GetById(int id)
        {
            var note = _dbContext.Notes
                .Include(n => n.User) // we join Notes table with the users table in order to be able to access info about the users
                                      // we use join dut to lazy loading being disabled
                                      // we use Include method to specify the related entity to include in the query results
                .FirstOrDefault(n => n.Id == id); // SELECT * from Notes where Id = id

            if (note == null) 
            {
                throw new Exception($"Note with id {id} not found.");
            }
            return note;
        }

        public void Update(Note entity)
        {
            _dbContext.Notes.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
