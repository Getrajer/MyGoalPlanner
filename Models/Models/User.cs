using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyGoalPlanner.Models.Models
{
    public class User
    {
        public int FileStorageMax { get; set; }
        public int FileStorageUsed { get; set; }
        [StringLength(300)]
        public string Motto { get; set; }

    }
}
