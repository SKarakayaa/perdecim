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
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<UnitOfWork.IUnitOfWork>();

            // var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            // builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            // {
            //     Selector = new AspectInterceptor()
            // }).SingleInstance();
        }
    }
}