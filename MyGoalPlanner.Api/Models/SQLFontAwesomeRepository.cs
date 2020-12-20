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

            if(result != null)
            {
                appDbContext.FontAwesomeIcons.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FontAwesomeIcon>> GetAllFontAwesomeIcons()
        {
            return await appDbContext.FontAwesomeIcons.ToListAsync();
        }

        public async Task<FontAwesomeIcon> GetFontAwesomeIcon(int fontAwesomeIconlId)
        {
            return await appDbContext.FontAwesomeIcons
                .FirstOrDefaultAsync(e => e.FontAwesomeIconId == fontAwesomeIconlId);
        }

        public async Task<FontAwesomeIcon> UpdateFontAwesomeIcon(FontAwesomeIcon fontAwesomeIcon)
        {
            var result = await appDbContext.FontAwesomeIcons
                .FirstOrDefaultAsync(e => e.FontAwesomeIconId == fontAwesomeIcon.FontAwesomeIconId);

            if(result != null)
            {
                result.IconName = fontAwesomeIcon.IconName;
                result.IconSymbol = fontAwesomeIcon.IconSymbol;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return result;
        }
    }
}
