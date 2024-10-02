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
    public class OrderService : IOrderService
    {
        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Get(Expression<Func<Order, bool>>? filter = null, Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public Order GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, Order entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
