using System;
using System.Threading.Tasks;
using Data.Abstract;

namespace Business.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductDAL Products { get; }
        ICategoryDAL Categories { get; }
        Task<int> Complete();
    }
}