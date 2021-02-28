using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFramework.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public virtual T add(T newEntity)
        {
            throw new NotImplementedException();
            // DbSet<>
        }

        public virtual T delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T find(int[] entityId)
        {
            throw new NotImplementedException();
        }

        public virtual T[] findAll()
        {
            throw new NotImplementedException();
        }

        public virtual T findOne(int entityId)
        {
            throw new NotImplementedException();
        }

        public virtual T update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
