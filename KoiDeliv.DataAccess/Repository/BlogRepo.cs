﻿using KoiDeliv.DataAccess.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.DataAccess.Repository
{
	public class BlogRepo : GenericRepository<Blog>
	{
		public BlogRepo(KoiDeliveryDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
