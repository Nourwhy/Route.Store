using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class AApplicationServicsRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            services.AddScoped<IServiceManager, ServiceManager>();
            services.Configure<JwtOptions>(configuration.GetSection( "JwtOptions"));
            return services;
        }
    }
}
