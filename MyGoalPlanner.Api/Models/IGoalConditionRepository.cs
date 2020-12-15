using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface IGoalConditionRepository
    {
        Task<IEnumerable<GoalCondition>> GetAllGoalConditions();
        Task<GoalCondition> GetGoalCondition(int goalConditionId);
        Task<GoalCondition> AddGoalCondition(GoalCondition goalCondition);
        Task<GoalCondition> UpdateGoalCondition(GoalCondition goalCondition);
        void DeleteGoalCondition(int goalConditionId);
    }
}
