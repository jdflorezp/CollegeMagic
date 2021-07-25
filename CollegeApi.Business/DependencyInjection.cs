using CollegeApi.Business.Interface;
using CollegeApi.Repository.EF.Implementation;
using CollegeApi.Repository.EF.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCollege(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IinscriptionBusiness, InscriptionBusiness>();
            services.AddScoped<IinscriptionRepository, InscriptionRepository>();
            return services;
        }
    }
}
