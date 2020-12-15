using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface ITypeOfGoalRepository
    {
        Task<IEnumerable<TypeOfGoal>> GetAllTypes();
        Task<TypeOfGoal> GetTypeOfGoal(int goalTypeId);
        Task<TypeOfGoal> AddTypeOfGoal(TypeOfGoal typeOfGoal);
        Task<TypeOfGoal> UpdateTypeOfGoal(TypeOfGoal typeOfGoal);
        void DeleteGoalType(int goalTypeId);
    }
}
