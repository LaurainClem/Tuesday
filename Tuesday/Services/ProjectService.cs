using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;
using Tuesday.Repositories;

namespace Tuesday.Services
{
    public class ProjectService : IProjectService
    {
        private DbManager _Context;
        public ProjectService(DbManager dbManager)
        {
            _Context = dbManager;
        }
        public void Add(ProjetEntity entity)
        {
            _Context.ProjetsContext.Add(entity);
            _Context.SaveChanges();
        }

        public List<ProjetEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public ProjetEntity FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public ProjetEntity Remove()
        {
            throw new NotImplementedException();
        }

        public ProjetEntity Update(ProjetEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
