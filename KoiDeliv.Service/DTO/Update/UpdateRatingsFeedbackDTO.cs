using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Update
{
	public class UpdateRatingsFeedbackDTO
	{
		public int FeedbackId { get; set; }
		public int OrderId { get; set; }
		public int? Rating { get; set; }
		public string? Feedback { get; set; }
	}
}
