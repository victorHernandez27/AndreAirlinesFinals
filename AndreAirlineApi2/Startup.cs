using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirlineApi2.Data;
using Canducci.MongoDB.Repository;
using AndreAirlineApi2.Data.Repositorios;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using AndreAirlineApi2.Service;

namespace AndreAirlineApi2
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AndreAirlineApi2", Version = "v1" });
            });

            services.AddDbContext<AndreAirlineApi2Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AndreAirlineApi2Context")));

            BsonSerializer.RegisterIdGenerator(typeof(string), new StringObjectIdGenerator()); ;

            //IoC Repositorio MongoDB
            services.AddScoped<IConnect, Connect>(_ => new Connect(Configuration));
            services.AddScoped<RepositorioAcessoImplementation, RepositorioAcesso>();
            services.AddScoped<RepositorioAeronaveImplementation, RepositorioAeronave>();
            services.AddScoped<RepositorioAeroportoImplementation, RepositorioAeroporto>();
            services.AddScoped<RepositorioClasseImplementation, RepositorioClasse>();
            services.AddScoped<RepositorioEnderecoImplementation, RepositorioEndereco>();
            services.AddScoped<RepositorioFuncaoImplementation, RepositorioFuncao>();
            services.AddScoped<RepositorioLogImplementation, RepositorioLog>();
            services.AddScoped<RepositorioPassageiroImplementation, RepositorioPassageiro>();
            services.AddScoped<RepositorioPassagemImplementation, RepositorioPassagem>();
            services.AddScoped<RepositorioPrecoBaseImplementation, RepositorioPrecoBase>();
            services.AddScoped<RepositorioUsuarioImplementation, RepositorioUsuario>();
            services.AddScoped<RepositorioVooImplementation, RepositorioVoo>();

            //IoC Service
            services.AddScoped<RegistrarLogService, RegistrarLogService>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AndreAirlineApi2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod() // Get, Post, Put, Delete, etc...
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
