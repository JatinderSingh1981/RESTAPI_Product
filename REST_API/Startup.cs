using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Business.REST_API;
using Common.REST_API;
using ViewModels.REST_API;
using REST_API.Mapper;
using DBContext.REST_API;
using Microsoft.EntityFrameworkCore;
using Repository.REST_API;

namespace REST_API
{
    //Add Serilog, versioning, health check, 
    
    public class Startup
    {
        private readonly string localApis = "_localApis";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            services.AddDbContext<DataContext>();
            services.Configure<AppSettings>(Configuration);
            services.AddApplicationInsightsTelemetry(Configuration);
            //services.AddHttpClientServices(Configuration);
            services.AddControllers();

            #region Swagger
            services.AddSwaggerGen();
            #endregion

            //services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(ProductMapper).Assembly);

            #region DI
            services.AddTransient<ProductListResponse>();
            services.AddTransient<ProductResponse>();
            services.AddTransient<EnumResponse>();

            services.AddTransient<IEnumBusiness, EnumBusiness>();

            services.AddTransient<IProductBusiness, ProductBusiness>();
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion

            //Add other urls here
            services.AddCors(o => o.AddPolicy(localApis, builder =>
            {
                builder.WithOrigins(
                        "http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            app.UseCors(localApis);

            if (env.IsDevelopment())
            {
                //migrate database changes on startup (includes initial db creation)
                //apply migrations programmatically
                //If you are not running the Update-Database command on Package Manager Console
                //It should not be on Production
                context.Database.Migrate();

                app.UseDeveloperExceptionPage();

                #region Add Swagger only in Development mode

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API");
                });
                #endregion
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
