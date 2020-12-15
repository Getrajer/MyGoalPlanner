using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface IFontAwesomeRepository
    {
        Task<IEnumerable<FontAwesomeIcon>> GetAllFontAwesomeIcons();
        Task<FontAwesomeIcon> GetFontAwesomeIcon(int fontAwesomeIconlId);
        Task<FontAwesomeIcon> AddFontAwesomeIcon(FontAwesomeIcon fontAwesomeIcon);
        Task<FontAwesomeIcon> UpdateFontAwesomeIcon(FontAwesomeIcon fontAwesomeIcon);
        void DeleteFontAwesomeIcon(int fontAwesomeIconId);
    }
}
