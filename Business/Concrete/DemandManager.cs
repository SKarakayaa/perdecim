using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Config;
using Entities.DTO.Demand;
using Microsoft.Extensions.Options;

namespace Business.Concrete
{
    public class DemandManager : IDemandService
    {
        private readonly IUnitOfWork _uow;
        private readonly FileUploadSettings _fileUploadSettings;
        public DemandManager(IUnitOfWork uow, IOptions<FileUploadSettings> fileUploadSettings)
        {
            _uow = uow;
            _fileUploadSettings = fileUploadSettings.Value;
        }

        public async Task<IResult> CreateDemandAsync(DemandCreateDto demandCreateDto)
        {
            string imageName = Guid.NewGuid().ToString() + "." + demandCreateDto.Image.FileName.Split('.')[1];
            _uow.Demands.Add(new Demand
            {
                DemandTypeId = demandCreateDto.DemandTypeId,
                ImageName = $"{_fileUploadSettings.DemandImagePath}{imageName}",
                Name = demandCreateDto.Name,
                Price = demandCreateDto.Price
            });
            int result = await _uow.Complete();
            if (result == 0)
                return new ErrorResult("Kayıt Esnasında Bir Hata Meydana Geldi !");

            var fileLocate = $"{_fileUploadSettings.MainPath}{_fileUploadSettings.DemandImagePath}{imageName}";
            using (var stream = new FileStream(fileLocate, FileMode.Create))
            {
                demandCreateDto.Image.CopyTo(stream);
            }
            return new SuccessResult();
        }

        public async Task<IResult> CreateOrUpdateDemandTypeAsync(DemandTypeCreateDto demandTypeDto)
        {
            if (demandTypeDto.Id != 0)
            {
                var demandType = await _uow.DemandTypes.GetAsync(x => x.Id == demandTypeDto.Id);
                demandType.Name = demandTypeDto.Name;
                _uow.DemandTypes.Update(demandType);
            }
            else
            {
                _uow.DemandTypes.Add(new DemandType { Name = demandTypeDto.Name });
            }
            int result = await _uow.Complete();
            if (result > 0)
                return new SuccessResult();
            return new ErrorResult("Kayıt Esnasında Bir Hata Meydana Geldi !");
        }

        public async Task<IDataResult<List<DemandType>>> GetListAsync()
        {
            var demandTypes = await _uow.DemandTypes.GetListAsync(null, new[] { "Demands" });
            if (demandTypes.Count == 0)
                return new ErrorDataResult<List<DemandType>>(demandTypes, "Kayıt Bulunamadı !");
            return new SuccessDataResult<List<DemandType>>(demandTypes);
        }

        public async Task<IResult> DeleteDemandAsync(int id)
        {
            var demand = await _uow.Demands.GetAsync(x => x.Id == id);
            _uow.Demands.Remove(demand);
            await _uow.Complete();
            return new SuccessResult();
        }

        public async Task<IResult> DeleteDemandTypeAsync(int id)
        {
            var demandType = await _uow.DemandTypes.GetAsync(x => x.Id == id, new[] { "Demands" });
            if (demandType.Demands.Count != 0)
            {
                foreach (var demand in demandType.Demands)
                {
                    _uow.Demands.Remove(demand);
                }
            }
            _uow.DemandTypes.Remove(demandType);
            await _uow.Complete();
            return new SuccessResult();
        }
    }
}