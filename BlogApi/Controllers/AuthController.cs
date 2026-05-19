using BlogApi.Data;
using BlogApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BlogApi.DTOs;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly BlogContext _context;

        public AuthController(BlogContext context)
        {
            _context = context;
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<ActionResult> Register(
            User user
        )
        {
            var emailExists =
                await _context.Users.AnyAsync(
                    x => x.Email == user.Email
                );

            if (emailExists)
            {
                return BadRequest(
                    "Email já cadastrado"
                );
            }

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // LOGIN
        [HttpPost("login")]
       public async Task<ActionResult> Login(
            LoginDTO loginData
        )
        {
            var user =
                await _context.Users.FirstOrDefaultAsync(
                    x =>
                        x.Email == loginData.Email &&
                        x.Password == loginData.Password
                );

            if (user == null)
            {
                return Unauthorized(
                    "Email ou senha inválidos"
                );
            }

            return Ok(user);
        }
    }
}