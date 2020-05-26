using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChordSpitterAPI.Models; 

namespace ChordSpitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChordsController : ControllerBase
    {
        private readonly ChordContext _context;

        public ChordsController(ChordContext context)
        {
            _context = context;
        }

        // GET: api/Chords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chord>>> GetChords()
        {
            return await _context.Chords.ToListAsync();
        }

        // GET: api/Chords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chord>> GetChord(long id)
        {
            var chord = await _context.Chords.FindAsync(id);

            if (chord == null)
            {
                return NotFound();
            }

            return chord;
        }

        // GET: api/Chords/Random 
        [HttpGet("Random")]
        public string GetRandomChord()
        {
            return RandomChord.GenerateRandomChord(); 
        }

        // PUT: api/Chords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChord(long id, Chord chord)
        {
            if (id != chord.Id)
            {
                return BadRequest();
            }

            _context.Entry(chord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChordExists(id))
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

        // POST: api/Chords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Chord>> PostChord(Chord chord)
        {
            _context.Chords.Add(chord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChord", new { id = chord.Id }, chord);
        }

        // DELETE: api/Chords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chord>> DeleteChord(long id)
        {
            var chord = await _context.Chords.FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }

            _context.Chords.Remove(chord);
            await _context.SaveChangesAsync();

            return chord;
        }

        private bool ChordExists(long id)
        {
            return _context.Chords.Any(e => e.Id == id);
        }
    }
}
