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

        public ProjectService(DbManager dbManager, ILogger<ProjectService> logger, IConsistencyChecker consistencyChecker)
        {
            _Context = dbManager;
            __logger = logger;
        }

        public ProjectEntity Add(ProjectEntity entity, UrlConfig config)
        {
            try
            {
                _Context.ProjetsContext.Add(entity);
                _Context.SaveChanges();

                return entity;
            }
            catch
            {
                __logger.LogError($"Error while trying to add {entity}");
                throw new HttpInternalErrorException($"Error while trying to add {entity}");
            }
        }

        public List<ProjectEntity> FindAll(UrlConfig config)
        {
            try
            {
                return _Context.ProjetsContext.ToList();
            } catch
            {
                __logger.LogError("Error while trying to retrieve projects");
                throw new HttpInternalErrorException("Error while trying to retrieve projects");
            }
        }

        public ProjectEntity FindOne(UrlConfig config)
        {
            try
            {
                return _Context.ProjetsContext.Single(project => project.Id == config.IdProject);
            } catch
            {
                __logger.LogError($"Error while trying to retrieve project ${config.IdProject}");
                throw new HttpNotFoundException();
            }
        }

        public List<ProjectEntity> Remove(UrlConfig config)
        {
            try
            {
                _Context.ProjetsContext.Remove(FindOne(config));
                _Context.SaveChanges();
                return FindAll(config);
            }
            catch
            {
                __logger.LogError($"Error while trying to remove project ${config.IdProject}");
                throw new HttpInternalErrorException($"Error while trying to remove project ${config.IdProject}");
            }
        }

        public ProjectEntity Update(ProjectEntity entity, UrlConfig config)
        {
            try
            {
                _Context.ProjetsContext.Update(entity);
                _Context.SaveChanges();

                UrlConfig newConfig = new UrlConfig() { IdProject = entity.Id };

                return FindOne(config);
            } catch
            {
                __logger.LogError($"Error while trying to update project ${config.IdProject}");
                throw new HttpInternalErrorException($"Error while trying to update project ${config.IdProject}");
            }
        }
    }
}
