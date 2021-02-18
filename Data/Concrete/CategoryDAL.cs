using Data.Repository;
using Data.Abstract;
using Data.Context;
using Entities.Concrete;

namespace Data.Concrete
{
    public class CategoryDAL : Repository<Category>, ICategoryDAL
    {
        public CategoryDAL(MatmazelContext context) : base(context)
        {
        }
    }
}