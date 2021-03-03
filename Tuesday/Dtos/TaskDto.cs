using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;

namespace Tuesday.Dtos
{
    public class TaskDto
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
        public List<ExigenceEntity> Exigences { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime RealStartDate { get; set; }
        public int Cost { get; set; }
        public int RequiredTaskId { get; set; }
    }
}
