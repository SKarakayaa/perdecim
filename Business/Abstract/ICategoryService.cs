using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetListAsync();
    }
}