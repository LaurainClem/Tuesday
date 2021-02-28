using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Services
{
    public interface IBaseService<T> where T : class
    {
        T FindOne(int id);
        List<T> FindAll();
        T Update(T entity);
        T Remove();
    }
}
