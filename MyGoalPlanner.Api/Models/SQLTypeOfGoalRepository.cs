using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLTypeOfGoalRepository : ITypeOfGoalRepository
    {
        public Task<TypeOfGoal> AddTypeOfGoal(TypeOfGoal typeOfGoal)
        {
            throw new NotImplementedException();
        }

        public void DeleteGoalType(int goalTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeOfGoal>> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public Task<TypeOfGoal> GetTypeOfGoal(int goalTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<TypeOfGoal> UpdateTypeOfGoal(TypeOfGoal typeOfGoal)
        {
            throw new NotImplementedException();
        }
    }
}
