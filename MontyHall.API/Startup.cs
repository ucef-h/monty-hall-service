using Core;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MontyHall.API.Filters;
using MontyHall.Application;
using MontyHall.Domain.MontyPlayerAggregate;
using MontyHall.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MontyHall.API
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
            services
                .AddControllers(options => options.Filters.Add(typeof(HttpGlobalExceptionFilter)))
                .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        JsonConvert.DefaultSettings = () => options.SerializerSettings;
                    }
                );
            ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MontyHall.Api", Version = "v1" });
            });
            services.AddMediatR(typeof(MontyHallAppAssemblyReference));
            services.AddSingleton<IMontyPlayerRepository, MontyPlayerInMemoryRepository>();

            services.AddTransient(typeof(IUnitOfWork<MontyPlayer>), typeof(MontyPlayerDbContext));

            services.AddFluentValidation();
            services.AddValidatorsFromAssembly(typeof(MontyHallAppAssemblyReference).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Account.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}