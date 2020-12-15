using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface IMotivatorRepository
    {
        Task<IEnumerable<Motivator>> GetAllMotivators();
        Task<Motivator> GetMotivator(int motivatorId);
        Task<Motivator> AddMotivator(Motivator motivator);
        Task<Motivator> UpdateMotivator(Motivator motivator);
        void DeleteMotivator(int motivatorId);
    }
}
