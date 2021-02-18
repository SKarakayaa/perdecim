using Autofac;
using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryDAL>().As<ICategoryDAL>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductDAL>().As<IProductDAL>();
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<UnitOfWork.IUnitOfWork>();
        }
    }
}