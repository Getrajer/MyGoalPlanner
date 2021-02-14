using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface IActivityRepository
    {
        Task<Activity> GetActivity(int activityId);
        Task<List<Activity>> GetActivitiesByGoalId(int goalId);
        Task<Activity> AddActivity(Activity activity);
        Task<Activity> DeleteActivity(int activityId);
    }
}
