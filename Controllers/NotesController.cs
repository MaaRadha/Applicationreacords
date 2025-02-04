using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTrackerData.Data;
using JobTrackerData.Models;
using AutoMapper;
using JobTrackerData.DTO.NotesDtos;
using System.Net.Mime;

namespace JobTrackerData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class NotesController : ControllerBase
    {
        private readonly JobTrackerDbContext _context;
        private readonly IMapper _mapper;

        public NotesController(JobTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Notes
        /// <summary>
        /// Get all Notes
        /// </summary>
        /// <returns>HTTP 200 response if successful </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<NotesReadDto>>> GetNotes()
        {
            var modelNotes = await _context.Notes.ToListAsync();
            return _mapper.Map<List<NotesReadDto>>(modelNotes);
        }

        // GET: api/Notes/5
        /// <summary>
        /// Get a single Notes by Id
        /// </summary>
        /// <param name="id">The ID of the Notes</param>
        /// <returns> HTTP 200 response if successful</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NotesReadDto>> GetNotes(int id)
        {
            var notes = await _context.Notes.FindAsync(id);

            if (notes == null)
            {
                return NotFound();
            }

            return _mapper.Map<NotesReadDto>(notes);
        }
        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update the note
        /// </summary>
        /// <param name="id">The ID of the note to update.</param>
        /// <returns>An HTTP 204 response if successful.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutNotes(int id, NotesUpdateDto notesUpdateDto)
        {
            if (id != notesUpdateDto.Id)
            {
                return BadRequest();
            }
            var notes = _mapper.Map<Notes>(notesUpdateDto); // using AutoMapper mapping the notes to update Dtos 

            _context.Entry(notes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add a new note to the database
        /// </summary>
        /// <param name="notesCreateDto">A DTO containing the properties of the new notes</param>
        /// <returns>A DTO of the newly created</returns>
        [HttpPost]
        public async Task<ActionResult<NotesCreateDto>> PostNotes(NotesCreateDto notesCreateDto)
        {
            var notes = _mapper.Map<Notes>(notesCreateDto); // using AutoMapper mapping the notes to create Dtos
            _context.Notes.Add(notes);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotes", new { id = notes.Id }, notesCreateDto);
        }

        // DELETE: api/Notes/5
        /// <summary>
        /// Remove an note from the database.
        /// </summary>
        /// <param name="id">The ID of the note to delete.</param>
        /// <returns>An HTTP 204 response if successful.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNotes(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(notes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotesExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}
