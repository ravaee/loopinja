using System;
using System.Threading.Tasks;
using loppinja.Common.DAL;
using loppinja.Common.Models.Domains;
using loppinja.DAL.Repositories;
using loppinja.Models.Context;
using loppinja.Models.Domains;

namespace loppinja.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Object _genericRepository;
        private ArticleRepository _articleRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }
        

        public ArticleRepository ArticleRepository
        {
            get
            {

                if (this._articleRepository == null)
                {
                    this._articleRepository = new ArticleRepository(_context);
                }
                return _articleRepository;
            }
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public GenericRepository<T> GetRepository<T>() where T : BaseModel
        {
            if(this._genericRepository == null){
                this._genericRepository = new GenericRepository<T>(_context);
            }

            return (GenericRepository<T>)this._genericRepository;
        }
    }
}