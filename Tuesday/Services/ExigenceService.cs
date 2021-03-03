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
    public class ExigenceService : IExigenceService
    {

        private DbManager _DbManager;
        private IJalonService _JalonService;
        private ILogger<ExigenceService> __logger;
        private readonly IConsistencyChecker _ConsistencyChecker;

        public ExigenceService(DbManager dbManager, IJalonService jalonService, ILogger<ExigenceService> logger, IConsistencyChecker consistencyChecker)
        {
            _DbManager = dbManager;
            _JalonService = jalonService;
            __logger = logger;
            _ConsistencyChecker = consistencyChecker;
        }
        public ExigenceEntity Add(ExigenceEntity entity, UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    entity.ProjectId = config.IdProject;
                    _DbManager.ExigencesContext.Add(entity);
                    _DbManager.SaveChanges();
                    return entity;
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying to add {entity}");
                    throw new HttpInternalErrorException($"Error occured while trying to add {entity}");
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public List<ExigenceEntity> FindAll(UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    return _DbManager.ExigencesContext.Where(exigence => exigence.ProjectId == config.IdProject).ToList();
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying find Exigences of jalon {config.IdProject}");
                    throw new HttpInternalErrorException($"Error occured while trying find Exigences of jalon {config.IdProject}");
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public ExigenceEntity FindOne(UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    return _DbManager.ExigencesContext.Find(config.IdExigence);
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying find Exigence ${config.IdExigence} of Jalon {config.IdJalon}");
                    throw new HttpNotFoundException();
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public List<ExigenceEntity> Remove(UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    _DbManager.ExigencesContext.Remove(FindOne(config));
                    _DbManager.SaveChanges();
                    return FindAll(config);
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying to remove exigence with id {config.IdExigence} of project {config.IdProject}");
                    throw new HttpInternalErrorException($"Error occured while trying to remove exigence with id {config.IdExigence} of project {config.IdProject}");
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public ExigenceEntity Update(ExigenceEntity entity, UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    _DbManager.ExigencesContext.Update(entity);
                    _DbManager.SaveChanges();
                    return entity;
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying to update {entity} of jalon {config.IdJalon}");
                    throw new HttpInternalErrorException($"Error occured while trying to update {entity} of jalon {config.IdJalon}");
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }
    }
}
