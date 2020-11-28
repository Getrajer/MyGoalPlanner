using MyGoalPlanner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibary.DataAccess
{
    public interface ISQLGoal
    {
        Task<List<Goal>> GetGoals();
        Task InsertGoal(Goal goal);
    }
}