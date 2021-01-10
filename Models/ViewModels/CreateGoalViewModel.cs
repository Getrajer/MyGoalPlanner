using MyGoalPlanner.Models.Models;
using System.Collections.Generic;

namespace MyGoalPlanner.Models.ViewModels
{
    class CreateGoalViewModel
    {
        public Goal Goal { get; set; }
        public Note Note { get; set; }
        public List<Step> ListOfSteps { get; set; }
        public TypeOfGoal TypeOfGoal { get; set; }
    }
}
