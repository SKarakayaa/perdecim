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
using Data.Abstract;
using Entities.Concrete;
using Entities.Config;
using Entities.DTO.Product;
using Microsoft.Extensions.Options;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IProductDAL _productDAL;
        private readonly IProductDemandDAL _productDemandDAL;
        private readonly IProductImageDAL _productImageDAL;
        private readonly IBrandDAL _brandDAL;
        private readonly IColorDAL _colorDAL;
        private readonly ICategoryDAL _categoryDAL;
        private readonly IDemandTypeDAL _demandTypeDAL;
        private readonly FileUploadSettings _fileUploadSettings;
        private readonly IProductColorDAL _productColorDAL;
        public ProductManager(IUnitOfWork uow, IProductDAL productDAL, IProductDemandDAL productDemandDAL, IProductImageDAL productImageDAL, IBrandDAL brandDAL, IColorDAL colorDAL, ICategoryDAL categoryDAL, IDemandTypeDAL demandTypeDAL, IOptions<FileUploadSettings> fileUploadSettings, IProductColorDAL productColorDAL)
        {
            _uow = uow;
            _productDAL = productDAL;
            _productDemandDAL = productDemandDAL;
            _productColorDAL = productColorDAL;
            _productImageDAL = productImageDAL;
            _brandDAL = brandDAL;
            _colorDAL = colorDAL;
            _categoryDAL = categoryDAL;
            _demandTypeDAL = demandTypeDAL;
            _fileUploadSettings = fileUploadSettings.Value;
        }

        public async Task<IResult> CreateProduct(CreateProductDto productDto)
        {
            Product product = new Product
            {
                BrandId = productDto.BrandId,
                CanNotable = productDto.CanNotable,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                DiscountRate = productDto.DiscountRate,
                InStock = productDto.InStock,
                IsNew = productDto.IsNew,
                IsPopular = productDto.IsPopular,
                Name = productDto.Name,
                Price = productDto.Price
            };
            product = _productDAL.Add(product);

            foreach (var colorId in productDto.ColorIds)
                product.ProductColors.Add(new ProductColor(product.Id, colorId));

            if (productDto.DemandTypeIds != null && productDto.DemandTypeIds.Count() != 0)
            {
                foreach (var demandTypeId in productDto.DemandTypeIds)
                    product.ProductDemands.Add(new ProductDemand(product.Id, demandTypeId));
            }

            if (productDto.Images != null && productDto.Images.Count() > 0)
            {
                foreach (var image in productDto.Images)
                {
                    string imageName = Guid.NewGuid() + "." + image.FileName.Split('.')[1];
                    var fileLocate = $"{productDto.FilePath}/{imageName}";
                    product.ProductImages.Add(new ProductImage { ImageName = imageName, ProductId = product.Id });

                    using (var stream = new FileStream(fileLocate, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                }
            }

            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }

        public async Task<IResult> UpdateProduct(UpdateProductDto productDto)
        {
            Product product = await _productDAL.GetAsync(x => x.Id == productDto.Id);

            product.BrandId = productDto.BrandId;
            product.CanNotable = productDto.CanNotable;
            product.CategoryId = productDto.CategoryId;
            product.Description = productDto.Description;
            product.DiscountRate = productDto.DiscountRate;
            product.InStock = productDto.InStock;
            product.IsNew = productDto.IsNew;
            product.IsPopular = productDto.IsPopular;
            product.Name = productDto.Name;
            product.Price = productDto.Price;

            _productDAL.Update(product);

            List<ProductColor> productColors = await _productColorDAL.GetListAsyncTracked(x => x.ProductId == productDto.Id);
            for (int i = 0; i < productColors.Count; i++)
            {
                if (i <= productDto.ColorIds.Count() - 1)
                {
                    productColors[i].ColorId = productDto.ColorIds[i];
                    _productColorDAL.Update(productColors[i]);
                }
                else
                {
                    _productColorDAL.Remove(productColors[i]);
                }
            }

            if (productDto.DemandTypeIds != null && productDto.DemandTypeIds.Count() != 0)
            {
                List<ProductDemand> productDemands = await _productDemandDAL.GetListAsync(x => x.ProductId == productDto.Id);
                List<ProductDemand> removedDemands = productDemands.Where(x => !productDto.DemandTypeIds.Contains(x.DemandTypeId)).ToList();
                foreach (var demandTypeId in productDto.DemandTypeIds)
                {
                    bool isExist = productDemands.Any(x => x.DemandTypeId == demandTypeId);
                    if (!isExist)
                        _productDemandDAL.Add(new ProductDemand(product.Id, demandTypeId));

                    ProductDemand isRemove = removedDemands.Count > 0 ? removedDemands.FirstOrDefault(x => x.DemandTypeId == demandTypeId) : null;
                    if (isRemove != null)
                        _productDemandDAL.Remove(isRemove);
                }
            }

            if (productDto.Images != null && productDto.Images.Count() > 0)
            {
                foreach (var image in productDto.Images)
                {
                    string imageName = Guid.NewGuid() + "." + image.FileName.Split('.')[1];
                    var fileLocate = $"{productDto.FilePath}/{imageName}";
                    product.ProductImages.Add(new ProductImage { ImageName = imageName, ProductId = product.Id });

                    using (var stream = new FileStream(fileLocate, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                }
            }

            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            Product product = await _productDAL.GetAsync(x => x.Id == id, x => x.ProductImages, x => x.ProductDemands, x => x.ProductColors);
            return new SuccessDataResult<Product>(product);
        }
        public async Task<IDataResult<Product>> GetProductWithDemandAsync(int productId)
        {
            Product product = await _productDAL.GetProductWithDemands(productId);
            return ResultHelper<Product>.DataResultReturn(product);
        }

        public async Task<IDataResult<CreateProductElementsDto>> GetCreateProductElements()
        {
            CreateProductElementsDto createProductElements = new CreateProductElementsDto();
            createProductElements.Brands = await _brandDAL.GetListAsync();
            createProductElements.Categories = (await _categoryDAL.GetListAsync(null, x => x.ChildCategories)).Where(x => x.ChildCategories.Count == 0).ToList();
            createProductElements.Colors = await _colorDAL.GetListAsync();
            createProductElements.DemandTypes = await _demandTypeDAL.GetListAsync();
            return new SuccessDataResult<CreateProductElementsDto>(createProductElements);
        }

        public async Task<IDataResult<List<Product>>> GetListAsync(Expression<Func<Product, bool>> filter = null, params Expression<Func<Product, object>>[] includes)
        {
            var products = await _productDAL.GetListAsync(filter, includes);
            return new SuccessDataResult<List<Product>>(products);
        }
    }
}