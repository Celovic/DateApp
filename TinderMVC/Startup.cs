using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tinder.Data.Context;
using Tinder.Data.Entities;
using Tinder.Service.Abstract;
using Tinder.Service.Concrete;

namespace TinderMVC
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

            services.AddDbContext<TinderDbContext>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TinderDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMatchesService, MatchesService>();
            services.AddScoped<IUnitOfWorkPattern, UnitOfWorkPattern>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddDistributedMemoryCache();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {

                    builder.WithOrigins("https://localhost:31186").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            services.AddAuthentication(
               CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
               x =>
               {
                   x.LoginPath = "/Account/Login";
                   x.LogoutPath = "/Account/Login";
                   x.Cookie = new CookieBuilder
                   {
                       Name = "TinderUser",
                       HttpOnly = true,
                       SameSite = SameSiteMode.Strict,
                       SecurePolicy = CookieSecurePolicy.SameAsRequest
                   };
                   x.SlidingExpiration = true;
                   x.ExpireTimeSpan = TimeSpan.FromDays(7);
                   x.AccessDeniedPath = "";
               });
            services.AddMvc(options => options.EnableEndpointRouting = false);



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
                app.UseExceptionHandler("/Error");
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }

}
