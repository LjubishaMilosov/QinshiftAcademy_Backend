using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.EFImplementation
{
    public class EFCategoryRepository : IRepository<Category>
    {
        private readonly ToDoAppDbContext _dbContext;

        public EFCategoryRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Category entity)
        {
            _dbContext.Category.Add(entity); // Add the new category entity to the DbSet
            _dbContext.SaveChanges(); // Save changes to the database
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _dbContext.Category.Remove(category); // Remove the category entity from the DbSet
                _dbContext.SaveChanges(); // Save changes to the database
            }
        }

        public List<Category> GetAll()
        {
            return _dbContext.Category
                .ToList(); // Retrieve all category entities from the database
        }

        public Category GetById(int id)
        {
            return _dbContext.Category
                .FirstOrDefault(c => c.Id == id); // Retrieve a category entity by its ID
        }

        public void Update(Category entity)
        {
            _dbContext.Category.Update(entity); // Update the category entity in the DbSet
            _dbContext.SaveChanges(); // Save changes to the database
        }
    }
}
