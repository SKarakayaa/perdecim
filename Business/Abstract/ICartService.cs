using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTO.Cart;

namespace Business.Abstract
{
    public interface ICartService
    {
        Task<IDataResult<CartDTO>> AddToCart(AddToCartDTO model);
        Task<IDataResult<CartDTO>> GetCart();
    }
}