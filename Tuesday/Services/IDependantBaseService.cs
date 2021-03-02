using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Services
{
    public interface IDependantBaseService<T> where T : class
    {
        T FindOne(int id, int idParent);
        List<T> FindAll(int idParent);
        T Update(T entity, int idParent);
        List<T> Remove(T entity, int idParent);
        T Add(T entity, int idParent);
    }
}
