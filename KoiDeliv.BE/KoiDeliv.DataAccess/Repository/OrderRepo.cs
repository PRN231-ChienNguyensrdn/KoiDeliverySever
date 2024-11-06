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
	public class OrderRepo : GenericRepository<Order>
	{
        public OrderRepo(KoiDeliveryDBContext context ) : base( context ) 
        {
            _context = context;
        }

        public async Task<List<Order>> getOrderUser(int uid)
        {
            return await _context.Orders.Where(u => u.CustomerId == uid).ToListAsync();
        }
    }
}
