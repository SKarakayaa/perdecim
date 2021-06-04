using System;
using System.Linq;
using System.Net;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers;
using Business.UnitOfWork;
using Data.Abstract;
using Data.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                // var eventTypeService = serviceProvider.GetService<IEventTypeDAL>();
                // var eventService = serviceProvider.GetService<IEventDAL>();
                // var uow = serviceProvider.GetService<IUnitOfWork>();
                var context = serviceProvider.GetService<MatmazelContext>();

                if (!context.EventTypes.Any())
                {
                    context.EventTypes.Add(new EventType { Name = "Sepet İndirimi" });
                    context.EventTypes.Add(new EventType { Name = "Kupon" });
                    context.SaveChanges();

                }
                if (!context.Events.Any())
                {
                    context.Events.Add(new Event { Description = "Sepet İndirim Açıklama", DiscountRate = 20, EndDate = DateTime.Now.AddDays(7), EventTypeId = 1, ImageName = "sepet-indirim.jpeg", MinPrice = 100, StartDate = DateTime.Now });
                    context.Events.Add(new Event { Description = "Kupon Açıklama", EndDate = DateTime.Now.AddDays(7), EventTypeId = 2, ImageName = "kupon.jpeg", MinPrice = 100, StartDate = DateTime.Now, DiscountPrice = 50 });
                    context.SaveChanges();
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
