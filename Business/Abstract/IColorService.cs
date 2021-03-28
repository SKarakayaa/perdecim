using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        Task<List<Color>> GetListAsync();
        Task<IResult> AddAsync(Color color);
        Task<IResult> DeleteAsync(int id);
    }
}