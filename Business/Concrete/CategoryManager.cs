using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        public async Task<List<Category>> GetListAsync()
        {
            return await _categoryDAL.GetListAsync();
        }
    }
}