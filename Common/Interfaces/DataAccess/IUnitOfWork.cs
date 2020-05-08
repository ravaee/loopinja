using System;

namespace loppinja.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Dispose(bool disposing);

    }
}