using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Models
{
    public class DailyGoal
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateEnd { get; set; }

        //changed
        public string Type { get; set; }
    }
}
