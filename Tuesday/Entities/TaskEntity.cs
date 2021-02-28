using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuesday.Entities
{
    public class TaskEntity
    {
        private string label { get; set; }
        private int id { get; set; }
        private string description { get; set; }
        private UtilisateurEntity asignee { get; set; }
        private List<ExigenceEntity> exigences{ get; set; }
        private  DateTime plannedStartDate { get; set; }
        private  DateTime realStartDate { get; set; }
        private  int cost { get; set; }
        private  TaskEntity requiredTask { get; set; }
    }
}
