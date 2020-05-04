using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coreTest2Api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;

namespace coreTest2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsEnabling")]
    public class AdministrateursController : ControllerBase
    {
        private readonly Pfa_evContext _context;
        //private readonly _AppExtraSettings _AppExtra;
        //public AdministrateursController(Pfa_evContext context, IOptions<_AppExtraSettings> AppExtra)
        //{
        //    _context = context;
        //    _AppExtra = AppExtra.Value;
        //}
        public AdministrateursController(Pfa_evContext context)
        {
            _context = context;
        }
        //// GET: api/Administrateurs/Login
        //[HttpPost]
        //[Route("Login")]
        //public async Task<ActionResult> Login(Administrateur admin)
        //{
        //    //var user = await _context.Administrateur.FindAsync(admin.Id);
        //    var user = _context.Administrateur.FromSqlInterpolated($"SELECT * FROM dbo.Administrateur").Where(res => res.Email == admin.Email).FirstOrDefault();
        //    if (user != null && user.MotdePasse == admin.MotdePasse)
        //    {
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                new Claim("UserId", user.Id)
        //            }),
        //            Expires = DateTime.UtcNow.AddDays(1),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_AppExtra.JWT_Key)), SecurityAlgorithms.HmacSha256Signature),
        //        };
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //        var token = tokenHandler.WriteToken(securityToken);
        //        return Ok(new { token });
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "Email ou Mot de passe est incorrect" });
        //    }
        //}

        // GET: api/Administrateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrateur>>> GetAdministrateur()
        {
            return await _context.Administrateur.ToListAsync();
        }

        // GET: api/Administrateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrateur>> GetAdministrateur(string id)
        {
            var administrateur = await _context.Administrateur.FindAsync(id);

            if (administrateur == null)
            {
                return NotFound();
            }

            return administrateur;
        }

        // PUT: api/Administrateurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrateur(string id, Administrateur administrateur)
        {
            if (id != administrateur.Id)
            {
                return BadRequest();
            }

            _context.Entry(administrateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrateurExists(id))
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

        // POST: api/Administrateurs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Administrateur>> PostAdministrateur(Administrateur administrateur)
        {
            _context.Administrateur.Add(administrateur);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdministrateurExists(administrateur.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdministrateur", new { id = administrateur.Id }, administrateur);
        }

        // DELETE: api/Administrateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Administrateur>> DeleteAdministrateur(string id)
        {
            var administrateur = await _context.Administrateur.FindAsync(id);
            if (administrateur == null)
            {
                return NotFound();
            }

            _context.Administrateur.Remove(administrateur);
            await _context.SaveChangesAsync();

            return administrateur;
        }

        private bool AdministrateurExists(string id)
        {
            return _context.Administrateur.Any(e => e.Id == id);
        }
    }
}
