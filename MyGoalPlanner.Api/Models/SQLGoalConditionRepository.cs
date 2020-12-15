using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLGoalConditionRepository : IGoalConditionRepository
    {
        public Task<GoalCondition> AddGoalCondition(GoalCondition goalCondition)
        {
            throw new NotImplementedException();
        }

        public void DeleteGoalCondition(int goalConditionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GoalCondition>> GetAllGoalConditions()
        {
            throw new NotImplementedException();
        }

        public Task<GoalCondition> GetGoalCondition(int goalConditionId)
        {
            throw new NotImplementedException();
        }

        public Task<GoalCondition> UpdateGoalCondition(GoalCondition goalCondition)
        {
            throw new NotImplementedException();
        }
    }
}
