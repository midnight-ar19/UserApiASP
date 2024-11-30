namespace UserApi.DTOs.UserDTO
{
	public class UserResponseDTO
	{
		public string Message { get; set; }
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public DateTime? RegisteredAt { get; set; }
	}
}
