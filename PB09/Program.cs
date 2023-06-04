using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PB09.Services;
using PB09.Models;
using PB09.Models.Entities;
using PB09.Services.Repositories;
using PB09.Interfaces;
using PB09.Middlewares;
using Shyjus.BrowserDetection;

namespace PB09
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddDetection();

            builder.Services.AddRazorPages();
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<User>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IHistoryService, HistoryService>();
            builder.Services.AddTransient<BrowserMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<BrowserMiddleware>();

            app.UseDetection();

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}