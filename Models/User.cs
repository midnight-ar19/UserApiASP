﻿namespace UserApi.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public bool IsActive { get; set; } = true;
		public DateTime CreateAt { get; set; } = DateTime.UtcNow;
	}
}
