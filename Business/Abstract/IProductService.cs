using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetListAsync(Expression<Func<Product, bool>> filter, string[] children=null);
    }
}