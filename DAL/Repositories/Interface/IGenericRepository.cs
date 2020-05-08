using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using loppinja.Models.Context;
using loppinja.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace loppinja.DAL
{
    public interface IGenericRepository<TEntity>{
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetByID(object id);

        Task InsertAsync(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}