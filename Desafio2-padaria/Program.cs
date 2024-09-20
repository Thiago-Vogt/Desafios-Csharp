using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Desafio2_padaria.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
namespace Desafio2_padaria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Desafio2_padariaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Desafio2_padariaContext") ?? throw new InvalidOperationException("Connection string 'Desafio2_padariaContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddHttpClient();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            var defaultCulture = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            app.UseRequestLocalization(localizationOptions);
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
