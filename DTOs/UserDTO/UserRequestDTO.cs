using System.ComponentModel.DataAnnotations;

namespace UserApi.DTOs.UserDTO
{
	public class UserRequestDTO
	{
		[Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
		[StringLength(50, ErrorMessage = "El nombre de usuario no puede superar los 50 caracteres.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "El correo electrónico es obligatorio.")]
		[EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "La contraseña es obligatoria.")]
		[StringLength(25, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 25 caracteres.")]
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
