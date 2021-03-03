using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    public class TaskExigence
    {
        public int ExigenceId { get; set; }
        public ExigenceEntity Exigence { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
    }
}
