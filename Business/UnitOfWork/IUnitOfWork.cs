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
        IProductDemandDAL ProductDemands { get; }
        IProductImageDAL ProductImages { get; }
        IUserAddressDAL UserAddressDAL { get; }
        IDistrictDAL DistrictDAL { get; }
        INeighborhoodsDAL NeighborhoodsDAL { get; }
        ICityDAL CityDAL { get; }
        Task<int> Complete();
    }
}