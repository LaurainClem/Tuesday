﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    [Table("Projet")]
    public class ProjetEntity
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public List<JalonEntity> Jalons { get; set; }
    }
}
