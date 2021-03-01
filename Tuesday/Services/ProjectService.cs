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
        public ProjectEntity Add(ProjectEntity entity)
        {
            _Context.ProjetsContext.Add(entity);
            _Context.SaveChanges();
            return FindOne(entity.Id);
        }

        public List<ProjectEntity> FindAll()
        {
            return _Context.ProjetsContext.ToList();
        }

        public ProjectEntity FindOne(int id)
        {
            return _Context.ProjetsContext.Single(project => project.Id == id);
        }

        public List<ProjectEntity> Remove(ProjectEntity entity)
        {
            _Context.ProjetsContext.Remove(entity);
            _Context.SaveChanges();

            return FindAll();
        }

        public ProjectEntity Update(ProjectEntity entity)
        {
            _Context.ProjetsContext.Update(entity);
            _Context.SaveChanges();
            
            return FindOne(entity.Id);
        }
    }
}
