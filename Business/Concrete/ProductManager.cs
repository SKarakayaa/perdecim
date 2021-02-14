using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public async Task<List<Product>> GetListAsync(Expression<Func<Product, bool>> filter, string[] children=null)
        {
            return await _productDAL.GetListAsync(filter,children);
        }
    }
}