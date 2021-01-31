using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public interface IStepService
    {
        Task<Step> CreateStep(Step newStep);
        Task<IEnumerable<Step>> GetStepsOfGoalId(int Id);
        Task<Step> UpdateStep(Step step);
        Task<Step> GetStep(int Id);
    }
}
