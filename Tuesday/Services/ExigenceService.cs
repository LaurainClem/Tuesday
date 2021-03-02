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

        public ExigenceService(DbManager dbManager, IJalonService jalonService, ILogger<ExigenceService> logger)
        {
            _DbManager = dbManager;
            _JalonService = jalonService;
            __logger = logger;
        }
        public ExigenceEntity Add(ExigenceEntity entity, int idParent, int idProject)
        {
            if (_JalonService.IsJalonExist(idParent))
            {
                try
                {
                    entity.JalonId = idParent;
                    _DbManager.ExigencesContext.Add(entity);
                    _DbManager.SaveChanges();
                    return entity;
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying to add {entity}");
                    throw new HttpInternalErrorException();
                }
            }
            else
            {
                __logger.LogInformation($"Error occured while trying to retrieve jalon {idParent}");
                throw new HttpNotFoundException();
            }
        }

        public List<ExigenceEntity> FindAll(int idParent)
        {
            if (_JalonService.IsJalonExist(idParent))
            {
                try
                {
                    return _DbManager.ExigencesContext.Where(exigence => exigence.JalonId == idParent).ToList();
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying find Exigences of jalon {idParent}");
                    throw new HttpInternalErrorException();
                }
            }
            else
            {
                __logger.LogInformation($"Error occured while trying to retrieve exigence {idParent}");
                throw new HttpNotFoundException();
            }
        }

        public ExigenceEntity FindOne(int id, int idParent)
        {
            if (_JalonService.IsJalonExist(idParent))
            {
                try
                {
                    return _DbManager.ExigencesContext.Find(id);
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying find Exigence ${id} of Jalon {idParent}");
                    throw new HttpNotFoundException();
                }
            }
            else
            {
                __logger.LogInformation($"Error occured while trying to retrieve project {idParent}");
                throw new HttpNotFoundException();
            }
        }

        public bool IsExigenceExist(int idJalon)
        {
            throw new NotImplementedException();
        }

        public List<ExigenceEntity> Remove(ExigenceEntity entity, int idParent)
        {
            if (_JalonService.IsJalonExist(idParent))
            {
                try
                {
                    _DbManager.ExigencesContext.Remove(entity);
                    _DbManager.SaveChanges();
                    return FindAll(idParent);
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying to remove {entity} of jalon {idParent}");
                    throw new HttpInternalErrorException();
                }
            }
            else
            {
                __logger.LogInformation($"Error occured while trying to retrieve exigence {idParent}");
                throw new HttpNotFoundException();
            }
        }

        public ExigenceEntity Update(ExigenceEntity entity, int idParent)
        {
            if (_JalonService.IsJalonExist(idParent))
            {
                try
                {
                    _DbManager.ExigencesContext.Update(entity);
                    _DbManager.SaveChanges();
                    return entity;
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying to update {entity} of jalon {idParent}");
                    throw new HttpInternalErrorException();
                }
            }
            else
            {
                __logger.LogInformation($"Error occured while trying to retrieve jalon {idParent}");
                throw new HttpNotFoundException();
            }
        }
    }
}
