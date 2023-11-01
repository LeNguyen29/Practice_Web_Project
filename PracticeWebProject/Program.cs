using PracticeWebProject.Models;
using PracticeWebProject.Services;
using System.Text.Json;

namespace PracticeWebProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<JsonFileProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            // API
            app.MapGet("/Products", (context) =>
            {
                var products = app.Services.GetService<JsonFileProductService>().GetProducts();
                var json = JsonSerializer.Serialize(products);

                return context.Response.WriteAsync(json);
            });

            app.Run();
        }
    }
}