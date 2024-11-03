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
    public class TransactionRepo : GenericRepository<Transaction>
    {
        public TransactionRepo(KoiDeliveryDBContext context) : base(context)
        {
            _context = context;

        }
    }
}
