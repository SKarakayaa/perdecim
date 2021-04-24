using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Config;
using Entities.DTO.Product;
using Microsoft.Extensions.Options;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly FileUploadSettings _fileUploadSettings;
        public ProductManager(IUnitOfWork uow, IOptions<FileUploadSettings> fileUploadSettings)
        {
            _uow = uow;
            _fileUploadSettings = fileUploadSettings.Value;
        }

        public async Task<IResult> CreateOrEditProductAsync(CreateProductDto productDto)
        {
            //! Ürün tabloya kayıt yada güncelleme yapılıyor
            Product product;
            if (productDto.ProductId != null)
                product = await _uow.Products.GetAsync(x => x.Id == productDto.ProductId.Value);
            else
                product = new Product();

            product.BrandId = productDto.BrandId.Value;
            product.CanNotable = productDto.CanNotable;
            product.CategoryId = productDto.CategoryId;
            product.ColorId = productDto.ColorId;
            product.CreatedAt = DateTime.Now;
            product.Description = productDto.Description;
            product.DiscountRate = productDto.DiscountRate.HasValue ? productDto.DiscountRate.Value : 0;
            product.InStock = productDto.IsStock;
            product.IsNew = productDto.IsNew;
            product.IsPopular = productDto.IsPopular;
            product.Price = productDto.Price;
            product.Name = productDto.Name;

            if (productDto.ProductId.HasValue)
                _uow.Products.Update(product);
            else
                product = _uow.Products.Add(product);

            //! Producta bağlı DemandType'lar güncelleniyor
            if (productDto.ProductId.HasValue)
            {
                List<ProductDemand> productDemands = await _uow.ProductDemands.GetListAsync(x => x.ProductId == productDto.ProductId.Value);
                List<ProductDemand> removedDemands = productDemands.Where(x => !productDto.DemandTypeIds.Contains(x.DemandTypeId)).ToList();
                foreach (var demandTypeId in productDto.DemandTypeIds)
                {
                    bool isExist = productDemands.Any(x => x.DemandTypeId == demandTypeId);
                    if (!isExist)
                        _uow.ProductDemands.Add(new ProductDemand { DemandTypeId = demandTypeId, ProductId = product.Id });

                    ProductDemand isRemove = removedDemands.Count > 0 ? removedDemands.FirstOrDefault(x => x.DemandTypeId == demandTypeId) : null;
                    if (isRemove != null)
                        _uow.ProductDemands.Remove(isRemove);
                }
            }
            else
            {
                product.ProductDemands = new List<ProductDemand>();
                productDto.DemandTypeIds.ToList().ForEach(demandType => product.ProductDemands.Add(new ProductDemand { DemandTypeId = demandType, ProductId = product.Id }));
            }

            //! Producta bağlı resimler hem fiziksel hemde db'ye kaydediliyor
            if (productDto.Images != null && productDto.Images.Count() > 0)
            {
                if (productDto.ProductId.HasValue)
                {
                    var currentImages = await _uow.ProductImages.GetListAsync(x => x.ProductId == product.Id);
                    if (currentImages.Count > 0)
                        currentImages.ForEach(image =>
                        {
                            var fileLocate = $"{_fileUploadSettings.MainPath}{_fileUploadSettings.ProductImagePath}{image.ImageName}";
                            File.Delete(fileLocate);
                            _uow.ProductImages.Remove(image);
                        });
                }
                product.ProductImages = new List<ProductImage>();
                foreach (var image in productDto.Images)
                {
                    string imageName = Guid.NewGuid() + "." + image.FileName.Split('.')[1];
                    var fileLocate = $"{_fileUploadSettings.MainPath}{_fileUploadSettings.ProductImagePath}{imageName}";
                    product.ProductImages.Add(new ProductImage { ImageName = imageName, ProductId = product.Id });
                    using (var stream = new FileStream(fileLocate, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                }
            }
            await _uow.Complete();
            return new SuccessResult();
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            Product product = await _uow.Products.GetAsync(x => x.Id == id, x => x.ProductImages, x => x.ProductDemands);
            return new SuccessDataResult<Product>(product);
        }
        public async Task<IDataResult<Product>> GetProductWithDemandAsync(int productId)
        {
            Product product = await _uow.Products.GetProductWithDemands(productId);
            return ResultHelper<Product>.DataResultReturn(product);
        }

        public async Task<IDataResult<CreateProductElementsDto>> GetCreateProductElements()
        {
            CreateProductElementsDto createProductElements = new CreateProductElementsDto();
            createProductElements.Brands = await _uow.Brands.GetListAsync();
            createProductElements.Categories = (await _uow.Categories.GetListAsync(null, x => x.ChildCategories)).Where(x => x.ChildCategories.Count == 0).ToList();
            createProductElements.Colors = await _uow.Colors.GetListAsync();
            createProductElements.DemandTypes = await _uow.DemandTypes.GetListAsync();
            return new SuccessDataResult<CreateProductElementsDto>(createProductElements);
        }

        public async Task<IDataResult<List<Product>>> GetListAsync(Expression<Func<Product, bool>> filter = null, params Expression<Func<Product, object>>[] includes)
        {
            var products = await _uow.Products.GetListAsync(filter, includes);
            return new SuccessDataResult<List<Product>>(products);
        }
    }
}