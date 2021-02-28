using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;
using Tuesday.Services;

namespace Tuesday.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {

        private readonly ILogger<TasksController> _logger;
        private readonly IProjectService _projectService;

        public ProjectsController(ILogger<TasksController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpGet]
        public List<ProjectEntity> Get ()
        {
            _logger.LogInformation("Called on Get");
            return _projectService.FindAll();
        }
    }
}
