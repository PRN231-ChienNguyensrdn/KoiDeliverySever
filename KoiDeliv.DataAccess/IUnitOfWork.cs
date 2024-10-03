﻿using KoiDeliv.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public interface IUnitOfWork : IDisposable
    {
        RatingsFeedbackRepo RatingsFeedbackRepo { get; }
		PriceListRepo PriceListRepo { get; }
        OrderRepo OrderRepo { get; }
		void Save();
    }

}
