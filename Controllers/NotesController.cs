using asp.net_crud.Context;
using asp.net_crud.Models;
using asp.net_crud.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.net_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public NotesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            var notes = dbContext.Notes.ToList();
            return Ok(notes);
        }

        [HttpPost]
        public IActionResult CreateNote(AddNotesDto addNotesDto)
        {
            var newNote = new Note()
            {
                Title = addNotesDto.Title,
                Content = addNotesDto.Content
            };

            dbContext.Notes.Add(newNote);
            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetNote(Guid id)
        {
            var note = dbContext.Notes.Find(id);
            if (note == null) return NotFound();

            return Ok(note);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateNote(Guid id, UpdateNoteDto updateNoteDto)
        {
            var note = dbContext.Notes.Find(id);
            if (note == null)
                return NotFound();


            note.Title = updateNoteDto.Title;
            note.Content = updateNoteDto.Content;

            dbContext.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteNote(Guid id)
        {
            var note = dbContext.Notes.Find(id);
            if (note == null)
                return NotFound();

            dbContext.Notes.Remove(note);
            return Ok();
        }
    }
}
