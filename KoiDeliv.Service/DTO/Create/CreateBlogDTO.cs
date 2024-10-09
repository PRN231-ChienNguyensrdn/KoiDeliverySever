using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Create
{
    public class CreateBlogDTO
    {
		public string? Title { get; set; } 
		public string? Content { get; set; } 
		public string? ImagePath { get; set; }
		public int? AuthorId { get; set; }
		public int? PriceListId { get; set; }

	}
}
