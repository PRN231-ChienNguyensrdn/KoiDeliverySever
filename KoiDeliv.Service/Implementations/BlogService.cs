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
    public class BlogService : IBlogService
    {
        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blog> Get(Expression<Func<Blog, bool>>? filter = null, Func<IQueryable<Blog>, IOrderedQueryable<Blog>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public Blog GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetObjbyID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Blog entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, Blog entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
