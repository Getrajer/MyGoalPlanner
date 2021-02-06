using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface IStepRepostitory
    {
        Task<IEnumerable<Step>> GetAllSteps();
        Task<Step> GetStep(int stepId);
        Task<Step> AddStep(Step step);
        Task<Step> UpdateStep(Step step);
        Task<IEnumerable<Step>> GetAllStepsOfGoalId(int GoalId); 
        Task<Step> DeleteStep(int stepId);
    }
}
