using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> GetAllGoals();
        Task<Goal> GetGoal(int goalId);
        Task<Goal> AddGoal(Goal goal);
        Task<Goal> UpdateGoal(Goal goal);
        void DeleteGoal(int goalId);
    }
}
