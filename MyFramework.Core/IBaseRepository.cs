using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFramework.Core
{
    public interface IBaseRepository<T>
    {
        T findOne(int entityId);
        T find(int[] entityId);
        T[] findAll();
        T add(T newEntity);
        T delete(T entity);
        T update(T entity);
    }
}
