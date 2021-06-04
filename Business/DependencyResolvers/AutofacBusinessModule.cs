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
            builder.RegisterType<DistrictDAL>().As<IDistrictDAL>().InstancePerLifetimeScope();
            builder.RegisterType<NeighborhoodDAL>().As<INeighborhoodsDAL>().InstancePerLifetimeScope();
            builder.RegisterType<CityDAL>().As<ICityDAL>().InstancePerLifetimeScope();

            builder.RegisterType<UserAddressDAL>().As<IUserAddressDAL>().InstancePerLifetimeScope();
            builder.RegisterType<UserAddressManager>().As<IUserAddressService>().InstancePerLifetimeScope();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryDAL>().As<ICategoryDAL>().InstancePerLifetimeScope();

            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();

            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductDAL>().As<IProductDAL>().InstancePerLifetimeScope();

            builder.RegisterType<DemandTypeDAL>().As<IDemandTypeDAL>().InstancePerLifetimeScope();
            builder.RegisterType<DemandDAL>().As<IDemandDAL>().InstancePerLifetimeScope();
            builder.RegisterType<DemandManager>().As<IDemandService>().InstancePerLifetimeScope();

            builder.RegisterType<ColorDAL>().As<IColorDAL>().InstancePerLifetimeScope();
            builder.RegisterType<ColorManager>().As<IColorService>().InstancePerLifetimeScope();

            builder.RegisterType<BrandDAL>().As<IBrandDAL>().InstancePerLifetimeScope();
            builder.RegisterType<BrandManager>().As<IBrandService>().InstancePerLifetimeScope();

            builder.RegisterType<ProductDemandDAL>().As<IProductDemandDAL>().InstancePerLifetimeScope();

            builder.RegisterType<ProductImageDAL>().As<IProductImageDAL>().InstancePerLifetimeScope();

            builder.RegisterType<OrderDAL>().As<IOrderDAL>().InstancePerLifetimeScope();

            builder.RegisterType<OrderDemandDAL>().As<IOrderDemandDAL>().InstancePerLifetimeScope();

            builder.RegisterType<OrderDetailDAL>().As<IOrderDetailDAL>().InstancePerLifetimeScope();
            builder.RegisterType<OrderManager>().As<IOrderService>().InstancePerLifetimeScope();

            builder.RegisterType<CartManager>().As<ICartService>().InstancePerLifetimeScope();

            builder.RegisterType<EventTypeDAL>().As<IEventTypeDAL>().InstancePerLifetimeScope();

            builder.RegisterType<EventDAL>().As<IEventDAL>().InstancePerLifetimeScope();
            builder.RegisterType<EventManager>().As<IEventService>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork.UnitOfWork>().As<UnitOfWork.IUnitOfWork>().InstancePerLifetimeScope();


            // var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            // builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            // {
            //     Selector = new AspectInterceptor()
            // }).SingleInstance();
        }
    }
}