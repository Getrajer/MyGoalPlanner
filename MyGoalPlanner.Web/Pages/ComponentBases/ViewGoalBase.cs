using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using MyGoalPlanner.Models.Models;
using MyGoalPlanner.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Pages.ComponentBases
{
    public class ViewGoalBase : ComponentBase
    {
        [Inject]
        public IGoalService GoalService { get; set; }

        [Inject]
        public IStepService StepService { get; set; }

        [Parameter]
        public int GoalId { get; set; }

        protected Goal goal = new Goal();

        List<Step> steps = new List<Step>();

        protected override async Task OnInitializedAsync()
        {
            goal = await GoalService.GetGoal(19);
            
        }


    }
}
