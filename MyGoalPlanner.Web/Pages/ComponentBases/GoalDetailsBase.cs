using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using MyGoalPlanner.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Pages.ComponentBases
{
    public class GoalDetailsBase : ComponentBase
    {
        public Goal Goal { get; set; } = new Goal();

        [Inject]
        public IGoalService GoalService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Goal = await GoalService.GetGoal(int.Parse(Id));
        }
    }
}
