using System;
using System.Threading.Tasks;
using Data.Context;

namespace Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MatmazelContext _context;

        public UnitOfWork(MatmazelContext context)
        {
            _context = context;
        }

        public async Task<int> Complete() =>  await _context.SaveChangesAsync();
        

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