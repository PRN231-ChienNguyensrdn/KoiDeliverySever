using KoiDeliv.DataAccess.Models;
using KoiDeliv.DataAccess.Repository;
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
		void Save();
    }

}
