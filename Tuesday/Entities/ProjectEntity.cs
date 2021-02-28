using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    public class ProjectEntity
    {
        public int Id { get; set; }

        public string label { get; set; }

        public ProjectEntity(string label)
        {
            this.label = label;
        }
    }
}
