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
    public class UserService : IUserService
    {
        private readonly DbManager _DbManager;
        private ILogger<UserService> __logger;

        public UserService(DbManager dbManager, ILogger<UserService> logger)
        {
            _DbManager = dbManager;
            __logger = logger;
        }

        public UserEntity Add(UserEntity entity, UrlConfig config)
        {
            throw new NotImplementedException();
        }

        public List<UserEntity> FindAll(UrlConfig config)
        {
            try
            {
                return _DbManager.UsersContext.ToList();
            } catch
            {
                __logger.LogError("An error occured while trying to retrieve users");
                throw new HttpInternalErrorException("An error occured while trying to retrieve users");
            }
        }

        public UserEntity FindOne(UrlConfig config)
        {
            try
            {
                return _DbManager.UsersContext.Find(config.IdUser);
            }
            catch
            {
                __logger.LogInformation($"Error while trying to retrieve user with id {config.IdUser}");
                throw new HttpNotFoundException();
            }
        }

        public List<UserEntity> Remove(UrlConfig config)
        {
            throw new NotImplementedException();
        }

        public UserEntity Update(UserEntity entity, UrlConfig config)
        {
            throw new NotImplementedException();
        }
    }
}