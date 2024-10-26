using KoiDeliv.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.DataAccess.Repository
{
	public class RatingsFeedbackRepo : GenericRepository<RatingsFeedback>
	{
		private readonly KoiDeliveryDBContext _dbContext;	
        public RatingsFeedbackRepo(KoiDeliveryDBContext context) : base(context) 
        {
            _context = context;
        }

		public async Task<List<RatingsFeedback>> GetAllFeedbacksAsync()
		{
			return await _dbContext.RatingsFeedbacks
				.Include(f => f.Order)  // Eager load the Order data
				.ToListAsync();
		}
	}
}
