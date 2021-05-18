using System;
using System.Threading.Tasks;

namespace Business.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}