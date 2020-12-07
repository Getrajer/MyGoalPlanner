using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Models
{
    public class GoalItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        public bool Completed { get; set; }

        //FK
        public int GoalId { get; set; }

        //FK
        public int GoalItemNoteId { get; set; }

    }
}
