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

		PriceListRepo PriceListRepo { get; }
		void Save();
    }

}
