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
        public async Task<IResult> AddOrEditAsync(Brand brand)
        {
            if (brand.Id != 0)
                _uow.Brands.Update(brand);
            else
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
        public async Task<IResult> DeleteAsync(int id)
        {
            Brand brand = await _uow.Brands.GetAsync(x => x.Id == id);
            _uow.Brands.Remove(brand);
            await _uow.Complete();
            return new SuccessResult();
        }
    }
}