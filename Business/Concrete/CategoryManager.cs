using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Messages;
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

        public async Task<IResult> CreateOrEditCategoryAsync(Category category)
        {
            if (category.Id == 0)
                _uow.Categories.Add(category);
            else
                _uow.Categories.Update(category);

            int result = await _uow.Complete();
            if (result == 1) return new SuccessResult();
            return new ErrorResult();
        }

        public async Task<IDataResult<List<Category>>> GetListAsync()
        {
            var categories = await _uow.Categories.GetListAsync(null, new[] { "ChildCategories" });
            return new SuccessDataResult<List<Category>>(categories);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var category = await _uow.Categories.GetAsync(x => x.Id == id, new[] { "ChildCategories" });
            if (category.ChildCategories.Count > 0)
                return new ErrorResult(CRUDMessages.CantDeleteCauseOfChilds);
            _uow.Categories.Remove(category);
            await _uow.Complete();
            return new SuccessResult();
        }
    }
}