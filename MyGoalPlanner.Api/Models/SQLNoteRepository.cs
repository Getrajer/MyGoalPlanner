using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLNoteRepository : INoteRepository
    {
        private readonly AppDbContext appDbContext;

        public SQLNoteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Note> AddNote(Note note)
        {
            var result = await appDbContext.Notes.AddAsync(note);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Note> DeleteNote(int noteId)
        {
            var result = await appDbContext.Notes
                .FirstOrDefaultAsync(e => e.NoteId == noteId);

            if(result != null)
            {
                appDbContext.Notes.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return result;
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return await appDbContext.Notes.ToListAsync();
        }

        public async Task<Note> GetNote(int noteId)
        {
            return await appDbContext.Notes
                .FirstOrDefaultAsync(e => e.NoteId == noteId);
        }

        public async Task<Note> UpdateNote(Note note)
        {
            var result = await appDbContext.Notes
                .FirstOrDefaultAsync(e => e.NoteId == note.NoteId);

            if(result != null)
            {
                result.NoteText = note.NoteText;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return result;
        }
    }
}
