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
    public class JalonService : IJalonService
    {
        private DbManager _DbManager;
        private ILogger<ProjectService> __logger;
        private IConsistencyChecker _ConsistencyChecker;

        public JalonService(DbManager dbManager, ILogger<ProjectService> logger, IConsistencyChecker consistencyChecker)
        {
            _DbManager = dbManager;
            __logger = logger;
            _ConsistencyChecker = consistencyChecker;
        }

        public JalonEntity Add(JalonEntity entity, UrlConfig config)
        {
            if(_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    _DbManager.JalonsContext.Add(entity);
                    _DbManager.SaveChanges();
                    return entity;
                } catch
                {
                    __logger.LogError($"Error while trying to add {entity}");
                    throw new HttpInternalErrorException($"Error while trying to add {entity}");
                }
            } else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public List<JalonEntity> FindAll(UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    return _DbManager.JalonsContext.Where(jalon => jalon.ProjectId == config.IdProject).ToList();
                }
                catch
                {
                    __logger.LogError("Error while trying to retrieve jalons");
                    throw new HttpInternalErrorException("Error while trying to retrieve jalons");
                }
            } else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public JalonEntity FindOne(UrlConfig config)
        {
           if(_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    return _DbManager.JalonsContext.Find(config.IdJalon);
                }
                catch
                {
                    __logger.LogError($"Error while trying to retrieve jalon ${config.IdJalon} in project ${config.IdProject}");
                    throw new HttpNotFoundException();
                }
            } else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public List<JalonEntity> Remove(UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    _DbManager.JalonsContext.Remove(FindOne(config));
                    _DbManager.SaveChanges();
                    config.IdJalon = 0;
                    return FindAll(config);
                }
                catch 
                {   
                    __logger.LogError($"Error while trying to remove jalon ${config.IdJalon} of project {config.IdProject}");
                    throw new HttpInternalErrorException($"Error while trying to remove jalon ${config.IdJalon} of project {config.IdProject}");
                }
            } else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public JalonEntity Update(JalonEntity entity, UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    _DbManager.JalonsContext.Update(entity);
                    _DbManager.SaveChanges();
                    return entity;
                }
                catch
                {
                    __logger.LogError($"Error while trying to update project ${config.IdJalon}");
                    throw new HttpInternalErrorException($"Error while trying to update project ${config.IdJalon}");
                }
            } else
            {
                throw new HttpUrlNotValidException();
            }
        }

    }
}
