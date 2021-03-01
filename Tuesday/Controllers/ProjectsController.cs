using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            try
            {
                return _projectService.FindAll();
            }
            catch
            {
                _logger.LogError("Internal Error while retrieving projects");
                throw new HttpInternalErrorException();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ProjectEntity FindOne(int id)
        {
            try
            {
                return _projectService.FindOne(id);
            } catch
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
            } catch (DbUpdateException e)
            {
                _logger.LogError($"Internal error while adding a new project. ");
                throw new HttpResponseException(400, e.InnerException.Message);
            }
            
        }

        [HttpDelete]
        public List<ProjectEntity> Remove([FromBody]ProjectEntity project)
        {
            try
            {
                return _projectService.Remove(project);
            } catch
            {
                _logger.LogError($"Can't find project with id {project.Id}");
                throw new HttpNotFoundException();
            }
        }

        [HttpPatch]
        public ProjectEntity Update([FromBody] ProjectEntity project)
        {
            try
            {
                return _projectService.Update(project);
            } catch 
            {
                _logger.LogError($"Can't find project with id {project.Id}");
                throw new HttpNotFoundException();
            }
        }
    }
}
