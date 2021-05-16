using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IUnitOfWork _uow;
        private readonly IBrandDAL _brandDAL;
        public BrandManager(IUnitOfWork uow, IBrandDAL brandDAL)
        {
            _uow = uow;
            _brandDAL = brandDAL;
        }
        public async Task<IResult> AddOrEditAsync(Brand brand)
        {
            if (brand.Id != 0)
                _brandDAL.Update(brand);
            else
                _brandDAL.Add(brand);

            int result = await _uow.Complete();

            if (result == 0)
                return new ErrorResult(CRUDMessages.CreateMessage);

            return new SuccessResult();
        }
        public async Task<List<Brand>> GetListAsync()
        {
            return await _brandDAL.GetListAsync();
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            Brand brand = await _brandDAL.GetAsync(x => x.Id == id);
            _brandDAL.Remove(brand);
            await _uow.Complete();
            return new SuccessResult();
        }
    }
}