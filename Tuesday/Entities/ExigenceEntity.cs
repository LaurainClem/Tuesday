using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    [Table("Exigence")]
    public class ExigenceEntity
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public int JalonID { get; set; }
        [Required]
        public ExigenceType ExigenceType { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }

    public enum ExigenceType
    {
        Fonctionnelle,
        Donnees,
        Performances,
        InterfaceUtilisateur,
        Qualite,
        Services
    }
}
