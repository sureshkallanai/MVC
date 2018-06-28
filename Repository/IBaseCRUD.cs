using System.Collections.Generic;

namespace Repository
{
    public interface IBaseCRUD<T>
    {
        void Add(T _T);
        void Update(T _T);
        ICollection<T> Get();
        void Delete(T _T);
        void DeleteFindByID(int id);
    }
}