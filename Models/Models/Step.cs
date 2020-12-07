using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyGoalPlanner.Models.Models
{
    public class Step
    {
        public int StepNumber { get; set; }
        [StringLength(200)]
        public string StepName { get; set; }

        //FK
        public int GoalId { get; set; }

    }
}
