using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLMotivatorRepository : IMotivatorRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLMotivatorRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Motivator> AddMotivator(Motivator motivator)
        {
            var result = await appDbContext.Motivators.AddAsync(motivator);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteMotivator(int motivatorId)
        {
            var result = await appDbContext.Motivators
                .FirstOrDefaultAsync(e => e.MotivatorId == motivatorId);

            if(result != null)
            {
                appDbContext.Motivators.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Motivator>> GetAllMotivators()
        {
            return await appDbContext.Motivators.ToListAsync();
        }

        public async Task<Motivator> GetMotivator(int motivatorId)
        {
            return await appDbContext.Motivators
                .FirstOrDefaultAsync(e => e.MotivatorId == motivatorId);
        }

        public async Task<Motivator> UpdateMotivator(Motivator motivator)
        {
            var result = await appDbContext.Motivators
                .FirstOrDefaultAsync(e => e.MotivatorId == motivator.MotivatorId);

            if(result != null)
            {
                result.MotivatorLink = motivator.MotivatorLink;
                result.MotivatorName = motivator.MotivatorName;
                result.MotivatorText = motivator.MotivatorText;
                result.Prize = motivator.Prize;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return result;
        }
    }
}
