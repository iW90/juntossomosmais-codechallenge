using JSMClientsRegistries.Application.Mappings;
using JSMClientsRegistries.Application.Models.Requests;
using JSMClientsRegistries.Application.UseCases;
using JSMClientsRegistries.Core.Interfaces;
using JSMClientsRegistries.Infra.Database;
using JSMClientsRegistries.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace JSMClientsRegistries.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddTransient<IUseCaseAsync<ElegibleListRequest, IActionResult>, ElegibleListUseCase>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
               .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            );


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JSMClientsRegistries.API", Version = "v1" });
            });

            services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JSMClientsRegistries.API v1"));
            }

            context.Database.Migrate();

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
