using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class UserAddressDAL : Repository<UserAddress>, IUserAddressDAL
    {
        public UserAddressDAL(MatmazelContext context) : base(context)
        {
        }
    }
}