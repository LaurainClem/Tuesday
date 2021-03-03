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
    [Route("api/projects/{idProject}/jalons/{idJalon}/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _TaskService;
        public TasksController(ITaskService taskService)
        {
            _TaskService = taskService;
        }

        [HttpGet]
        public List<TaskEntity> FindAll(int idProject, int idJalon)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon };
            return _TaskService.FindAll(config);
        }

        [HttpGet]
        [Route("{idTask}")]
        public TaskEntity FindOne(int idProject, int idJalon, int idTask)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon, IdTask = idTask};
            return _TaskService.FindOne(config);
        }

        [HttpPost]
        public TaskEntity Add([FromBody] TaskDto taskDto, int idProject, int idJalon)
        {
            TaskEntity task = new TaskEntity()
            {
                AssigneeId = taskDto.AssigneeId,
                Label = taskDto.Label,
                PlannedStartDate = taskDto.PlannedStartDate,
                Cost = taskDto.Cost,
                Description = taskDto.Description,
                Exigences = taskDto.Exigences,
                JalonId = idJalon,
                RequiredTask = taskDto.RequiredTaskId,
            };
            UrlConfig config = new UrlConfig() { IdProject = idProject };
            return _TaskService.Add(task, config);
        }

        [HttpPatch]
        [Route("{idTask}")]
        public TaskEntity Update([FromBody] TaskDto taskDto, int idProject, int idJalon, int idTask)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon, IdTask = idTask };
            try
            {
                TaskEntity task = _TaskService.FindOne(config);
                if (task != null) {
                    task.AssigneeId = taskDto.AssigneeId != 0 ? taskDto.AssigneeId : task.AssigneeId;
                    task.Label = taskDto.Label != null ? taskDto.Label : task.Label;
                    task.PlannedStartDate = taskDto.PlannedStartDate != new DateTime() ? taskDto.PlannedStartDate : task.PlannedStartDate;
                    task.Cost = taskDto.Cost != 0 ? taskDto.Cost : task.Cost;
                    task.Description = taskDto.Description != null ? taskDto.Description : task.Description;
                    task.Exigences = taskDto.Exigences != null ? taskDto.Exigences : task.Exigences;
                    task.RequiredTask = taskDto.RequiredTaskId != null ? taskDto.RequiredTaskId : task.RequiredTask;
                    task.RealStartDate = taskDto.RealStartDate != new DateTime() ? taskDto.RealStartDate : task.RealStartDate;
                    task.RealEndDate = taskDto.RealEndDate != new DateTime() ? taskDto.RealEndDate : task.RealEndDate;

                    return _TaskService.Update(task, config);
                } else
                {
                    throw new HttpNotFoundException();
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{idTask}")]
        public List<TaskEntity> Remove(int idProject, int idJalon, int idTask)
        {
            UrlConfig config = new UrlConfig() { IdProject = idProject, IdJalon = idJalon, IdTask = idTask };
            return _TaskService.Remove(config);
        }
    }
}
