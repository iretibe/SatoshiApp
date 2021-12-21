using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SatoshiApp.BasketApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatoshiApp.BasketApi
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

            //Redis Configuration
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddAutoMapper(typeof(Startup));

            //Used to add grpc client to consume the discount grpc service
            //services
            //    .AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
            //    (opt => opt.Address = new Uri(Configuration["GrpcSettings:DiscountUrl"]));

            //services.AddScoped<DiscountGrpcService>();


            ////Start MassTransit RabbitMQ Configuration**************
            //services.AddMassTransit(config =>
            //{
            //    config.UsingRabbitMq((ctx, cfg) =>
            //    {
            //        cfg.Host(Configuration["EventBusSettings:HostAddress"]);
            //    });
            //});

            //services.AddMassTransitHostedService();
            ////End MassTransit RabbitMQ Configuration**************
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SatoshiApp.BasketApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SatoshiApp.BasketApi v1"));
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
