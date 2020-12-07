using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Models
{
    public class Goal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public bool Completed { get; set; }
        public bool HasListOfSteps { get; set; }
        public bool HasNote { get; set; }
        public bool HasMotivator { get; set; }



        //FK
        public int GoalTypeId { get; set; }


    }
}
