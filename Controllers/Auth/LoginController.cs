using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Context;
using UserApi.DTOs.UserDTO;
using UserApi.Models;

namespace UserApi.Controllers.Auth
{
	[Route("api/auth")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly AppDbContext _context;
        public LoginController(AppDbContext context)
        {
			_context = context;
        }

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			// Buscar el usuario por correo electrónico
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.Email == dto.Email);

			// Si no se encuentra el usuario
			if (user == null)
			{
				return BadRequest(new { message = "Usuario no encontrado" });
			}

			//Compara la contrasena 
			if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))  
			{
				return Unauthorized(new { message = "Contraseña incorrecta" });
			}

			// Si la autenticación es exitosa
			var response = new UserResponseDTO
			{
				Message = "Usuario logueado con éxito.",
				Id = user.Id,
				Username = user.Username,
				Email = user.Email,
				RegisteredAt = user.CreateAt,
			};

			return Ok(response);
		}
	}
}

