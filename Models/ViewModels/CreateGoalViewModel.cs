using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGoalPlanner.Models.ViewModels
{
    public class CreateGoalViewModel
    {
        public Goal Goal { get; set; }
        public Note Note { get; set; }
        public List<Step> ListOfSteps { get; set; }
        public TypeOfGoal TypeOfGoal { get; set; }
        //Ammount of actions done (Created goal items)
        public GoalCondition Condition { get; set; }
    }
}
