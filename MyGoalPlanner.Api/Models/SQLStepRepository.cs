using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLStepRepository : IStepRepostitory
    {
        private readonly AppDbContext appDbContext;

        public SQLStepRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Step> AddStep(Step step)
        {
            var result = await appDbContext.Steps.AddAsync(step);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Step> DeleteStep(int stepId)
        {
            var result = await appDbContext.Steps
                .FirstOrDefaultAsync(e => e.StepId == stepId);

            if(result != null)
            {
                appDbContext.Steps.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return result;

        }

        public async Task<IEnumerable<Step>> GetAllStepsOfGoalId(int GoalId)
        {
            //List<Step> steps = await appDbContext.Steps.ToListAsync();
            return appDbContext.Steps.Where(s => s.GoalId == GoalId);
        }

        public async Task<IEnumerable<Step>> GetAllSteps()
        {
            return await appDbContext.Steps.ToListAsync();
        }

        public async Task<Step> GetStep(int stepId)
        {
            Step step = await appDbContext.Steps
                .FirstOrDefaultAsync(e => e.StepId == stepId);
            if(step == null)
            {
                return null;
            }
            else
            {
                return step;
            }

            
        }

        public async Task<Step> UpdateStep(Step step)
        {
            var result = await appDbContext.Steps
                .FirstOrDefaultAsync(e => e.StepId == step.StepId);

            if(result != null)
            {
                result.StepName = step.StepName;
                result.StepNumber = step.StepNumber;
                result.StepCompleted = step.StepCompleted;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return result;
        }
    }
}
