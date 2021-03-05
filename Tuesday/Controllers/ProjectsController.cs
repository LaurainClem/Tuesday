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
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public List<ProjectEntity> FindAll()
        {
            UrlConfig config = new UrlConfig();
            return _projectService.FindAll(config);
        }

        [HttpGet]
        [Route("{idProject}")]
        public ProjectEntity FindOne(int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject };
            return _projectService.FindOne(config);
        }

        [HttpPost]
        public ProjectEntity Add([FromBody] ProjectDto projectDto)
        {
            var project = new ProjectEntity
            {
                Label = projectDto.Label,
                AssigneeId = projectDto.AssigneeId
            };
            UrlConfig config = new UrlConfig();

            return _projectService.Add(project, config);            
        }

        [HttpDelete]
        [Route("{idProject}")]
        public List<ProjectEntity> Remove(int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject };
            return _projectService.Remove(config);
        }

        [HttpPatch]
        [Route("{idProject}")]
        public ProjectEntity Update([FromBody] ProjectDto projectDto, int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject };
            try
            {
                ProjectEntity entity = _projectService.FindOne(config);
                entity.Label = projectDto.Label != null ? projectDto.Label : entity.Label;
                entity.AssigneeId = projectDto.AssigneeId;
                return _projectService.Update(entity, config);
            } catch
            {
                throw;
            }
        }
    }
}
