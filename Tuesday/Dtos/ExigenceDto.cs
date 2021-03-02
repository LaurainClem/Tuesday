using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;

namespace Tuesday.Dtos
{
    public class ExigenceDto
    {
        public string Label { get; set; }
        public int ExigenceId { get; set; }
        public ExigenceType ExigenceType { get; set; }
    }
}
