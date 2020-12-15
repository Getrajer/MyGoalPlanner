using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class SQLNoteRepository : INoteRepository
    {
        public Task<Note> AddNote(Note note)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(int noteId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetNote(int noteId)
        {
            throw new NotImplementedException();
        }

        public Task<Note> UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
