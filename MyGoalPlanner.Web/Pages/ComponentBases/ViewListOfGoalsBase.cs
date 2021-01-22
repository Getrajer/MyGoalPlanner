using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using MyGoalPlanner.Models.ViewModels;
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

        protected List<ViewGoalsViewModel> goals = new List<ViewGoalsViewModel>();


        protected override async Task OnInitializedAsync()
        {
            var serviceGoals = await GoalService.GetGoals();

                       
            foreach(var sG in serviceGoals)
            {
                ViewGoalsViewModel gVM = new ViewGoalsViewModel();
                gVM.Goal = sG;
                gVM.GoalRoute = $"GoalDetails/{sG.GoalId}";
                goals.Add(gVM);
            }
            
        }


    }
}
