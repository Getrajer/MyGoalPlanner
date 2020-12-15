using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLMotivatorRepository : IMotivatorRepository
    {
        public Task<Motivator> AddMotivator(Motivator motivator)
        {
            throw new NotImplementedException();
        }

        public void DeleteMotivator(int motivatorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Motivator>> GetAllMotivators()
        {
            throw new NotImplementedException();
        }

        public Task<Motivator> GetMotivator(int motivatorId)
        {
            throw new NotImplementedException();
        }

        public Task<Motivator> UpdateMotivator(Motivator motivator)
        {
            throw new NotImplementedException();
        }
    }
}
