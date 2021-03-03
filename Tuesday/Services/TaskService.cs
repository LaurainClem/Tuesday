using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Dtos;
using Tuesday.Entities;
using Tuesday.Exceptions;
using Tuesday.Repositories;

namespace Tuesday.Services
{
    public class TaskService : ITaskService
    {
        private DbManager _DbManager;
        private ILogger<TaskService> __logger;
        private IConsistencyChecker _ConsistencyChecker;

        public TaskService(DbManager dbManager, ILogger<TaskService> logger, IConsistencyChecker consistencyChecker)
        {
            _DbManager = dbManager;
            __logger = logger;
            _ConsistencyChecker = consistencyChecker;
        }

        public TaskEntity Add(TaskEntity entity, UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    _DbManager.TasksContext.Add(entity);
                    _DbManager.SaveChanges();
                    return entity;
                }
                catch
                {
                    __logger.LogError($"Error while trying to add {entity}");
                    throw new HttpInternalErrorException($"Error while trying to add {entity}");
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public List<TaskEntity> FindAll(UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    return _DbManager.TasksContext.Where(task => task.JalonId == config.IdJalon).ToList();
                }
                catch
                {
                    __logger.LogError("Error while trying to retrieve tasks");
                    throw new HttpInternalErrorException("Error while trying to retrieve tasks");
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public TaskEntity FindOne(UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    return _DbManager.TasksContext.Find(config.IdTask);
                }
                catch
                {
                    __logger.LogError($"Error while trying to retrieve task {config.IdJalon} in jalon {config.IdJalon}");
                    throw new HttpNotFoundException();
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public List<TaskEntity> Remove(UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    _DbManager.TasksContext.Remove(FindOne(config));
                    _DbManager.SaveChanges();
                    config.IdTask = 0;
                    return FindAll(config);
                }
                catch
                {
                    __logger.LogError($"Error while trying to remove task {config.IdTask} of jalon {config.IdJalon}");
                    throw new HttpInternalErrorException($"Error while trying to remove task {config.IdTask} of jalon {config.IdJalon}");
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }

        public TaskEntity Update(TaskEntity entity, UrlConfig config)
        {
            if (_ConsistencyChecker.IsUrlValid(config))
            {
                try
                {
                    _DbManager.TasksContext.Update(entity);
                    _DbManager.SaveChanges();
                    return entity;
                }
                catch
                {
                    __logger.LogError($"Error while trying to update task {config.IdTask}");
                    throw new HttpInternalErrorException($"Error while trying to update task {config.IdTask}");
                }
            }
            else
            {
                throw new HttpUrlNotValidException();
            }
        }
    }
}
