using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLGoalItemRepository : IGoalItemRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLGoalItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<GoalItem> AddGoalItem(GoalItem goalItem)
        {
            var result = await appDbContext.GoalItems.AddAsync(goalItem);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteGoalItem(int goalItemId)
        {
            var result = await appDbContext.GoalItems
                .FirstOrDefaultAsync(e => e.GoalItemId == goalItemId);

            if(result != null)
            {
                appDbContext.GoalItems.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GoalItem>> GetAllGoalItems()
        {
            return await appDbContext.GoalItems.ToListAsync();
        }

        public async Task<GoalItem> GetGoalItem(int goalItemId)
        {
            return await appDbContext.GoalItems
                .FirstOrDefaultAsync(e => e.GoalItemId == goalItemId);
        }

        public async Task<GoalItem> UpdateGoalItem(GoalItem goalItem)
        {
            var result = await appDbContext.GoalItems
                .FirstOrDefaultAsync(e => e.GoalItemId == goalItem.GoalItemId);

            if(result != null)
            {
                result.Completed = goalItem.Completed;
                result.Description = goalItem.Description;
                result.Name = goalItem.Name;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return result;
        }
    }
}
