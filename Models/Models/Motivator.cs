using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyGoalPlanner.Models.Models
{
    public class Motivator
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string MotivatorName { get; set; }
        [StringLength(300)]
        public string MotivatorLink { get; set; }
        [StringLength(500)]
        public string MotivatorText { get; set; }
        [StringLength(100)]
        public string Prize { get; set; }

    }
}
