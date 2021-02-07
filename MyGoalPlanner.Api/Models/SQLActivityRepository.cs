using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLActivityRepository : IActivityRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLActivityRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Activity> AddActivity(Activity activity)
        {
            var result = await appDbContext.Activities.AddAsync(activity);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Activity> DeleteActivity(int activityId)
        {
            var result = await appDbContext.Activities
                .FirstOrDefaultAsync(a => a.ActivityId == activityId);

            if(result != null)
            {
                appDbContext.Activities.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Activity> GetActivity(int activityId)
        {
            return await appDbContext.Activities
                .FirstOrDefaultAsync(a => a.ActivityId == activityId);
        }
    }
}
