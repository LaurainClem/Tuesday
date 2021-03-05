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
        public int AssigneeId { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
