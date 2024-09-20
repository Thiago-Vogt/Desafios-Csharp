
using Microsoft.AspNetCore.Localization;
using PontosAPI.Interfaces;
using PontosAPI.Models;
using PontosAPI.Repositorios;
using PontosAPI.Services;
using System.Globalization;

namespace PontosAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IRepository<ClientePontos, int, string>, ClientePontosRepository>();
            builder.Services.AddSingleton<ClientePontosService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
