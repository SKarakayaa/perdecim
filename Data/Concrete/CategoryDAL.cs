using Core.Repository;
using Data.Abstract;
using Data.Context;
using Entities.Concrete;

namespace Data.Concrete
{
    public class CategoryDAL : Repository<Category, MatmazelContext>, ICategoryDAL
    {

    }
}