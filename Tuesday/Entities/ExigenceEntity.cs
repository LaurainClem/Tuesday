using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    [Table("Exigence")]
    public class ExigenceEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public JalonEntity Jalon { get; set; }
        public ExigenceType ExigenceType { get; set; }
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
