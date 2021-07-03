using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelListing.Services.UnitOfWork.IRepository
{
    public interface IGenericRepository<T> where T:class
    {

        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        void Update(T t);
        public void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        public Task<IEnumerable<T>> GetAll(
           Expression<Func<T, bool>> expression = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           List<string> includes = null);
        Task<T> Get(
            Expression<Func<T, bool>> expression,
            List<string> includes=null

         );
    }
}
