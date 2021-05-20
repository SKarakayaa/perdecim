using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Business.UnitOfWork;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Data.Abstract;
using Entities.Concrete;
using Entities.Config;
using Entities.DTO.Demand;
using Microsoft.Extensions.Options;

namespace Business.Concrete
{
    public class DemandManager : IDemandService
    {
        private readonly IUnitOfWork _uow;
        private readonly IDemandDAL _demandDAL;
        private readonly IDemandTypeDAL _demandTypeDAL;
        private readonly FileUploadSettings _fileUploadSettings;
        public DemandManager(IUnitOfWork uow, IDemandDAL demandDAL, IDemandTypeDAL demandTypeDAL, IOptions<FileUploadSettings> fileUploadSettings)
        {
            _uow = uow;
            _fileUploadSettings = fileUploadSettings.Value;
            _demandDAL = demandDAL;
            _demandTypeDAL = demandTypeDAL;
        }

        public async Task<IResult> CreateDemandAsync(DemandCreateDto demandCreateDto)
        {
            string imageName = demandCreateDto.Image != null ? Guid.NewGuid().ToString() + "." + demandCreateDto.Image.FileName.Split('.')[1] : "";
            _demandDAL.Add(new Demand
            {
                DemandTypeId = demandCreateDto.DemandTypeId,
                ImageName = $"{imageName}",
                Name = demandCreateDto.Name,
                Price = demandCreateDto.Price
            });
            int result = await _uow.Complete();
            if (result == 0)
                return new ErrorResult(CRUDMessages.CreateMessage);

            if (demandCreateDto.Image != null)
            {
                var fileLocate = $"{demandCreateDto.FilePath}/{imageName}";
                using (var stream = new FileStream(fileLocate, FileMode.Create))
                {
                    demandCreateDto.Image.CopyTo(stream);
                }
            }

            return new SuccessResult();
        }

        public async Task<IResult> CreateOrUpdateDemandTypeAsync(DemandTypeCreateDto demandTypeDto)
        {
            if (demandTypeDto.Id != 0)
            {
                var demandType = await _demandTypeDAL.GetAsync(x => x.Id == demandTypeDto.Id);
                demandType.Name = demandTypeDto.Name;
                _demandTypeDAL.Update(demandType);
            }
            else
            {
                _demandTypeDAL.Add(new DemandType { Name = demandTypeDto.Name });
            }
            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }

        public async Task<IDataResult<List<DemandType>>> GetListAsync()
        {
            var demandTypes = await _demandTypeDAL.GetListAsync(null, x => x.Demands);
            return ResultHelper<List<DemandType>>.DataResultReturn(demandTypes);
        }

        public async Task<IResult> DeleteDemandAsync(int id)
        {
            var demand = await _demandDAL.GetAsync(x => x.Id == id);
            _demandDAL.Remove(demand);
            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }

        public async Task<IResult> DeleteDemandTypeAsync(int id)
        {
            var demandType = await _demandTypeDAL.GetAsync(x => x.Id == id, x => x.Demands);
            if (demandType.Demands.Count != 0)
            {
                foreach (var demand in demandType.Demands)
                {
                    _demandDAL.Remove(demand);
                }
            }
            _demandTypeDAL.Remove(demandType);
            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }
    }
}