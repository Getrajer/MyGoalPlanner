using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Models
{
    public class TypeOfGoal
    {
        public int TypeOfGoalId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
