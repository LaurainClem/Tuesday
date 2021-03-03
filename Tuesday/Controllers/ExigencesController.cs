using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Dtos;
using Tuesday.Entities;
using Tuesday.Services;

namespace Tuesday.Controllers
{
    [Route("api/projects/{idProject}/jalons/{idJalon}/[controller]")]
    [ApiController]
    public class ExigencesController : ControllerBase
    {
        private readonly IExigenceService _exigenceService;

        public ExigencesController(IExigenceService exigenceService)
        {
            _exigenceService = exigenceService;
        }

        [HttpGet]
        public List<ExigenceEntity> FindAll(int idJalon, int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon};
            return _exigenceService.FindAll(config);
        }

        [HttpGet]
        [Route("{idExigence}")]
        public ExigenceEntity FindOne(int idJalon, int idExigence, int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon, IdExigence = idExigence };
            return _exigenceService.FindOne(config);
        }

        [HttpPost]
        public ExigenceEntity Add([FromBody] ExigenceDto exigenceDto, int idJalon, int idProject)
        {
            ExigenceEntity exigence = new ExigenceEntity()
            {
                Label = exigenceDto.Label,
                ProjectId = idProject,
                ExigenceType = exigenceDto.ExigenceType,
            };
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon };
            return _exigenceService.Add(exigence, config);
        }

        [HttpPatch]
        public ExigenceEntity Update([FromBody] ExigenceEntity exigence, int idJalon, int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon };
            return _exigenceService.Update(exigence, config);
        }

        [HttpDelete]
        public List<ExigenceEntity> Remove([FromBody] ExigenceEntity exigence, int idJalon, int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon };
            return _exigenceService.Remove(config);
        }
    }
}
