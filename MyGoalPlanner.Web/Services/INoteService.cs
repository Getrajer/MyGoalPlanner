using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> GetNote(int noteId);
        Task<Note> CreateNote(Note newNote);
        Task<Note> UpdateNote(Note updatedNote);
        Task DeleteNote(int noteId);
    }
}
