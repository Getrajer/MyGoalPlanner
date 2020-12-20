using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLTypeOfGoalRepository : ITypeOfGoalRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLTypeOfGoalRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TypeOfGoal> AddTypeOfGoal(TypeOfGoal typeOfGoal)
        {
            var result = await appDbContext.TypeOfGoals.AddAsync(typeOfGoal);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteGoalType(int goalTypeId)
        {
            var result = await appDbContext.TypeOfGoals
                .FirstOrDefaultAsync(e => e.TypeOfGoalId == goalTypeId);

            if(result != null)
            {
                appDbContext.TypeOfGoals.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TypeOfGoal>> GetAllTypes()
        {
            return await appDbContext.TypeOfGoals.ToListAsync();
        }

        public async Task<TypeOfGoal> GetTypeOfGoal(int goalTypeId)
        {
            return await appDbContext.TypeOfGoals
                .FirstAsync(e => e.TypeOfGoalId == goalTypeId);
        }

        public async Task<TypeOfGoal> UpdateTypeOfGoal(TypeOfGoal typeOfGoal)
        {
            var result = await appDbContext.TypeOfGoals
                .FirstAsync(e => e.TypeOfGoalId == typeOfGoal.TypeOfGoalId);

            if(result != null)
            {
                result.Name = typeOfGoal.Name;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return result;
        }
    }
}
