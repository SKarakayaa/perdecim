using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        Task<List<Brand>> GetListAsync();
        Task<IResult> AddAsync(Brand brand);
    }
}