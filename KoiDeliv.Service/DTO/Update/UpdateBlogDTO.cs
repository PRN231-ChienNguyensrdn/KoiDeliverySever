﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Update
{
	public class UpdateBlogDTO
	{
		public int BlogId { get; set; }
		public string Title { get; set; } 
		public string Content { get; set; } 
		public string ImagePath { get; set; }
	}
}
