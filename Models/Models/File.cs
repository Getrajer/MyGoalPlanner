using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyGoalPlanner.Models.Models
{
    public class File
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Path { get; set; }

        //FK
        public int GoalId { get; set; }

        //FK
        public int GoalItemId { get; set; }
    }
}
