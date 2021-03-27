using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Product;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;
        public ProductManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id, string[] children)
        {
            Product product = await _uow.Products.GetAsync(x => x.Id == id, children);
            return new SuccessDataResult<Product>(product);
        }

        public async Task<IDataResult<CreateProductElementsDto>> GetCreateProductElements()
        {
            CreateProductElementsDto createProductElements = new CreateProductElementsDto();
            createProductElements.Brands = await _uow.Brands.GetListAsync();
            createProductElements.Categories = await _uow.Categories.GetListAsync();
            createProductElements.Colors = await _uow.Colors.GetListAsync();
            createProductElements.DemandTypes = await _uow.DemandTypes.GetListAsync();
            return new SuccessDataResult<CreateProductElementsDto>(createProductElements);
        }

        public async Task<IDataResult<List<Product>>> GetListAsync(Expression<Func<Product, bool>> filter = null, string[] children = null)
        {
            var products = await _uow.Products.GetListAsync(filter, children);
            return new SuccessDataResult<List<Product>>(products);
        }
    }
}