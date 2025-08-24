using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess
{
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext (DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // with this we take the implementation from the base clas and then we can add our etra logic here
            // Fluent API configurations
           
            modelBuilder.Entity<Note>()  // configuring the Note entity
                .Property(x => x.Text)  // configuring the Text property of the Note entity
                .IsRequired()  // making the Text property required (not null)
                .HasMaxLength(100);  // setting the maximum length of the Text property to 100 characters

            modelBuilder.Entity<Note>()
                .Property(x => x.Priority)
                .IsRequired();
            modelBuilder.Entity<Note>()
                .Property(x => x.Tag)
                .IsRequired();

            //relation between User and Note
            modelBuilder.Entity<Note>()// the entity Note
                .HasOne(x => x.User) // has one User
                .WithMany(x => x.Notes) // with many Notes
                .HasForeignKey(x => x.UserId) // the foreign key that connects note to user is UserId
                .OnDelete(DeleteBehavior.Cascade); // when a User is deleted, all their Notes are also deleted (cascade delete)
            
            //we can configure this relation either way
            modelBuilder.Entity<User>()  // the entity User
                .HasMany(x => x.Notes)  // has many Notes
                .WithOne(x => x.User)  // with one User
                .HasForeignKey(x => x.UserId);  // the foreign key that connects note to user is UserId


        }
    }
}
