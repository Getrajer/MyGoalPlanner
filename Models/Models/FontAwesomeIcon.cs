using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Models
{
    public class FontAwesomeIcon
    {
        public int FontAwesomeIconId { get; set; }

        [StringLength(30)]
        public string IconName { get; set; }
        [StringLength(30)]
        public string IconSymbol { get; set; }
    }
}
