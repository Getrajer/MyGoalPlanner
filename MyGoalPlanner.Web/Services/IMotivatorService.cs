using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public interface IMotivatorService
    {
        Task<IEnumerable<Motivator>> GetMotivatorsOfGoal(int goalId);
        Task<Motivator> CreateMotivator(Motivator newMotivator);
        Task<Motivator> EditMotivator(Motivator editedMotivator);
        Task DeleteMotivator(int motivatorId);
    }
}
