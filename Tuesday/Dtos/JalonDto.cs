using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;

namespace Tuesday.Dtos
{
    public class JalonDto
    {
        public string Label { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public UserEntity Assignee { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
