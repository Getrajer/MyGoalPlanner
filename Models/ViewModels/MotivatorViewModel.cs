using MyGoalPlanner.Models.Enum;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGoalPlanner.Models.ViewModels
{
    public class MotivatorViewModel
    {
        public MotivatorViewModel(Motivator motivator)
        {
            Motivator = motivator;
            switch (motivator.MotivatorName)
            {
                case "Image":
                    {
                        IfImageMotivator = true;
                        break;
                    }
                case "Mantra":
                    {
                        IfMantraMotivator = true;
                        break;
                    }
                case "Video":
                    {
                        IfVideoMotivator = true;
                        break;
                    }
                case "Prize":
                    {
                        IfPrizeMotivator = true;
                        break;
                    }
            }
        }

        public Motivator Motivator { get; set; }
        public bool IfVideoMotivator { get; set; }
        public bool IfMantraMotivator { get; set; }
        public bool IfPrizeMotivator { get; set; }
        public bool IfImageMotivator { get; set; }
    }
}
