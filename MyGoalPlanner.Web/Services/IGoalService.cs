using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public interface IGoalService
    {
        Task<IEnumerable<Goal>> GetGoals();
        Task<Goal> GetGoal(int id);
    }
}
