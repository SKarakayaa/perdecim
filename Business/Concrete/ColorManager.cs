using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IUnitOfWork _uow;
        public ColorManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IResult> AddOrEditAsync(Color color)
        {
            if(color.Id != 0)
                _uow.Colors.Update(color);
            else
                _uow.Colors.Add(color);
            int result = await _uow.Complete();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            Color color = await _uow.Colors.GetAsync(x => x.Id == id);
            _uow.Colors.Remove(color);
            await _uow.Complete();
            return new SuccessResult();
        }

        public async Task<List<Color>> GetListAsync()
        {
            return await _uow.Colors.GetListAsync();
        }
    }
}