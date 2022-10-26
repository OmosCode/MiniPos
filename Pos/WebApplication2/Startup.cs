using DAL.Context;
using DAL.Repositories.Concrete;
using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.Mappers;

namespace WebApplication2
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
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ProjectContext>();
            // coookie için kod yazýlacak.
            services.ConfigureApplicationCookie(a =>
            {
                a.LoginPath = new PathString("/Home/Login");
                a.ExpireTimeSpan = TimeSpan.FromDays(1); // kaç gün cookiede kalacak
                a.Cookie = new CookieBuilder
                {
                    Name = "UserCookie",
                    SecurePolicy = CookieSecurePolicy.Always
                };
            });

           
            services.AddAuthentication();  // kimlik doðrulama

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IReceteRepository, ReceteRepostiory>();
            services.AddScoped<ISatisHrkRepository, SatisHrkRepository>();
            services.AddScoped<IRec_CategoryRepository, Rec_CategoryRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
          


            services.AddAutoMapper(typeof(Mapping));


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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();  // kimlik doðrulama
            app.UseAuthorization();  // yetkilendirme

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
