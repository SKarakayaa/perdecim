using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Product;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<List<Product>>> GetListAsync(Expression<Func<Product, bool>> filter = null, params Expression<Func<Product, object>>[] includes);
        Task<IDataResult<Product>> GetByIdAsync(int id);
        Task<IDataResult<Product>> GetProductWithDemandAsync(int productId);
        Task<IDataResult<CreateProductElementsDto>> GetCreateProductElements();
        Task<IResult> CreateOrEditProductAsync(CreateProductDto productDto);
    }
}