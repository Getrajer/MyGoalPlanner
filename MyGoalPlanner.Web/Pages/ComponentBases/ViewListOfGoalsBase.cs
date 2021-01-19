using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using MyGoalPlanner.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Pages.ComponentBases
{
    public class ViewListOfGoalsBase : ComponentBase
    {
        [Inject]
        public IGoalService GoalService { get; set; }

        protected List<Goal> goals = new List<Goal>();


        protected override async Task OnInitializedAsync()
        {
            var goalss = await GoalService.GetGoals();
            goals = goalss.ToList();
        }


    }
}
