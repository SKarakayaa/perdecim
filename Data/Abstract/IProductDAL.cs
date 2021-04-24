using System.Threading.Tasks;
using Data.Repository;
using Entities.Concrete;

namespace Data.Abstract
{
    public interface IProductDAL : IRepositoryBase<Product>
    {
        Task<Product> GetProductWithDemands(int productId);
    }
}