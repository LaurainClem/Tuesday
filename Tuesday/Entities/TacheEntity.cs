using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    [Table("Tache")]

    public class TacheEntity
    {
        public string Label { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public UtilisateurEntity Assignee { get; set; }
        public List<ExigenceEntity> Exigences{ get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime RealStartDate { get; set; }
        public int Cost { get; set; }
        public TacheEntity RequiredTask { get; set; }
    }
}
