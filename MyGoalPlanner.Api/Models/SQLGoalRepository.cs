using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLGoalRepository : IGoalRepository
    {
        public Task<Goal> AddGoal(Goal goal)
        {
            throw new NotImplementedException();
        }

        public void DeleteGoal(int goalId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Goal>> GetAllGoals()
        {
            throw new NotImplementedException();
        }

        public Task<Goal> GetGoal(int goalId)
        {
            throw new NotImplementedException();
        }

        public Task<Goal> UpdateGoal(Goal goal)
        {
            throw new NotImplementedException();
        }
    }
}
