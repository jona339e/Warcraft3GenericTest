
using Microsoft.EntityFrameworkCore;
using Warcraft3GenericTest.Data;
using Warcraft3GenericTest.Interfaces;
using Warcraft3GenericTest.Models;
using Warcraft3GenericTest.Repositories;

namespace Warcraft3GenericTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            
            builder.Services.AddScoped<IGenericRepository<Race>, GenericRepository<Race>>();
            builder.Services.AddScoped<IGenericRepository<Building>, GenericRepository<Building>>();
            builder.Services.AddScoped<IGenericRepository<Unit>, GenericRepository<Unit>>();
            builder.Services.AddScoped<IGenericRepository<Faction>, GenericRepository<Faction>>();



            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // if there are route conflicts you can enable the below to only apply the route with conflicts to the first endpoint
            //builder.Services.AddSwaggerGen(c => {
            //    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            //    c.IgnoreObsoleteActions();
            //    c.IgnoreObsoleteProperties();
            //    c.CustomSchemaIds(type => type.FullName);
            //});



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warcraft 3 Generic Web Api Test v1");
                //    c.RoutePrefix = string.Empty;
                //});
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}