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
    public class RouteRepo : GenericRepository<Route>
    {
        public RouteRepo(KoiDeliveryDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Route>> getRouteByShipmentId(int id)
        {
            return await _context.Routes.Where(r => r.ShipmentId == id).ToListAsync();
        }
    }
}
