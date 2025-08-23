using Microsoft.EntityFrameworkCore;
using NotesAppDA.Domain;

namespace NotesAppDA.DataAccess
{
    public class NotesAppDADbContext : DbContext
    {
        public NotesAppDADbContext(DbContextOptions options) : base(options) { }

        // DbSet represents a collection of entities of a specific type that can be queried from the database
        // and also used to perform CRUD operations on those entities.
        // Each DbSet property corresponds to a table in the database.
        // In this case, we have two DbSet properties: Notes and Users.
        // 

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
