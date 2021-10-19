using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tinder.Data.Context;
using Tinder.Data.Entities;
using Tinder.Service.Abstract;
using Tinder.Service.Concrete;
using TinderAPI.Helper;

namespace TinderAPI
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

            services.AddControllersWithViews()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.PropertyNamingPolicy = null;
                    x.JsonSerializerOptions.Converters.Add(new DateTimeConverterUsingDateTimeParse());
                });
            services.AddDbContext<TinderDbContext>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TinderDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMatchesService, MatchesService>();
            services.AddScoped<IUnitOfWorkPattern, UnitOfWorkPattern>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TinderAPI", Version = "v1" });
            });
            services.AddCors(options =>
            {
                var frontendURL = Configuration.GetValue<string>("frontend_url");
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TinderAPI v1"));
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
