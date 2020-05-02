using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreTest2Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreTest2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly Pfa_evContext _context;
        public UserController(Pfa_evContext context)
        {
            _context = context;
        }
        // Get: /api/User
        [EnableCors("AllowOrigin")]
        [HttpGet]
        [Authorize]    
        public async Task<object> UserProfile()
        {
            string userId = User.Claims.First(res => res.Type == "UserId").Value;
            var user = await _context.Administrateur.FindAsync(userId);
            return new
            {
                user.Nom,
                user.Prenom,
                user.Email
            };
        }
    }
}