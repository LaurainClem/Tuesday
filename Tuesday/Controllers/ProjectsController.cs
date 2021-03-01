using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Dtos;
using Tuesday.Entities;
using Tuesday.Exceptions;
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
        public List<ProjectEntity> FindAll()
        {
            return _projectService.FindAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ProjectEntity FindOne(int id)
        {
            try
            {
                return _projectService.FindOne(id);
            } catch (Exception e)
            {
                _logger.LogError($"Can't find project with id {id}");
                throw new HttpNotFoundException();
            }
        }

        [HttpPost]
        public ProjectEntity Add([FromBody] ProjectDto projectDto)
        {
            try
            {
                var project = new ProjectEntity
                {
                    Label = projectDto.Label
                };
                return _projectService.Add(project);
            } catch (Exception e)
            {
                throw new HttpInternalErrorException();
            }
            
        }

        [HttpDelete]
        public List<ProjectEntity> Remove([FromBody]ProjectEntity project)
        {
            try
            {
                return _projectService.Remove(project);
            } catch (Exception e)
            {
                throw new HttpNotFoundException();
            }
        }

        [HttpPatch]
        public ProjectEntity Update([FromBody] ProjectEntity project)
        {
            try
            {
                return _projectService.Update(project);
            } catch (Exception e)
            {
                throw new HttpNotFoundException();
            }
        }
    }
}
