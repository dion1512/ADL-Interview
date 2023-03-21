using ADL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Repositories.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
