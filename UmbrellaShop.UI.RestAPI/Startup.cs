using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using PetshopApp2019.Infrastructure.SQLData.Repositories;
using UmbrellaShop.Core.ApplicationService;
using UmbrellaShop.Core.ApplicationService.ServiceImplementation;
using UmbrellaShop.Core.ApplicationService.ServiceImplemetation;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Helper;
using UmbrellaShop.Infrastructure.SQLData;
using UmbrellaShop.Infrastructure.SQLData.Repositories;

namespace UmbrellaShop.UI.RestAPI
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<UmbrellaShopContext>
                    (opt => opt.UseSqlite("Data Source=UmbrellaShopSQLLite.db")
                );
            }
            else
            {
                services.AddDbContext<UmbrellaShopContext>(
                    opt =>
                    {
                        opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
                    });
               
            }

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUmbrellaRepository, UmbrellaRepository>();
            services.AddScoped<IUmbrellaService, UmbrellaService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
            services.AddTransient<IDbInitializer, DbInitializer>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        //.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                        .WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
                );
            });
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");

            if (env.IsDevelopment())
            {               
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = scope.ServiceProvider.GetService<UmbrellaShopContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    var dbInitializer = services.GetService<IDbInitializer>();
                    dbInitializer.Seed(context);
                }


            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {

                    var context = scope.ServiceProvider.GetRequiredService<UmbrellaShopContext>();
                    IDbInitializer dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
                    context.Database.EnsureCreated();
                    dbInitializer.Seed(context);

                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}