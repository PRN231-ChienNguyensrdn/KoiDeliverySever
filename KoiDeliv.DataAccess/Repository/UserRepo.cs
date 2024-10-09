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
	public class UserRepo : GenericRepository<User>
	{
        public readonly KoiDeliveryDBContext DBContext;
        public UserRepo(KoiDeliveryDBContext context) : base(context) 
        {
            _context = context;
        }

		//public async Task<User> getUserById(int id)
		//{
		//	return await DBContext.Users.Include(b => b.Orders).FirstOrDefaultAsync(b => b.UserId == id);
		//}

		//public async Task<List<User>> getBlogById(int id)
		//{
		//	return await DBContext.Users.Include(b => b.Blogs).ToListAsync();
		//}
	}
}
