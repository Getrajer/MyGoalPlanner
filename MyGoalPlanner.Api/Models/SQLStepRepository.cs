using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLStepRepository : IStepRepostitory
    {
        public Task<Step> AddStep(Step step)
        {
            throw new NotImplementedException();
        }

        public void DeleteStep(int stepId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Step>> GetAllSteps()
        {
            throw new NotImplementedException();
        }

        public Task<Step> GetStep(int stepId)
        {
            throw new NotImplementedException();
        }

        public Task<Step> UpdateStep(Step step)
        {
            throw new NotImplementedException();
        }
    }
}
