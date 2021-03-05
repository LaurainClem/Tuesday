using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    [Table("Project")]
    public class ProjectEntity
    {
        public int Id { get; set; }

        [Required]
        public string Label { get; set; }

        public int AssigneeId { get; set; }

        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public DateTime RealStartDate { get; set; }
        public DateTime RealEndDate { get; set; }
    }
}
