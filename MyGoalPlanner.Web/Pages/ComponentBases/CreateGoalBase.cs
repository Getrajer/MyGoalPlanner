using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using MyGoalPlanner.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Pages.ComponentBases
{
    public class CreateGoalBase : ComponentBase
    {
        [Inject]
        public IGoalService GoalService { get; set; }

        public IEnumerable<Goal> Goals { get; set; }



        #region Content_Togglers_Variables

        protected bool IfHasMotivator = false;
        protected bool IfHasVideoMotivator = false;

        #endregion

        #region Content_Togglers_Functions

        public void ToggleHasMotivator()
        {
            if (IfHasMotivator)
            {
                IfHasMotivator = false;
            }
            else
            {
                IfHasMotivator = true;
            }
        }

        public void ToggleHasVideoMotivator()
        {
            if (IfHasVideoMotivator)
            {
                IfHasVideoMotivator = false;
            }
            else
            {
                IfHasVideoMotivator = true;
            }
        }

        #endregion

        protected string GoalName = "";

        protected override async Task OnInitializedAsync()
        {
            Goals = (await GoalService.GetGoals()).ToList();
        }

        public async Task CreateGoal()
        {
            Goal g1 = new Goal();
            g1.Name = GoalName;

            var result = await GoalService.CreateGoal(g1);
        }
    }
}
