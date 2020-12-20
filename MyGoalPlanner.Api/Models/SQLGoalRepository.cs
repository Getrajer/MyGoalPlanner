using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLGoalRepository : IGoalRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLGoalRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Goal> AddGoal(Goal goal)
        {
            var result = await appDbContext.Goals.AddAsync(goal);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteGoal(int goalId)
        {
            var result = await appDbContext.Goals
                .FirstOrDefaultAsync(e => e.GoalId == goalId);

            if(result != null)
            {
                appDbContext.Goals.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Goal>> GetAllGoals()
        {
            return await appDbContext.Goals.ToListAsync();
        }

        public async Task<Goal> GetGoal(int goalId)
        {
            return await appDbContext.Goals
                .FirstOrDefaultAsync(e => e.GoalId == goalId);
        }

        public async Task<Goal> UpdateGoal(Goal goal)
        {
            var result = await appDbContext.Goals
                .FirstOrDefaultAsync(e => e.GoalId == goal.GoalId);

            if(result != null)
            {
                result.Completed = goal.Completed;
                result.Description = goal.Description;
                result.GoalTypeId = goal.GoalTypeId;
                result.HasListOfSteps = goal.HasListOfSteps;
                result.HasMotivator = goal.HasMotivator;
                result.HasMotivator = goal.HasMotivator;
                result.HasNote = goal.HasNote;
                result.Name = goal.Name;
                result.TimeEnd = goal.TimeEnd;
                result.TimeStart = goal.TimeStart;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return result;
        }
    }
}
