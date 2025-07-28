using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Interfaces
{
    interface IRepository<T> where T : BaseEntity
    {
        // CRUD methods for accesing the database
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
