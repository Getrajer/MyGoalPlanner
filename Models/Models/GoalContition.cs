using System;
using System.Collections.Generic;
using System.Text;

namespace MyGoalPlanner.Models.Models
{
    public class GoalContition
    {
        public int Id { get; set; }

        public int ConditionCount { get; set; }

        //FK
        public int GoalId { get; set; }
        

    }
}
