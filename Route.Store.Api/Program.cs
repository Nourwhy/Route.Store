
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

            // Register services
            builder.Services.RegisterAllServices(builder.Configuration);

            var app = builder.Build();

            // Use middlewares
            await app.ConfigureMiddlewares();

            // Final run
            await app.RunAsync();

        }
    }
}