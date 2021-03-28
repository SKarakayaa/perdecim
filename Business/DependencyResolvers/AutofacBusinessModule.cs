using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Interceptor;
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

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductDAL>().As<IProductDAL>();

            builder.RegisterType<DemandTypeDAL>().As<IDemandTypeDAL>();
            builder.RegisterType<DemandDAL>().As<IDemandDAL>();
            builder.RegisterType<DemandManager>().As<IDemandService>();

            builder.RegisterType<ColorDAL>().As<IColorDAL>();
            builder.RegisterType<ColorManager>().As<IColorService>();

            builder.RegisterType<BrandDAL>().As<IBrandDAL>();
            builder.RegisterType<BrandManager>().As<IBrandService>();

            builder.RegisterType<ProductDemandDAL>().As<IProductDemandDAL>();

            builder.RegisterType<ProductImageDAL>().As<IProductImageDAL>();

            builder.RegisterType<UnitOfWork.UnitOfWork>().As<UnitOfWork.IUnitOfWork>();


            // var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            // builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            // {
            //     Selector = new AspectInterceptor()
            // }).SingleInstance();
        }
    }
}