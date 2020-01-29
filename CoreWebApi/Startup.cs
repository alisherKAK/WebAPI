using AutoMapper;
using Domain.AutoMapper;
using Domain.DbContexts;
using Domain.Infrastructure;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreWebApi
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
            services.AddControllers();
            services.AddDbContext<CarDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("CarDb"));
            });
            services.AddScoped<DbContext, CarDbContext>();
            services.AddScoped(typeof(IRepository<,>), typeof(DbRepository<,>));

            services.AddScoped(typeof(IService<,,,>), typeof(Service<,,,>));

            services.AddTransient(typeof(IMapper), config => AutoMapperConfiguration.Config());
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
