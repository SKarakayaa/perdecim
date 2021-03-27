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
        Task<IDataResult<List<Product>>> GetListAsync(Expression<Func<Product, bool>> filter = null, string[] children = null);
        Task<IDataResult<Product>> GetByIdAsync(int id, string[] children);
        Task<IDataResult<CreateProductElementsDto>> GetCreateProductElements();
    }
}