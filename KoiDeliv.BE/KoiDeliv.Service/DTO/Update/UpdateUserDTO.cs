using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Update
{
	public class UpdateUserDTO
	{
		public int UserId { get; set; }
		public string FullName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PasswordHash { get; set; } = null!;
		public string Role { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public string? Address { get; set; }
	}
}
