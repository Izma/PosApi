using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace PosApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public static string ConnectionString { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "PoS API",
                    Description = "Point of Sale",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Ismael López Aguilar",
                        Email = "ismael.lopez.aguilar@gmail.com",
                        Url = "https://twitter.com/ismaellopeza"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var dataPath = Path.Combine(AppContext.BaseDirectory, "Data.xml");
                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(dataPath);
            });
            var mvcCoreBuilder = services.AddMvcCore().AddFormatterMappings().AddJsonFormatters().AddJsonOptions(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore).AddCors();
            services.AddSingleton<IConnectionFactory>(_ => new ConnectionFactory(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IGroupingRepository, GroupingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseSwagger();
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowCredentials();
            });
            app.UseMvc();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PoS API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
