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
    public class UserService : IUserService
    {
        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>>? filter = null, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public User GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, User entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(User entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
