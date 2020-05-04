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
    public class UtilisateursController : ControllerBase
    {
        private readonly Pfa_evContext _context;

        public UtilisateursController(Pfa_evContext context)
        {
            _context = context;
        }

        //POST: api/Utilisateurs/Login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody]Utilisateurs utilisateur)
        {
            var user =_context.Utilisateurs.FromSqlInterpolated($"SELECT * FROM dbo.Utilisateurs").Where(res => res.Email == utilisateur.Email).FirstOrDefault();
            //var user = await _context.Utilisateurs.FindAsync(utilisateur.Id);
            if(user!=null && user.MotdePasse==utilisateur.MotdePasse && user.Email==utilisateur.Email)
            {
                return Ok(new
                {
                    user.Id,                    
                    user.Nom,
                    user.Prenom,
                    user.Email,
                    user._Status
                }); ;
            }
            else
            {
                return BadRequest(new { message = "Email ou Mot de passe est incorrect" });
            }
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateurs>>> GetUtilisateurs()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateurs>> GetUtilisateurs(string id)
        {
            var utilisateurs = await _context.Utilisateurs.FindAsync(id);

            if (utilisateurs == null)
            {
                return NotFound();
            }

            return utilisateurs;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateurs(string id, Utilisateurs utilisateurs)
        {
            if (id != utilisateurs.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilisateurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateursExists(id))
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

        // POST: api/Utilisateurs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Utilisateurs>> PostUtilisateurs(Utilisateurs utilisateurs)
        {
            _context.Utilisateurs.Add(utilisateurs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UtilisateursExists(utilisateurs.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUtilisateurs", new { id = utilisateurs.Id }, utilisateurs);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilisateurs>> DeleteUtilisateurs(string id)
        {
            var utilisateurs = await _context.Utilisateurs.FindAsync(id);
            if (utilisateurs == null)
            {
                return NotFound();
            }

            _context.Utilisateurs.Remove(utilisateurs);
            await _context.SaveChangesAsync();

            return utilisateurs;
        }

        private bool UtilisateursExists(string id)
        {
            return _context.Utilisateurs.Any(e => e.Id == id);
        }
    }
}
