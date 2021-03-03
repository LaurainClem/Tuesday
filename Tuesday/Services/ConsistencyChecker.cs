using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Repositories;

namespace Tuesday.Services
{
    public class ConsistencyChecker : IConsistencyChecker
    {
        private DbManager _DbManager;
        private ILogger<ConsistencyChecker> __logger;

        public ConsistencyChecker(DbManager dbManager, ILogger<ConsistencyChecker> logger)
        {
            _DbManager = dbManager;
            __logger = logger;
        }

        public bool IsUrlValid(UrlConfig config)
        {
            if(config.IdProject != 0 && CheckProjectConsistency(config))
            {
                if(config.IdJalon != 0)
                {
                    return CheckJalonConsistency(config);
                }

                return true;
            }
            __logger.LogInformation("Url invalid no project id found or can't retrieve project");
            return false;
        }

        private bool CheckProjectConsistency(UrlConfig config)
        {
            try
            {
                return _DbManager.ProjetsContext.Find(config.IdProject) != null;
            } catch
            {
                return false;
            }
        }

        private bool CheckJalonConsistency(UrlConfig config)
        {
            try
            {
                var jalon = _DbManager.JalonsContext.Find(config.IdJalon);
                if(jalon == null || jalon.ProjectId != config.IdProject)
                {
                    __logger.LogInformation($"Url invalid no jalon found with id {config.IdJalon} in project {config.IdProject}");
                    return false;
                }
                return jalon.ProjectId == config.IdProject;
            }
            catch
            {
                __logger.LogInformation($"Url invalid no jalon found with id {config.IdJalon}");
                return false;
            }
        }
    }
}
