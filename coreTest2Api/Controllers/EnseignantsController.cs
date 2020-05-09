using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coreTest2Api.Models;
using Microsoft.AspNetCore.Cors;

namespace coreTest2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsEnabling")]
    public class EnseignantsController : ControllerBase
    {
        private readonly Pfa_evContext _context;

        public EnseignantsController(Pfa_evContext context)
        {
            _context = context;
        }

        // GET: api/Enseignants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enseignant>>> GetEnseignant()
        {
            return await _context.Enseignant.ToListAsync();
        }

        // GET: api/Enseignants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enseignant>> GetEnseignant(string id)
        {
            var enseignant = await _context.Enseignant.FindAsync(id);

            if (enseignant == null)
            {
                return NotFound();
            }

            return enseignant;
        }

        // PUT: api/Enseignants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnseignant(string id, Enseignant enseignant)
        {
            if (id != enseignant.Id)
            {
                return BadRequest();
            }

            _context.Entry(enseignant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnseignantExists(id))
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

        // POST: api/Enseignants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Enseignant>> PostEnseignant(Enseignant enseignant)
        {
            _context.Enseignant.Add(enseignant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnseignantExists(enseignant.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEnseignant", new { id = enseignant.Id }, enseignant);
        }

        // DELETE: api/Enseignants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Enseignant>> DeleteEnseignant(string id)
        {
            var enseignant = await _context.Enseignant.FindAsync(id);
            if (enseignant == null)
            {
                return NotFound();
            }

            _context.Enseignant.Remove(enseignant);
            await _context.SaveChangesAsync();

            return enseignant;
        }

        private bool EnseignantExists(string id)
        {
            return _context.Enseignant.Any(e => e.Id == id);
        }
    }
}
