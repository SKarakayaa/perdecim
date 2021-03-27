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

        public UnitOfWork(MatmazelContext context, IProductDAL productDAL, ICategoryDAL categoryDAL, IDemandDAL demandDAL, IDemandTypeDAL demandTypeDAL, IColorDAL colorDAL, IBrandDAL brandDAL)
        {
            _context = context;
            Products = productDAL;
            Categories = categoryDAL;
            Demands = demandDAL;
            DemandTypes = demandTypeDAL;
            Brands = brandDAL;
            Colors = colorDAL;
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