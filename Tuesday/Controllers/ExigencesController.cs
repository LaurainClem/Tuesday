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
        public List<ExigenceEntity> FindAll(int idJalon)
        {
            return _exigenceService.FindAll(idJalon);
        }

        [HttpGet]
        [Route("{idExigence}")]
        public ExigenceEntity FindOne(int idJalon, int idExigence)
        {
            return _exigenceService.FindOne(idExigence, idJalon);
        }

        [HttpPost]
        public ExigenceEntity Add([FromBody] ExigenceDto exigenceDto, int idJalon)
        {
            ExigenceEntity exigence = new ExigenceEntity()
            {
                Label = exigenceDto.Label,
                ExigenceId = exigenceDto.ExigenceId,
                ExigenceType = exigenceDto.ExigenceType,
            };
            return _exigenceService.Add(exigence, idJalon);
        }

        [HttpPatch]
        public ExigenceEntity Update([FromBody] ExigenceEntity exigence, int idJalon)
        {
            return _exigenceService.Update(exigence, idJalon);
        }

        [HttpDelete]
        public List<ExigenceEntity> Remove([FromBody] ExigenceEntity exigence, int idJalon)
        {
            return _exigenceService.Remove(exigence, idJalon);
        }
    }
}
