using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            services.AddMvcCore().AddFormatterMappings(options => {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
     }).AddJsonFormatters().AddCors();
            services.AddScoped<IConnectionFactory>(_ => new ConnectionFactory(""));
            services.AddMvcCore().AddFormatterMappings().AddJsonFormatters().AddCors();
            services.AddSingleton<IConnectionFactory>(_ => new ConnectionFactory(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IProductRepository,ProductRepository>();
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
            app.UseMvc();
        }
    }
}
