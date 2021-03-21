using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        public CategoryManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IResult> CreateCategoryAsync(Category category)
        {
            await _uow.Categories.AddAsync(category);
            int result = await _uow.Complete();
            if (result == 1) return new SuccessResult();
            return new ErrorResult();
        }

        public async Task<IDataResult<List<Category>>> GetListAsync()
        {
            var categories = await _uow.Categories.GetListAsync();
            return new SuccessDataResult<List<Category>>(categories);
        }
    }
}