using System;
using loppinja.DAL.Interface;
using loppinja.Models.Context;
using loppinja.Models.Domains;

namespace loppinja.DAL.InterfaceDepartment
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private GenericRepository<Article> _articleRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }
        

        public GenericRepository<Article> ArticleRepository
        {
            get
            {

                if (this._articleRepository == null)
                {
                    this._articleRepository = new GenericRepository<Article>(_context);
                }
                return _articleRepository;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
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

    }
}