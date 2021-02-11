using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public interface IActivityService
    {
        Task<Activity> GetActivity(int activityId);
        Task<Activity> CreateActivity(Activity newActivity);
        Task DeleteActivity(int activityId);
    }
}
