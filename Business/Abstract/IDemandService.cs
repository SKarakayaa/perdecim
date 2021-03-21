using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Demand;

namespace Business.Abstract
{
    public interface IDemandService
    {
        Task<IDataResult<List<DemandType>>> GetListAsync();
        Task<IResult> CreateDemandTypeAsync(DemandTypeCreateDto demandTypeDto);
        Task<IResult> CreateDemandAsync(DemandCreateDto demandCreateDto);
        
    }
}