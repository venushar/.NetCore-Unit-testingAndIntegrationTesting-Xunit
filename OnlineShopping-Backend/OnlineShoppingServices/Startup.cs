using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnlineShoppingServices.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingServices.Common.Models;
using OnlineShoppingServices.Common.Interfaces;
using OnlineShoppingServices.Business;
using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Helpers;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace WebApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _currentEnv;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _currentEnv = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /// services.AddCors();
            services.AddControllers();
            services.AddOptions();

            // auth and mvc
            if (!(_currentEnv.IsEnvironment("Test")))
            {
                ConfigureAuth(services);
                services.AddMvc();
            }
            else
            {
                services.AddMvc(opts =>
                {
                    opts.Filters.Add(new AllowAnonymousFilter());
                });

            }
            services.AddAuthentication();           
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // Db context       
          
            services.AddDbContext<ShoppingDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("ShoppingDbCon")));
                    

            // configure DI for application services


            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductBusiness, ProductBusiness>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           if(_currentEnv.IsEnvironment("Test") || _currentEnv.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next().ConfigureAwait(false);
            });
            
            app.UseRouting();

            // global cors policy
            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader());
            if (!(_currentEnv.IsEnvironment("Test")))
            {
                app.UseAuthentication();
                app.UseAuthorization();
            }
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        public virtual void AddMvc(IServiceCollection collection)
        {
            collection.AddMvc();
        }

        public virtual void ConfigureAuth(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
   .AddJwtBearer(x =>
   {
       x.RequireHttpsMetadata = false;
       x.SaveToken = true;
       x.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(key),
           ValidateIssuer = false,
           ValidateAudience = false
       };
   });
        }
    }
}
