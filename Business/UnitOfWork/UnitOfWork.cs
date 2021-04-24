using System;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MatmazelContext _context;
        private readonly IServiceProvider _serviceProvider;
        private IProductDAL productDal;
        private ICategoryDAL categoryDal;
        private IDemandDAL demandDal;
        private IDemandTypeDAL demandTypeDal;
        private IBrandDAL brandDal;
        private IColorDAL colorDal;
        private IProductDemandDAL productDemandDal;
        private IProductImageDAL productImageDal;
        private IUserAddressDAL userAddressDal;
        private IDistrictDAL districtDal;
        private INeighborhoodsDAL neighborhoodsDal;
        private ICityDAL cityDal;//CityDAL;

        public UnitOfWork(MatmazelContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public IProductDAL Products => productDal ?? _serviceProvider.GetRequiredService<IProductDAL>();
        public ICategoryDAL Categories => categoryDal ?? _serviceProvider.GetRequiredService<ICategoryDAL>();
        public IDemandDAL Demands => demandDal ?? _serviceProvider.GetRequiredService<IDemandDAL>();
        public IDemandTypeDAL DemandTypes => demandTypeDal ?? _serviceProvider.GetRequiredService<IDemandTypeDAL>();
        public IBrandDAL Brands => brandDal ?? _serviceProvider.GetRequiredService<IBrandDAL>();
        public IColorDAL Colors => colorDal ?? _serviceProvider.GetRequiredService<IColorDAL>();
        public IProductDemandDAL ProductDemands => productDemandDal ?? _serviceProvider.GetRequiredService<IProductDemandDAL>();
        public IProductImageDAL ProductImages => productImageDal ?? _serviceProvider.GetRequiredService<IProductImageDAL>();
        public INeighborhoodsDAL Neighborhoods => neighborhoodsDal ?? _serviceProvider.GetRequiredService<INeighborhoodsDAL>();
        public IDistrictDAL Districts => districtDal ?? _serviceProvider.GetRequiredService<IDistrictDAL>();
        public ICityDAL Cities => cityDal ?? _serviceProvider.GetRequiredService<ICityDAL>();
        public IUserAddressDAL UserAddresses => userAddressDal ?? _serviceProvider.GetRequiredService<IUserAddressDAL>();


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