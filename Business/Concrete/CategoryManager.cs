using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Data.Abstract;
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
        public async Task<List<Category>> GetListAsync()
        {
            return await _uow.Categories.GetListAsync();
        }
    }
}