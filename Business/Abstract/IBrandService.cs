using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        Task<List<Brand>> GetListAsync();
        Task<IResult> AddOrEditAsync(Brand brand);

        Task<IResult> DeleteAsync(int id);
    }
}