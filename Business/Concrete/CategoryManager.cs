using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly ICategoryDAL _categoryDAL;
        public CategoryManager(IUnitOfWork uow,ICategoryDAL categoryDAL)
        {
            _uow = uow;
            _categoryDAL = categoryDAL;
        }

        public async Task<IResult> CreateOrEditCategoryAsync(Category category)
        {
            if (category.Id == 0)
                _categoryDAL.Add(category);
            else
                _categoryDAL.Update(category);

            int result = await _uow.Complete();
            if (result == 1) return new SuccessResult();
            return new ErrorResult();
        }

        public async Task<IDataResult<List<Category>>> GetListAsync()
        {
            var categories = await _categoryDAL.GetListAsyncTracked(null, x => x.ChildCategories);
            return new SuccessDataResult<List<Category>>(categories);
        }

        public async Task<IDataResult<List<Category>>> GetListForBannerAsync()
        {
            var categories = (await _categoryDAL.GetListAsync(x => x.ParentId != null, x => x.ChildCategories)).Take(4).ToList();
            return new SuccessDataResult<List<Category>>(categories);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var category = await _categoryDAL.GetAsync(x => x.Id == id, x => x.ChildCategories);
            if (category.ChildCategories.Count > 0)
                return new ErrorResult(CRUDMessages.CantDeleteCauseOfChilds);
            _categoryDAL.Remove(category);
            await _uow.Complete();
            return new SuccessResult();
        }
    }
}