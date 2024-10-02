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
    public class PriceService : IPriceService
    {
        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(PriceList entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriceList> Get(Expression<Func<PriceList, bool>>? filter = null, Func<IQueryable<PriceList>, IOrderedQueryable<PriceList>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public PriceList GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PriceList entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, PriceList entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(PriceList entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
