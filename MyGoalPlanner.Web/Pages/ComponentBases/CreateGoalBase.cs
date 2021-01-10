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

        #endregion


        #region Form_Input_Variables

        protected string goalName_error = "";
        protected string goalDescription_error = "";
        protected string timeStartOfTheGoal_error;
        protected string timeEndOfTheGoal_error;
        protected string linkToVideoMotivator_error = "";
        protected string mantra_error = "";
        protected string linkToImage_error = "";
        protected string prize_error = "";



        #endregion


        #region Content_Togglers_Variables

        protected bool IfConfigureStartDate = false;
        protected bool IfConfigureEndDate = false;
        protected bool IfHasDeadline = false;
        protected bool IfHasMotivator = true;
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
            timeEndOfTheGoal = DateTime.Now;
            timeStartOfTheGoal = DateTime.Now;


            minStartDate = DateTime.UtcNow.ToString("s");

            Goals = (await GoalService.GetGoals()).ToList();
        }

        public async Task CheckInput()
        {

        }

        public async Task CreateGoal()
        {
            bool errorOccured = false;

            if(goalName == "")
            {
                goalName_error = "Please enter a name for your goal";
                errorOccured = true;
            }


            Goal goal = new Goal();
            goal.Name = goalName;
            goal.Description = goalDescription;
            goal.TimeStart = timeStartOfTheGoal;
            goal.TimeEnd = timeEndOfTheGoal;

            var result = await GoalService.CreateGoal(goal);
        }
    }
}
