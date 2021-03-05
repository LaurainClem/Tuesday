using Microsoft.AspNetCore.Mvc;
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
    [Route("api/projects/{idProject}/[controller]")]
    [ApiController]
    public class ExigencesController : ControllerBase
    {
        private readonly IExigenceService _exigenceService;

        public ExigencesController(IExigenceService exigenceService)
        {
            _exigenceService = exigenceService;
        }

        [HttpGet]
        public List<ExigenceEntity> FindAll(int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject };
            return _exigenceService.FindAll(config);
        }

        [HttpGet]
        [Route("{idExigence}")]
        public ExigenceEntity FindOne(int idExigence, int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdExigence = idExigence };
            return _exigenceService.FindOne(config);
        }

        [HttpPost]
        public ExigenceEntity Add([FromBody] ExigenceDto exigenceDto, int idProject)
        {
            ExigenceEntity exigence = new ExigenceEntity()
            {
                Label = exigenceDto.Label,
                ProjectId = idProject,
                ExigenceType = exigenceDto.ExigenceType,
            };
            UrlConfig config = new UrlConfig() { IdProject = idProject };
            return _exigenceService.Add(exigence, config);
        }

        [HttpPatch]
        [Route("{idExigence}")]
        public ExigenceEntity Update([FromBody] ExigenceDto exigenceDto, int idProject, int idExigence)
        {
            try
            {
                UrlConfig config = new UrlConfig() { IdProject = idProject, IdExigence = idExigence };
                ExigenceEntity exigence = _exigenceService.FindOne(config);
                exigence.Label = exigenceDto.Label;
                exigence.ExigenceType = exigenceDto.ExigenceType;
                return _exigenceService.Update(exigence, config);
            }
           catch
            {
                throw new HttpInternalErrorException("");
            }
        }

        [HttpDelete]
        [Route("{idExigence}")]
        public List<ExigenceEntity> Remove(int idProject, int idExigence)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdExigence = idExigence };
            return _exigenceService.Remove(config);
        }
    }
}
