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
    
    public class GSPRepo : GenericRepository<Gsp>
    {
        public GSPRepo(KoiDeliveryDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<string> GetlocaRan()
        {
            return await _context.Gsps
                .OrderBy(gsp => Guid.NewGuid())
                .Select(gsp => gsp.PStart)
                .FirstOrDefaultAsync();
        }
        public async Task AddGPS(List<Gsp> gsps)
        {
            await _context.AddRangeAsync(gsps);
            await _context.SaveChangesAsync();
        }

        public async Task<Gsp> GetGSP(string source, string destination)
        {
            return await _context.Gsps.FirstOrDefaultAsync(gsp => gsp.Regions.Contains(source) && gsp.Regions.Contains(destination));
        }

        public async Task<Gsp> GetGSPByLocation(string locaiton)
        {
            return await _context.Gsps.FirstOrDefaultAsync(gsp => gsp.Regions.Contains(locaiton));
        }

        public async Task<Gsp> GetGSPByPStart(string locaiton)
        {
            return await _context.Gsps.FirstOrDefaultAsync(g => g.PStart == locaiton);
        }

        public async Task<Gsp> GetGSPByPStartPEnd(string pStart, string pEnd)
        {
            return await _context.Gsps.FirstOrDefaultAsync(gsp => gsp.PStart == pStart && gsp.PEnd == pEnd);
        }
    }
}
