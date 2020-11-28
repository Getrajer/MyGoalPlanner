using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyGoalPlanner.CodeBase
{
    public class TestBase : ComponentBase
    {
        //Parameters
        [Parameter] public bool LoaderAdd { get; set; } = false;

        //Toggle variables
        public bool HasToggleItems { get; set; }

        //Button Texts
        protected string ToggleAddingItemsBtnTxt = " ";

        //Input Fields
        public string GoalNameInput { get; set; }



        //Test data
        protected List<string> goalType = new List<string>();


        protected List<Goal> goals = new List<Goal>();

        protected override async Task OnInitializedAsync()
        {
            LoaderAdd = false;

            Goal goalEx = new Goal();


            goalEx.Name = "Example";

            goals.Add(goalEx);
        }


        public async Task CreateGoal()
        {
            LoaderAdd = true;

            if(GoalNameInput != "")
            {
                await Task.Delay(1000);
                LoaderAdd = false;

                Goal newGoal = new Goal();
                newGoal.Name = GoalNameInput;
                goals.Add(newGoal);
            }
        }



        public async Task ToggleAddingItems()
        {
            if (HasToggleItems)
            {
                HasToggleItems = false;
                ToggleAddingItemsBtnTxt = "\t";
            }
            else
            {
                HasToggleItems = true;
                ToggleAddingItemsBtnTxt = "✓";
            }
        }

        public async Task AddGoalItem()
        {

        }

    }
}
