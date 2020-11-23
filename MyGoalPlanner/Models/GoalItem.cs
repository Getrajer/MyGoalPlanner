using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Models
{
    public class GoalItem
    {
        public int Id { get; set; }
        /// <summary>
        /// This ID connects Goal item to list of goals needed to be achived to complete task
        /// </summary>
        public int GoalId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }



    }
}
