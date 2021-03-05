using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    [Table("Task")]

    public class TaskEntity
    {
        [Required]
        public string Label { get; set; }
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AssigneeId { get; set; }
        [Required]
        public List<ExigenceEntity> Exigences { get; set; }
        [Required]
        public DateTime PlannedStartDate { get; set; }
        [Required]
        public DateTime PlannedEndDate { get; set; }
        public DateTime RealStartDate { get; set; }
        public DateTime RealEndDate { get; set; }
        [Required]
        public int Cost { get; set; }
        public TaskEntity RequiredTask { get; set; }

        [Required]
        public int JalonId { get; set; }
    }
}
