using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotePadServerAPI.DAO;
using Swashbuckle.AspNetCore.Filters;
using System;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.EntityFrameworkCore;
using NotePadServerAPI.Data;

namespace NotePadServerAPI
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
            services.AddDbContext<NotePadServerAPIDBContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DBConnection")));
            services.AddTransient<IUsersDAO, UsersDAO>();
            services.AddTransient<IPurchasesDAO, PurchasesDAO>();
            services.AddControllers();
            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NotePadServerAPI",
                    Version = "v1",
                    Description = "Backend development for RTUITLab level 1. Yanovsky Vladislav Valerievich IKBO-01-19.",
                    Contact = new OpenApiContact
                    {
                        Name = "Yanovsky Vladislav",
                        Email = "vlad.nomerov@yandex.ru",
                        Url = new Uri("https://vk.com/soss_nom")
                    },
                });
                options.ExampleFilters();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotePadServerAPI"));
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
