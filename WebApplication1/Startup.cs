using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orderkitchen.Services;
using OrderKitchen.Domain.IRepository;
using OrderKitchen.Domain.IServices;
using OrderKitchen.Repository;
using OrderKitchen.Repository.Context;


namespace WebApplication1
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
            #region Context
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("DataBase"));
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            #endregion

            #region Cors / Mvc / Controller
            services.AddSwaggerGen();
            services.AddCors();

            services.AddMvc();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();
            #endregion

            
            #region DI
           
            //services.AddTransient<IOrderService, OrderService>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
