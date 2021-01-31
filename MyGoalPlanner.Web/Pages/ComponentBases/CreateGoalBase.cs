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
    public class CreateGoalBase : ComponentBase
    {
        [Inject]
        public IGoalService GoalService { get; set; }

        [Inject]
        public IStepService StepService { get; set; }

        public IEnumerable<Goal> Goals { get; set; }


        #region Form_Input_Variables

        protected string goalName = "";
        protected string goalDescription = "";
        protected DateTime timeStartOfTheGoal;
        protected DateTime timeEndOfTheGoal;

        protected string linkToVideoMotivator = "";
        protected string mantra = "";
        protected string linkToImage = "";
        protected string prize = "";

        //Min date time pickers
        protected string minStartDate = "";
        protected string minEndDate = "";

        protected List<Step> ListOfSteps = new List<Step>();

        #endregion


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


        #region Content_Togglers_Variables

        protected bool IfConfigureStartDate = false;
        protected bool IfConfigureEndDate = false;
        protected bool IfHasDeadline = false;
        protected bool IfHasMotivator = false;
        protected bool IfHasVideoMotivator = false;
        protected bool IfHasMantraMotivator = false;
        protected bool IfHasImageMotivator = false;
        protected bool IfHasPrizeMotivator = false;
        protected bool IfHasListOfSteps = false;

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

        public void ToggleHasMantraMotivator()
        {
            if (IfHasMantraMotivator)
            {
                IfHasMantraMotivator = false;
            }
            else
            {
                IfHasMantraMotivator = true;
            }
        }

        public void ToggleHasImageMotivator()
        {
            if (IfHasImageMotivator)
            {
                IfHasImageMotivator = false;
            }
            else
            {
                IfHasImageMotivator = true;
            }
        }

        public void ToggleHasPrizeMotivator()
        {
            if (IfHasPrizeMotivator)
            {
                IfHasPrizeMotivator = false;
            }
            else
            {
                IfHasPrizeMotivator = true;
            }
        }

        public void ToggleHasListOfSteps()
        {
            if (IfHasListOfSteps)
            {
                IfHasListOfSteps = false;
            }
            else
            {
                IfHasListOfSteps = true;
            }
        }

        public void ToggleConfigureDateStart()
        {
            if (IfConfigureStartDate)
            {
                IfConfigureStartDate = false;
            }
            else
            {
                IfConfigureStartDate = true;
            }
        }

        public void ToggleConfigureDateEnd()
        {
            if (IfConfigureEndDate)
            {
                IfConfigureEndDate = false;
            }
            else
            {
                IfConfigureEndDate = true;
            }
        }
        #endregion


        protected override async Task OnInitializedAsync()
        {
            timeEndOfTheGoal = DateTime.UtcNow;
            timeStartOfTheGoal = DateTime.UtcNow;


            minStartDate = DateTime.UtcNow.ToString("s");

            await LoadGoals();
        }

        public void AddStepToList()
        {
            Step newStep = new Step();
            newStep.StepId = ListOfSteps.Count + 1;
            ListOfSteps.Add(newStep);
        }

        public async void RemoveStepById(int Id)
        {
            ListOfSteps.RemoveAt(Id - 1);
            for(int i = 0; i < ListOfSteps.Count; i++)
            {
                ListOfSteps[i].StepId = i + 1;
            }
        }

        public async Task CheckInput()
        {

        }

        public async Task LoadGoals()
        {
            Goals = new List<Goal>();
            Goals = (await GoalService.GetGoals()).ToList();
            StateHasChanged();
        }

        public async Task CreateGoal()
        {
            bool errorOccured = false;

            if(goalName == "")
            {
                goalName_error = "Please enter a name for your goal";
                errorOccured = true;
            }

            if (IfHasMotivator)
            {
                bool oneMotivator = false;

                if (IfHasVideoMotivator)
                {
                    oneMotivator = true;

                    if(linkToVideoMotivator == "")
                    {
                        linkToVideoMotivator_error = "Please enter link to video motivator!";
                        errorOccured = true;
                    }
                }

                if (IfHasMantraMotivator)
                {
                    oneMotivator = true;

                    if (mantra == "")
                    {
                        mantra_error = "Please enter your mantra!";
                        errorOccured = true;
                    }
                }

                if (IfHasImageMotivator)
                {
                    oneMotivator = true;

                    if (linkToImage == "")
                    {
                        linkToImage_error = "Please add link to image motivator!";
                        errorOccured = true;
                    }
                }

                if (IfHasPrizeMotivator)
                {
                    oneMotivator = true;

                    if (prize == "")
                    {
                        prize_error = "Please ener your expected prize!";
                        errorOccured = true;
                    }
                }

                if (!oneMotivator)
                {
                    errorOccured = true;
                    motivator_error = "Please choose your motivator!";
                }
            }

           

            if (!errorOccured)
            {
                Goal goal = new Goal();
                goal.Name = goalName;

                goal.Description = goalDescription;
                goal.TimeStart = timeStartOfTheGoal;
                goal.TimeEnd = timeEndOfTheGoal;
                var result = await GoalService.CreateGoal(goal);
                
                for(int i = 0; i < ListOfSteps.Count; i++)
                {
                    Step step = new Step();
                    step.GoalId = result.GoalId;
                    step.StepName = ListOfSteps[i].StepName;
                    step.StepNumber = i + 1;

                    var r = await StepService.CreateStep(step);
                }
            }

            ResetVariables();

            await LoadGoals();
        }


        #region HelpingFunctions

        public void ResetVariables()
        {
            goalName = "";
            goalDescription = "";
            timeStartOfTheGoal = new DateTime();
            timeEndOfTheGoal = new DateTime();
            linkToVideoMotivator = "";
            mantra = "";
            linkToImage = "";
            prize = "";
            minStartDate = "";
            minEndDate = "";

            IfConfigureStartDate = false;
            IfConfigureEndDate = false;
            IfHasDeadline = false;
            IfHasMotivator = false;
            IfHasVideoMotivator = false;
            IfHasMantraMotivator = false;
            IfHasImageMotivator = false;
            IfHasPrizeMotivator = false;
            IfHasListOfSteps = false;

            ListOfSteps = new List<Step>();
        }

        #endregion

    }
}
