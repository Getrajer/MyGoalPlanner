using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface IGoalItemRepository
    {
        Task<IEnumerable<GoalItem>> GetAllGoalItems();
        Task<GoalItem> GetGoalItem(int goalItemId);
        Task<GoalItem> AddGoalItem(GoalItem goalItem);
        Task<GoalItem> UpdateGoalItem(GoalItem goalItem);
        void DeleteGoalItem(int goalItemId);
    }
}
