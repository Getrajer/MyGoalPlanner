using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public class NoteService : INoteService
    {
        private readonly HttpClient httpClient;

        public NoteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Note> CreateNote(Note newNote)
        {
            return await httpClient.PostJsonAsync<Note>("api/Notes", newNote);
        }

        public async Task DeleteNote(int noteId)
        {
            await httpClient.DeleteAsync($"api/Notes/{noteId}");
        }

        public async Task<Note> GetNote(int noteId)
        {
            return await httpClient.GetJsonAsync<Note>($"api/Notes/{noteId}");
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            return await httpClient.GetJsonAsync<Note[]>("api/Notes");
        }

        public async Task<Note> UpdateNote(Note updatedNote)
        {
            return await httpClient.PutJsonAsync<Note>($"api/Notes", updatedNote);
        }
    }
}
