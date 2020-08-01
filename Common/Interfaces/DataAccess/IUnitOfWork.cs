using System;
using System.Threading.Tasks;
using loppinja.Common.Models.Domains;
using loppinja.DAL;
using loppinja.DAL.Repositories;

namespace loppinja.Common.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        ArticleRepository ArticleRepository {get;}
        Task<int> Save();
        void Dispose(bool disposing);
        GenericRepository<T> GetRepository<T>() where T: BaseModel;

    }
}