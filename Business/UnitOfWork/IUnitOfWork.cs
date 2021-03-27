using System;
using System.Threading.Tasks;
using Data.Abstract;

namespace Business.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductDAL Products { get; }
        ICategoryDAL Categories { get; }
        IDemandDAL Demands { get; }
        IDemandTypeDAL DemandTypes { get; }
        IColorDAL Colors { get; }
        IBrandDAL Brands { get; }
        Task<int> Complete();
    }
}