using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllNotes();
        Task<Note> GetNote(int noteId);
        Task<Note> AddNote(Note note);
        Task<Note> UpdateNote(Note note);
        void DeleteNote(int noteId);
    }
}
