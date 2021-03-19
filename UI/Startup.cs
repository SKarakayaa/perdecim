using System;
using Business.Extensions;
using Business.Factory;
using Data.Context;
using Entities.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();
            services.AddValidationInjection();

            services.AddDbContext<MatmazelContext>(option => option.UseNpgsql("Server=167.172.186.80; Database=perdecim; User Id=perdecimuser; Password=H}WuON<QXIIGfX; Port=5432;"));
            services.AddIdentity<AppUser, AppRole>(_ =>
             {
                 _.Password.RequiredLength = 5;
                 _.Password.RequireNonAlphanumeric = false;
                 _.Password.RequireLowercase = false;
                 _.Password.RequireUppercase = false;

                 _.User.RequireUniqueEmail = true;
                 _.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";
             }).AddEntityFrameworkStores<MatmazelContext>()
             .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, MyUserClaimsPrincipalFactory>();

            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/Auth/Login");
                _.LogoutPath = new PathString("/Auth/Logout");
                _.Cookie = new CookieBuilder
                {
                    Name = "AccessToken",
                    HttpOnly = false,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always
                };
                _.SlidingExpiration = true;
                _.ExpireTimeSpan = TimeSpan.FromHours(3);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            // app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
