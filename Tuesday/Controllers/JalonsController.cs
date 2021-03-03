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

        public JalonsController(IJalonService jalonService)
        {
            _jalonService = jalonService;
        }

        [HttpGet]
        public List<JalonEntity> FindAll(int idProject)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject };
            return _jalonService.FindAll(config);
        }

        [HttpGet]
        [Route("{idJalon}")]
        public JalonEntity FindOne(int idProject, int idJalon)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon };
            return _jalonService.FindOne(config);
        }

        [HttpPost]
        public JalonEntity Add([FromBody]JalonDto jalonDto, int idProject)
        {
            JalonEntity jalon = new JalonEntity()
            {
                AssigneeId = jalonDto.AssigneeId,
                Label = jalonDto.Label,
                PlannedStartDate = jalonDto.PlannedStartDate,
                ProjectId = idProject
            };
            UrlConfig config = new UrlConfig() { IdProject = idProject };
            return _jalonService.Add(jalon, config);
        }

        [HttpPatch]
        [Route("{idJalon}")]
        public JalonEntity Update([FromBody] JalonDto jalonDto, int idProject, int idJalon)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon };
            try
            {
                JalonEntity jalon = _jalonService.FindOne(config);
                jalon.AssigneeId = jalonDto.AssigneeId != 0 ? jalonDto.AssigneeId : jalon.AssigneeId;
                jalon.Label = jalonDto.Label != null ? jalonDto.Label : jalon.Label;
                jalon.PlannedStartDate = jalonDto.PlannedStartDate != new DateTime() ? jalonDto.PlannedStartDate : jalon.PlannedStartDate;
                return _jalonService.Update(jalon, config);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{idJalon}")]
        public List<JalonEntity> Remove(int idProject, int idJalon)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon };
            return _jalonService.Remove(config);
        }
    }


}
