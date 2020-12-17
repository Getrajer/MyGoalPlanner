using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLFontAwesomeRepository : IFontAwesomeRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLFontAwesomeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<FontAwesomeIcon> AddFontAwesomeIcon(FontAwesomeIcon fontAwesomeIcon)
        {
            var result = await appDbContext.FontAwesomeIcons.AddAsync(fontAwesomeIcon);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteFontAwesomeIcon(int fontAwesomeIconId)
        {
            var result = await appDbContext.FontAwesomeIcons
                .FirstOrDefaultAsync(e => e.FontAwesomeIconId == fontAwesomeIconId);
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
