using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using MyGoalPlanner.Models.Models;
using MyGoalPlanner.Models.ViewModels;
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

        protected List<StepViewModel> steps = new List<StepViewModel>();

        protected override async Task OnInitializedAsync()
        {
            goal = await GoalService.GetGoal(GoalId);
            IEnumerable<Step> stepsI = await StepService.GetStepsOfGoalId(GoalId);

            int i = 0;
            foreach(var s in stepsI)
            {
                StepViewModel stepModel = new StepViewModel();
                stepModel.Step = s;
                stepModel.StepListId = i;
                steps.Add(stepModel);
                i++;
            }
        }

        protected void ChangeStepComplition(int stepId)
        {
            if(steps[stepId].Step.StepCompleted)
            {
                steps[stepId].Step.StepCompleted = false;
            }
            else
            {
                steps[stepId].Step.StepCompleted = true;
            }
        }

    }
}
