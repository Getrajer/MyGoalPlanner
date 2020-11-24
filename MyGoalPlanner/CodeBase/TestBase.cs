using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyGoalPlanner.Models;


namespace MyGoalPlanner.CodeBase
{
    public class TestBase : ComponentBase
    {
        //Parameters
        [Parameter] public bool LoaderAdd { get; set; } = false;


        //Input Fields
        public string GoalNameInput { get; set; }


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

    }
}
