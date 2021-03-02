using Microsoft.AspNetCore.Http;
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
    [Route("api/projects/{idProject}/[controller]")]
    [ApiController]
    public class JalonsController : ControllerBase
    {
        private readonly IJalonService _jalonService;

        public JalonsController(ILogger<JalonsController> logger, IJalonService jalonService)
        {
            _jalonService = jalonService;
        }

        [HttpGet]
        public List<JalonEntity> FindAll(int idProject)
        {
            return _jalonService.FindAll(idProject);
        }

        [HttpGet]
        [Route("{idJalon}")]
        public JalonEntity FindOne(int idProject, int idJalon)
        {
            return _jalonService.FindOne(idJalon, idProject);
        }

        [HttpPost]
        public JalonEntity Add([FromBody]JalonDto jalonDto, int idProject)
        {
            JalonEntity jalon = new JalonEntity()
            {
                Assignee = jalonDto.Assignee,
                Label = jalonDto.Label,
                PlannedStartDate = jalonDto.PlannedStartDate,
                Tasks = jalonDto.Tasks
            };
            return _jalonService.Add(jalon, idProject);
        }

        [HttpPatch]
        public JalonEntity Update([FromBody] JalonEntity jalon, int idProject)
        {
            return _jalonService.Update(jalon, idProject);
        }

        [HttpDelete]
        public List<JalonEntity> Remove([FromBody] JalonEntity jalon, int idProject)
        {
            return _jalonService.Remove(jalon, idProject);
        }
    }
}
