using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyGoalPlanner.Models.Models
{
    public class Note
    {
        public int Id { get; set; }

        [StringLength(5000)]
        public string NoteText { get; set; }

    }
}
