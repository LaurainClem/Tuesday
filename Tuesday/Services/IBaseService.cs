using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Services
{
    public interface IBaseService<T> where T : class
    {
        T FindOne(UrlConfig config);
        List<T> FindAll(UrlConfig config);
        T Update(T entity, UrlConfig config);
        List<T> Remove(UrlConfig config);
        T Add(T entity, UrlConfig config);
    }
}
