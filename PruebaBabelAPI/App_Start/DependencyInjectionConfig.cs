using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PruebaBabelAPI.Repository;
using PruebaBabelAPI.Service;
using System;

namespace subastaAPI.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)

        {
            //services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICountryRepo, CountryRepo>();
            services.AddScoped<ICountryService, CountryService>();

            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();
            services.AddSingleton(configuration);


        }
    }
}


