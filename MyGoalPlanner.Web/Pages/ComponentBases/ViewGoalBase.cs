using Blazored.TextEditor;
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
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IGoalService GoalService { get; set; }

        [Inject]
        public IStepService StepService { get; set; }

        [Inject]
        public IMotivatorService MotivatorService { get; set; }

        [Inject]
        public IActivityService ActivityService { get; set; }

        [Parameter]
        public int GoalId { get; set; }


        protected bool saveChangesLoader = false;
        protected bool editGoalToggler = false;
        protected Goal goal = new Goal();
        protected List<StepViewModel> steps = new List<StepViewModel>();
        protected List<MotivatorViewModel> motivators = new List<MotivatorViewModel>();
        protected List<Activity> activities = new List<Activity>();
        protected bool saveEditLoader = false;
        protected BlazoredTextEditor QuillHtml;


        #region Form_Error_Variables

        protected string goalName_error = "";
        protected string goalDescription_error = "";
        protected string timeStartOfTheGoal_error;
        protected string timeEndOfTheGoal_error;
        protected string linkToVideoMotivator_error = "";
        protected string mantra_error = "";
        protected string linkToImage_error = "";
        protected string prize_error = "";
        protected string motivator_error = "";

        #endregion


        protected override async Task OnInitializedAsync()
        {
            goal = await GoalService.GetGoal(GoalId);
            
            IEnumerable<Step> stepsI = await StepService.GetStepsOfGoalId(GoalId);
            int i = 0;

            foreach (var s in stepsI)
            {
                StepViewModel stepModel = new StepViewModel();
                stepModel.Step = s;
                stepModel.StepListId = i;
                steps.Add(stepModel);
                i++;
            }

            if (goal.HasMotivator)
            {
                IEnumerable<Motivator> motivatorsI = await MotivatorService.GetMotivatorsOfGoal(GoalId);
                
                foreach(var m in motivatorsI)
                {
                    MotivatorViewModel model = new MotivatorViewModel(m);
                    motivators.Add(model);
                }
            }
        }


        protected async Task SaveChanges()
        {
            saveChangesLoader = true;
            for(int i = 0; i < steps.Count; i++)
            {
                var result = await StepService.UpdateStep(steps[i].Step);
            }
            saveChangesLoader = false;
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

        public void ToggleGoalForm()
        {
            if (editGoalToggler)
            {
                editGoalToggler = false;
            }
            else
            {
                editGoalToggler = true;
            }
        }

        public void AddNewStep()
        {
            StepViewModel stepVM = new StepViewModel();
            Step step = new Step();
            stepVM.StepListId = steps.Count;
            stepVM.Step = step;
            stepVM.Step.StepNumber = steps.Count + 1;
            stepVM.Step.GoalId = goal.GoalId;
            stepVM.Step.StepId = 0;
            steps.Add(stepVM);
        }

        public void DeleteStep(int id)
        {
            if(steps[id].Step.StepId == 0)
            {
                steps.RemoveAt(id);
            }
            else
            {
                if (steps[id].ToBeRemoved)
                {
                    steps[id].ToBeRemoved = false;
                }
                else
                {
                    steps[id].ToBeRemoved = true;
                }
            }

            for(int i = 0; i < steps.Count; i++)
            {
                if(steps[i].ToBeRemoved != true)
                {
                    steps[i].Step.StepNumber = i;
                }
            }
        }


        public async Task UpdateGoal()
        {
            bool errorOccured = false;

            if (goal.Name == "")
            {
                goalName_error = "Please enter a name for your goal";
                errorOccured = true;
            }

            if (goal.HasMotivator)
            {
                bool oneMotivator = false;
            }

            for(int i = 0; i < steps.Count; i++)
            {
                if(steps[i].Step.StepName == "")
                {
                    errorOccured = true;
                    steps[i].StepErrorMessage = "Please write name for your step!";
                }
            }

            if (!errorOccured)
            {
                saveEditLoader = true;

                var goalResult = await GoalService.UpdateGoal(goal);

                for(int i = 0; i < steps.Count; i++)
                {
                    if(steps[i].Step.StepId == 0)
                    {
                        var stepResult = await StepService.CreateStep(steps[i].Step);
                    }
                    else
                    {
                        var stepResult = await StepService.UpdateStep(steps[i].Step);
                    }
                }

                saveEditLoader = false;
                editGoalToggler = false;
            }

        }


        public async Task DeleteGoal()
        {
            await GoalService.DeleteGoal(GoalId);
           
            for(int i = 0; i < steps.Count; i++)
            {
                var r = StepService.DeleteStep(steps[i].Step.StepId);
            }

            for(int i = 0; i < motivators.Count; i++)
            {
                var r = MotivatorService.DeleteMotivator(motivators[i].Motivator.MotivatorId);
            }

            NavigationManager.NavigateTo("/ListOfGoals");
        }
        
    }
}
