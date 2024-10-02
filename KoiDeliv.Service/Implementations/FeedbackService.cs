using KoiDeliv.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(FeedbackService entityToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeedbackService> Get(Expression<Func<FeedbackService, bool>>? filter = null, Func<IQueryable<FeedbackService>, IOrderedQueryable<FeedbackService>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public FeedbackService GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(FeedbackService entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(object id, FeedbackService entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(FeedbackService entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
