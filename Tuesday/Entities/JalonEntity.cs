using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    [Table("Jalon")]

    public class JalonEntity
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public DateTime PlannedStartDate { get; set; }
        [Required]
        public int AssigneeId { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}
