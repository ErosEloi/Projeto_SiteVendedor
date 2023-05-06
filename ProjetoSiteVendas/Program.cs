﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoSiteVendas.Data;
using ProjetoSiteVendas.Interface;
using ProjetoSiteVendas.Services;

namespace ProjetoSiteVendas
{
    public class Program
    {

        

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //String de conexão ao banco de dados
            builder.Services.AddDbContext<ProjetoSiteVendasContext>(options => options.UseMySql("server=localhost; initial catalog=Crud_MVC_SiteVendas;uid=root;pwd=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql")));
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            

            // Serviço de busca dos vendedores
            builder.Services.AddScoped<ISellerService, SellerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}