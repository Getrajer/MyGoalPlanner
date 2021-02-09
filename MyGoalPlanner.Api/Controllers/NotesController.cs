using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGoalPlanner.Api.Models;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        [HttpGet("noteId:int")]
        public async Task<ActionResult<Note>> GetNote(int noteId)
        {
            try
            {
                var result = await noteRepository.GetNote(noteId);

                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error geting data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote(Note note)
        {
            try
            {
                if(note == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createdNote = await noteRepository.AddNote(note);

                    return createdNote;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error with posting data to the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Note>> UpdateNote(Note updatedNote)
        {
            try
            {
                var noteToUpdate = await noteRepository.GetNote(updatedNote.NoteId);

                if(noteToUpdate == null)
                {
                    return NotFound($"Note with Id = {updatedNote.NoteId} not found");
                }

                return await noteRepository.UpdateNote(updatedNote);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error updating data");
            }
        }

        [HttpDelete("noteId:int")]
        public async Task<ActionResult<Note>> DeleteNote(int noteId)
        {
            try
            {
                var noteToDelete = await noteRepository.GetNote(noteId);

                if(noteToDelete == null)
                {
                    return NotFound($"Note with Id = {noteId} not found");
                }

                return await noteRepository.DeleteNote(noteId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                 "Error deleting data");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetNotes()
        {
            try
            {
                return Ok(await noteRepository.GetAllNotes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error geting data from the database");
            }
        }

    }
}
