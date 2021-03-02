using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;
using Tuesday.Exceptions;
using Tuesday.Repositories;

namespace Tuesday.Services
{
    public class ProjectService : IProjectService
    {
        private DbManager _Context;
        private ILogger<ProjectService> __logger;

        public ProjectService(DbManager dbManager, ILogger<ProjectService> logger)
        {
            _Context = dbManager;
            __logger = logger;
        }

        public ProjectEntity Add(ProjectEntity entity)
        {
            try
            {
                _Context.ProjetsContext.Add(entity);
                _Context.SaveChanges();
                return FindOne(entity.Id);
            } catch
            {
                __logger.LogError($"Error occured while trying to add {entity}");
                throw new HttpInternalErrorException();
            }
        }

        public List<ProjectEntity> FindAll()
        {
            try
            {
                return _Context.ProjetsContext.ToList();
            } catch
            {
                __logger.LogError("Error occured while trying to get all projects");
                throw new HttpInternalErrorException();
            }
        }

        public ProjectEntity FindOne(int id)
        {
            try
            {
                return _Context.ProjetsContext.Single(project => project.Id == id);
            } catch
            {
                __logger.LogError($"No projects found with id : ${id}");
                throw new HttpNotFoundException();
            }
        }

        public bool IsProjectExist(int idProject)
        {
            try
            {
                return FindOne(idProject) != null;
            } catch
            {
                throw new HttpNotFoundException();
            }
        }

        public List<ProjectEntity> Remove(ProjectEntity entity)
        {
            try
            {
                _Context.ProjetsContext.Remove(entity);
                _Context.SaveChanges();
                return FindAll();
            }
            catch
            {
                __logger.LogError($"Error occured while trying to remove {entity}");
                throw new HttpInternalErrorException();
            }
        }

        public ProjectEntity Update(ProjectEntity entity)
        {
            try
            {
                _Context.ProjetsContext.Update(entity);
                _Context.SaveChanges();

                return FindOne(entity.Id);
            } catch
            {
                __logger.LogError($"Error occured while trying to update {entity}");
                throw new HttpInternalErrorException();
            }
        }
    }
}
