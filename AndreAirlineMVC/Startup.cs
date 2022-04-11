using AndreAirlineApi2.Data.Repositorios;
using Canducci.MongoDB.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using Microsoft.EntityFrameworkCore;
using AndreAirlineMVC.Data;

namespace AndreAirlineMVC
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
            services.AddDbContext<AndreAirlineMVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AndreAirlineMVCContext")));

            BsonSerializer.RegisterIdGenerator(typeof(string), new StringObjectIdGenerator()); ;

            //IoC Repositorio MongoDB
            services.AddScoped<IConnect, Connect>(_ => new Connect(Configuration));
            services.AddScoped<RepositorioAeroportoImplementation, RepositorioAeroporto>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
