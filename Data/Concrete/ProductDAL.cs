using Data.Repository;
using Data.Abstract;
using Data.Context;
using Entities.Concrete;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete
{
    public class ProductDAL : Repository<Product>, IProductDAL
    {
        public ProductDAL(MatmazelContext context) : base(context)
        {
        }
        public async Task<Product> GetProductWithDemands(int productId)
        {
            Product product = await base._context.Products.Where(x => x.Id == productId)
                    .Include(x => x.Category)
                    .Include(x => x.ProductDemands).ThenInclude(y => y.DemandType).ThenInclude(z => z.Demands)
                    .Include(x => x.ProductImages)
                    .FirstOrDefaultAsync();
            return product;
        }
    }
}