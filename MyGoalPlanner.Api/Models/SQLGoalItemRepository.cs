using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLGoalItemRepository : IGoalItemRepository
    {
        public Task<GoalItem> AddGoalItem(GoalItem goalItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteGoalItem(int goalItemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GoalItem>> GetAllGoalItems()
        {
            throw new NotImplementedException();
        }

        public Task<GoalItem> GetGoalItem(int goalItemId)
        {
            throw new NotImplementedException();
        }

        public Task<GoalItem> UpdateGoalItem(GoalItem goalItem)
        {
            throw new NotImplementedException();
        }
    }
}
