﻿using KoiDeliv.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.DataAccess.Repository
{
	public class ShipmentRepo : GenericRepository<Shipment>
	{
        public ShipmentRepo(KoiDeliveryDBContext context) :base(context) 
        {
            _context = context;
        }

        public async Task<List<Shipment>> GetShipmentsByOrderId(int orderId)
        {
            return await _context.Shipments.Where(s => s.OrderId == orderId).ToListAsync();
        }
    }
}
