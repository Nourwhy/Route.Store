
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Presistence;
using Presistence.Data;
using Presistence.Repositories;
using Route.Store.Api.Extensions;
using Service;
using Services.Abstractions;
using Shared.ErrorModels;
using System.Reflection.Metadata;
using AssemblyMapping = Service.AssemblyReference;
namespace Route.Store.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterAllApplicationService(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline[Middleware].
            await app.ConfigureMiddlewares();

            app.Run();
        }
    }
}