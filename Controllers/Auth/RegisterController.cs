using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Context;
using UserApi.DTOs.UserDTO;
using UserApi.Models;

namespace UserApi.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RegisterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequestDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dto.Password != dto.ConfirmPassword) { 
                return BadRequest(new { message = "Las contraseñas no son iguales" });
            }

			if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest(new { message = "El email ya esta en uso" });
            }

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            string message = "Usuario registrado con éxito.";
            var response = new UserResponseDTO
            {
                Message = message,
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                RegisteredAt = user.CreateAt,
            };

            return Ok(response);
        }
    }
}
