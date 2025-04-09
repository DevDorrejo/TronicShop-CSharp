using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Repositories
{
    internal interface IRepository<T>
    {
        List<T> GetAll();
        T? GetByID(int id);
        bool Insert(T entity);
        bool Update (T entity);
        bool Delete(int id);
    }
}
