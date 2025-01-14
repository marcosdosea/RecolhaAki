using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecolhakiWeb
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
            services.AddControllersWithViews();
            // inje��o depend�ncia DBContext
            services.AddDbContext<recolhakiContext>(options =>
               options.UseMySQL(
                   Configuration.GetConnectionString("RecolhakiDataBase")));
            // inje��o depend�ncia Services
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IMaterialreciclavelService, MaterialreciclavelService>();
            //services.AddTransient<IPessoaService, PessoaService>();
            //services.AddTransient<INotificarProblemaService, NotificarProblemaService>();
            //services.AddTransient<IAutorizarColetorService, AutorizarColetorService>();
            // inje��o depend�ncia mappers
            services.AddAutoMapper(typeof(Startup).Assembly);
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
