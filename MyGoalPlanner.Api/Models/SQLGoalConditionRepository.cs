using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLGoalConditionRepository : IGoalConditionRepository
    {

        private readonly AppDbContext appDbContext;

        public SQLGoalConditionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<GoalCondition> AddGoalCondition(GoalCondition goalCondition)
        {
            var result = await appDbContext.GoalContitions.AddAsync(goalCondition);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteGoalCondition(int goalConditionId)
        {
            var result = await appDbContext.GoalContitions
                .FirstOrDefaultAsync(e => e.GoalConditionId == goalConditionId);

            if(result != null)
            {
                appDbContext.GoalContitions.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GoalCondition>> GetAllGoalConditions()
        {
            return await appDbContext.GoalContitions.ToListAsync();
        }

        public async Task<GoalCondition> GetGoalCondition(int goalConditionId)
        {
            return await appDbContext.GoalContitions
                .FirstOrDefaultAsync(e => e.GoalConditionId == goalConditionId);
        }

        public async Task<GoalCondition> UpdateGoalCondition(GoalCondition goalCondition)
        {
            var result = await appDbContext.GoalContitions
                .FirstOrDefaultAsync(e => e.GoalConditionId == goalCondition.GoalConditionId);

            if(result != null)
            {
                result.ConditionCount = goalCondition.ConditionCount;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return result;
        }
    }
}
