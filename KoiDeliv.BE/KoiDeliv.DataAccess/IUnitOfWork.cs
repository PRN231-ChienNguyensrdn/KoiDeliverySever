using KoiDeliv.DataAccess.Models;
using KoiDeliv.DataAccess.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public interface IUnitOfWork : IDisposable
    {
        UserRepo UserRepo { get; }
        RatingsFeedbackRepo RatingsFeedbackRepo { get; }
		PriceListRepo PriceListRepo { get; }
        OrderRepo OrderRepo { get; }
        ShipmentRepo ShipmentRepo { get; }
		BlogRepo BlogRepo { get; }
        TransactionRepo TransactionRepo { get; }
        RouteRepo RouteRepo { get; }
        GSPRepo GPSRepo { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Save();
    }

}
