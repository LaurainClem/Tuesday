using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    public class TaskEntity
    {
        public string label { get; set; }
        [Key]
        public int Id { get; set; }
        public string description { get; set; }
        public UtilisateurEntity asignee { get; set; }
        // public List<ExigenceEntity> exigences{ get; set; }
        public DateTime plannedStartDate { get; set; }
        public DateTime realStartDate { get; set; }
        public int cost { get; set; }
        public TaskEntity requiredTask { get; set; }
    }
}
