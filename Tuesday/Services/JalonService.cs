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
        private IProjectService _ProjectService;
        private ILogger<ProjectService> __logger;

        public JalonService(DbManager dbManager, IProjectService projectService, ILogger<ProjectService> logger)
        {
            _DbManager = dbManager;
            _ProjectService = projectService;
            __logger = logger;
        }

        public JalonEntity Add(JalonEntity entity, int idParent)
        {
            if (_ProjectService.IsProjectExist(idParent))
            {
                try
                {
                    entity.ProjectId = idParent;
                    _DbManager.JalonsContext.Add(entity);
                    _DbManager.SaveChanges();
                    return entity;
                } catch
                {
                    __logger.LogInformation($"Error occured while trying to add {entity}");
                    throw new HttpInternalErrorException();
                }
            } else
            {
                __logger.LogInformation($"Error occured while trying to retrieve project {idParent}");
                throw new HttpNotFoundException();
            }
        }

        public List<JalonEntity> FindAll(int idParent)
        {
            if (_ProjectService.IsProjectExist(idParent))
            {
                try
                {
                    return _DbManager.JalonsContext.Where(jalon => jalon.ProjectId == idParent).ToList();
                } catch
                {
                    __logger.LogInformation($"Error occured while trying find Jalons of project {idParent}");
                    throw new HttpInternalErrorException();
                }
            } else
            {
                __logger.LogInformation($"Error occured while trying to retrieve project {idParent}");
                throw new HttpNotFoundException();
            }
        }

        public JalonEntity FindOne(int id, int idParent)
        {
            if (_ProjectService.IsProjectExist(idParent))
            {
                try
                {
                    return _DbManager.JalonsContext.Find(id);
                } catch
                {
                    __logger.LogInformation($"Error occured while trying find Jalons ${id} of project {idParent}");
                    throw new HttpNotFoundException();
                }
            } else
            {
                __logger.LogInformation($"Error occured while trying to retrieve project {idParent}");
                throw new HttpNotFoundException();
            }
        }

        public bool IsJalonExist(int idJalon, int idProject)
        {
            try
            {
                return FindOne(idJalon, idProject) != null;
            }
            catch
            {
                throw new HttpNotFoundException();
            }
        }

        public List<JalonEntity> Remove(JalonEntity entity, int idParent)
        {
            if (_ProjectService.IsProjectExist(idParent))
            {
                try
                {
                    _DbManager.JalonsContext.Remove(entity);
                    _DbManager.SaveChanges();
                    return FindAll(idParent);
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying to remove {entity} of project {idParent}");
                    throw new HttpInternalErrorException();
                }
            }
            else
            {
                __logger.LogInformation($"Error occured while trying to retrieve project {idParent}");
                throw new HttpNotFoundException();
            }
        }

        public JalonEntity Update(JalonEntity entity, int idParent)
        {
            if (_ProjectService.IsProjectExist(idParent))
            {
                try
                {
                    _DbManager.JalonsContext.Update(entity);
                    _DbManager.SaveChanges();
                    return entity;
                }
                catch
                {
                    __logger.LogInformation($"Error occured while trying to update {entity} of project {idParent}");
                    throw new HttpInternalErrorException();
                }
            }
            else
            {
                __logger.LogInformation($"Error occured while trying to retrieve project {idParent}");
                throw new HttpNotFoundException();
            }
        }

    }
}
