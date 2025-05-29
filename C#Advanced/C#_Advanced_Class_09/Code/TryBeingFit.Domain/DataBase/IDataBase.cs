
using TryBeingFit.Domain.Models;

namespace TryBeingFit.Domain.DataBase
{
    public interface IDataBase<T> where T: BaseEntity
    {
        //CRUD
        List<T> GetAll();

        T GetById(int id);

        int Insert(T entity);

        void Update(T entity);

        void RemoveById(int id);
    }
}
