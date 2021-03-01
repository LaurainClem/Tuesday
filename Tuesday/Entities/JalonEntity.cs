﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    [Table("Jalon")]

    public class JalonEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public UtilisateurEntity Assignee { get; set; }
        public List<TacheEntity> Tasks { get; set; }
    }
}
