using jsmclients.Application.Mappings;
using jsmclients.Application.Models.Requests;
using jsmclients.Application.UseCases;
using jsmclients.Core.Interfaces;
using jsmclients.Infra.Database;
using jsmclients.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;


namespace jsmclients.API
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
            //Inje��o de Depend�ncia: evita o alto n�vel de acoplamento de c�digo dentro de uma aplica��o.

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "jsmclients.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "jsmclients.API v1"));
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
