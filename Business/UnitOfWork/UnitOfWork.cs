using System;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Context;

namespace Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MatmazelContext _context;
        public IProductDAL Products { get; }
        public ICategoryDAL Categories { get; }
        public IDemandDAL Demands { get; }
        public IDemandTypeDAL DemandTypes { get; }
        public IBrandDAL Brands { get; }
        public IColorDAL Colors { get; }
        public IProductDemandDAL ProductDemands { get; }
        public IProductImageDAL ProductImages { get; }
        public IUserAddressDAL UserAddressDAL { get; }
        public IDistrictDAL DistrictDAL { get; }
        public INeighborhoodsDAL NeighborhoodsDAL { get; }
        public ICityDAL CityDAL { get; }

        public UnitOfWork(MatmazelContext context, IProductDAL productDAL, ICategoryDAL categoryDAL, IDemandDAL demandDAL, IDemandTypeDAL demandTypeDAL, IColorDAL colorDAL, IBrandDAL brandDAL, IProductDemandDAL productDemandDAL, IProductImageDAL productImageDAL, IUserAddressDAL userAddressDAL, IDistrictDAL districtDAL, INeighborhoodsDAL neighborhoodsDAL, ICityDAL cityDAL)
        {
            _context = context;
            Products = productDAL;
            Categories = categoryDAL;
            Demands = demandDAL;
            DemandTypes = demandTypeDAL;
            Brands = brandDAL;
            Colors = colorDAL;
            ProductDemands = productDemandDAL;
            ProductImages = productImageDAL;
            NeighborhoodsDAL = neighborhoodsDAL;
            DistrictDAL = districtDAL;
            CityDAL = cityDAL;
            UserAddressDAL = userAddressDAL;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}