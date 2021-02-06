using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface IMotivatorRepository
    {
        Task<IEnumerable<Motivator>> GetAllMotivatorsOfGoal(int goalId);
        Task<Motivator> GetMotivator(int motivatorId);
        Task<Motivator> AddMotivator(Motivator motivator);
        Task<Motivator> UpdateMotivator(Motivator motivator);
        Task<Motivator> DeleteMotivator(int motivatorId);
    }
}
