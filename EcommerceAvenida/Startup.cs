using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using EcommerceAvenida.Dapper;
using EcommerceAvenida.Migracao;
using EcommerceAvenida.Repositorios.Implementacao;
using EcommerceAvenida.Repositorios.Interface;
using EcommerceAvenida.Servicos.Implementacao;
using EcommerceAvenida.Servicos.Interface;

namespace EcommerceAvenida

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

            services.AddScoped<ICategoriaServico, CategoriaServico>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddScoped<Conexao>(x => new Conexao(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnidade, Unidade>();
            services.AddScoped<BancoDeDados>();

            services.AddLogging(c => c.AddFluentMigratorConsole()).AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSqlServer2012()
                .WithGlobalConnectionString(Configuration.GetConnectionString("DefaultConnection"))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Teste Simpress",
                    Description = "Api utilizada para testes.",
                    Contact = new OpenApiContact
                    {
                        Name = "Juliano Ferro",
                        Email = "jferro1993@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/juliano-alam-ferro"),
                    }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api - Teste");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}