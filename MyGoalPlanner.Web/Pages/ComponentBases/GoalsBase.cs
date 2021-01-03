using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using MyGoalPlanner.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Pages.ComponentBases
{
    public class GoalsBase : ComponentBase
    {
        [Inject]
        public IGoalService GoalService { get; set; }

        public IEnumerable<Goal> Goals { get; set; }


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
