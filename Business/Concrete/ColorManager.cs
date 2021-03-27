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
        public async Task<IResult> AddAsync(Color color)
        {
            _uow.Colors.Add(color);
            int result = await _uow.Complete();

            return new SuccessResult();
        }

        public async Task<List<Color>> GetListAsync()
        {
            return await _uow.Colors.GetListAsync(); 
        }
    }
}