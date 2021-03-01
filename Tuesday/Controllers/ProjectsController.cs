using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Dtos;
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
        public List<ProjetEntity> Get ()
        {
            _logger.LogInformation("Called on Get");
            return _projectService.FindAll();
        }

        [HttpGet]
        public ProjetEntity GetOne(int id)
        {
            _logger.LogInformation("Called on GetOne");
            return _projectService.FindOne(id);
        }

        [HttpPost]
        public void Add([FromBody] ProjectDto projectDto)
        {
            _logger.LogInformation("Called on Post");
            var project = new ProjetEntity();
            project.Label = projectDto.Label;
            _projectService.Add(project);
        }
    }
}
