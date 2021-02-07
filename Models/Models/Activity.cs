using System;
using System.Collections.Generic;
using System.Text;

namespace MyGoalPlanner.Models.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityType { get; set; }

        public string ActivityConnection { get; set; }
        public int ActivityConnectionId { get; set; }
    }
}
