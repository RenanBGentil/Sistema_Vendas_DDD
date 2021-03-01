using Aplicacao.Servico;
using Dominio.Interfaces;
using Dominio.Repositorios;
using Dominio.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Contexto;
using Repositorio.Entidades;
namespace SistemaVendas
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyStock")) );
            services.AddHttpContextAccessor();
            services.AddSession();

            //Servico Aplicacao
            services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();           
            services.AddScoped<IServicoAplicacaoCliente, ServicoAplicacaoCliente>();           
            services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();           
            services.AddScoped<IServicoAplicacaoVenda, ServicoAplicacaoVenda>();           
            services.AddScoped<IServicoAplicacaoUsuario, ServicoAplicacaoUsuario>();           
            
            //Dominio
            services.AddScoped<IServicoCategoria, ServicoCategoria>();            
            services.AddScoped<IServicoCliente, ServicoCliente>();            
            services.AddScoped<IServicoProduto, ServicoProduto>();            
            services.AddScoped<IServicoVenda, ServicoVenda>();            
            services.AddScoped<IServicoUsuario, ServicoUsuario>();            
            
            //Repositorio
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            services.AddScoped<IRepositorioProduto, RepositorioProduto>();
            services.AddScoped<IRepositorioVenda, RepositorioVenda>();
            services.AddScoped<IRepositorioVendaProdutos, RepositorioVendaProdutos>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
