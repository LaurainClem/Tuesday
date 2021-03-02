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
            return _projectService.FindAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ProjectEntity FindOne(int id)
        {
            return _projectService.FindOne(id);
        }

        [HttpPost]
        public ProjectEntity Add([FromBody] ProjectDto projectDto)
        {
            var project = new ProjectEntity
            {
                Label = projectDto.Label
            };
            return _projectService.Add(project);            
        }

        [HttpDelete]
        public List<ProjectEntity> Remove([FromBody]ProjectEntity project)
        {
            return _projectService.Remove(project);
        }

        [HttpPatch]
        public ProjectEntity Update([FromBody] ProjectEntity project)
        {
            return _projectService.Update(project);
        }
    }
}
