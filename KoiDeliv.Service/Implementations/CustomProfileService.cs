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
    public class CustomProfileService : ICustomProfileService
    {
        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(CustomerProfile entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerProfile> Get(Expression<Func<CustomerProfile, bool>>? filter = null, Func<IQueryable<CustomerProfile>, IOrderedQueryable<CustomerProfile>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public CustomerProfile GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(CustomerProfile entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, CustomerProfile entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerProfile entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
