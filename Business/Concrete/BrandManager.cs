using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IUnitOfWork _uow;
        public BrandManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IResult> AddAsync(Brand brand)
        {
            _uow.Brands.Add(brand);
            int result = await _uow.Complete();

            if (result == 0)
                return new ErrorResult(CRUDMessages.CreateMessage);

            return new SuccessResult();
        }

        public async Task<List<Brand>> GetListAsync()
        {
            return await _uow.Brands.GetListAsync();
        }
    }
}