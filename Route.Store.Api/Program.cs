
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Presistence;
using Presistence.Data;
using Presistence.Repositories;
using Service;
using Services.Abstractions;
using System.Reflection.Metadata;
using AssemblyMapping = Service.AssemblyReference;
namespace Route.Store.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
   

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

     
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

    
            builder.Services.AddScoped<IDbIntializer, DbInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(typeof(AssemblyMapping).Assembly);
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbIntializer>();
                await dbInitializer.InitializeAsync();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            await app.RunAsync(); 
        }
    }
}