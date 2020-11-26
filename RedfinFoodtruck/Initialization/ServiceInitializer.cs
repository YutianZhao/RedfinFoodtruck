using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedfinFoodtruck.Services.Interfaces;
using RedfinFoodtruck.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedfinFoodtruck.Initialization
{
    public class ServiceInitializer
    {
        public void RegisterService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMobileFoodScheduleHttpClientService, MobileFoodScheduleHttpClientService>();
            services.AddSingleton<IHttpClientServiceBase, HttpClientServiceBase>();
        }
    }
}
