using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Abstract;
using Business.UnitOfWork;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;
        public ProductManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<Product>> GetListAsync(Expression<Func<Product, bool>> filter, string[] children = null)
        {
            return await _uow.Products.GetListAsync(filter, children);
        }
    }
}