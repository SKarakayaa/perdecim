using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDAL _colorDAL;
        private readonly IUnitOfWork _uow;
        public ColorManager(IUnitOfWork uow,IColorDAL colorDAL)
        {
            _uow = uow;
            _colorDAL = colorDAL;
        }
        public async Task<IResult> AddOrEditAsync(Color color)
        {
            if(color.Id != 0)
                _colorDAL.Update(color);
            else
                _colorDAL.Add(color);
            int result = await _uow.Complete();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            Color color = await _colorDAL.GetAsync(x => x.Id == id);
            _colorDAL.Remove(color);
            await _uow.Complete();
            return new SuccessResult();
        }

        public async Task<List<Color>> GetListAsync()
        {
            return await _colorDAL.GetListAsync();
        }
    }
}