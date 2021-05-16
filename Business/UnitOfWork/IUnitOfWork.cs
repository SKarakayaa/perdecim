using System;
using System.Threading.Tasks;
using Data.Abstract;

namespace Business.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}