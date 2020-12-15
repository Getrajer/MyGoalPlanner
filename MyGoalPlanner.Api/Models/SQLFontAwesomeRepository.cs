using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLFontAwesomeRepository : IFontAwesomeRepository
    {
        public Task<FontAwesomeIcon> AddFontAwesomeIcon(FontAwesomeIcon fontAwesomeIcon)
        {
            throw new NotImplementedException();
        }

        public void DeleteFontAwesomeIcon(int fontAwesomeIconId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FontAwesomeIcon>> GetAllFontAwesomeIcons()
        {
            throw new NotImplementedException();
        }

        public Task<FontAwesomeIcon> GetFontAwesomeIcon(int fontAwesomeIconlId)
        {
            throw new NotImplementedException();
        }

        public Task<FontAwesomeIcon> UpdateFontAwesomeIcon(FontAwesomeIcon fontAwesomeIcon)
        {
            throw new NotImplementedException();
        }
    }
}
