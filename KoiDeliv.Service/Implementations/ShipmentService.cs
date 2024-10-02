using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Implementations
{
    public class ShipmentService : IShipmentService
    {
        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Shipment entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipment> Get(Expression<Func<Shipment, bool>>? filter = null, Func<IQueryable<Shipment>, IOrderedQueryable<Shipment>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public Shipment GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Shipment entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, Shipment entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(Shipment entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
