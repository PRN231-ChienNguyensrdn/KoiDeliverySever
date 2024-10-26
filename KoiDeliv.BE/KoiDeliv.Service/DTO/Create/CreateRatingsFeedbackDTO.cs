using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Create
{
	public class CreateRatingsFeedbackDTO
	{
	 
		public int OrderId { get; set; }
		public int? Rating { get; set; }
		public string? Feedback { get; set; }
		public DateTime? CreatedAt { get; set; } = DateTime.Now;
	}
}
