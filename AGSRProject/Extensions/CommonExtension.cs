namespace AGSRProject.Extensions
{
    using AGSRProject.Common.Mappings;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class CommonExtension
    {
        public static IServiceCollection ConfigureCommon(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PatientProfile));

            return services;
        }
    }
}
