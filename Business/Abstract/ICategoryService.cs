using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetListAsync();

        Task<IResult> CreateOrEditCategoryAsync(Category category);
        Task<IDataResult<List<Category>>> GetListForBannerAsync();

        Task<IResult> DeleteAsync(int id);
    }
}