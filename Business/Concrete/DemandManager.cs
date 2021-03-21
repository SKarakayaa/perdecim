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
            var result = await _uow.Demands.AddAsync(new Demand
            {
                DemandTypeId = demandCreateDto.DemandTypeId,
                ImageName = $"{_fileUploadSettings.DemandImagePath}{imageName}",
                Name = demandCreateDto.Name,
                Price = demandCreateDto.Price
            });

            if (result.Id == 0)
                return new ErrorResult("Kayıt Esnasında Bir Hata Meydana Geldi !");

            var fileLocate = $"{_fileUploadSettings.MainPath}{_fileUploadSettings.DemandImagePath}{imageName}";
            using (var stream = new FileStream(fileLocate, FileMode.Create))
            {
                demandCreateDto.Image.CopyTo(stream);
            }
            return new SuccessResult();
        }

        public async Task<IResult> CreateDemandTypeAsync(DemandTypeCreateDto demandTypeDto)
        {
            var result = await _uow.DemandTypes.AddAsync(new DemandType { Name = demandTypeDto.Name });
            if (result.Id > 0)
                return new SuccessResult();
            return new ErrorResult("Kayıt Esnasında Bir Hata Meydana Geldi !");
        }

        public async Task<IDataResult<List<DemandType>>> GetListAsync()
        {
            var demandTypes = await _uow.DemandTypes.GetListAsync();
            if (demandTypes.Count == 0)
                return new ErrorDataResult<List<DemandType>>(demandTypes, "Kayıt Bulunamadı !");
            return new SuccessDataResult<List<DemandType>>(demandTypes);
        }
    }
}