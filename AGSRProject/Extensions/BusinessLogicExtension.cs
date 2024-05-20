using AGSRProject.BusinessLogic.Services;
using AGSRProject.Common.Interfaces.Services;
using AGSRProject.Common.Models.Dto;
using AGSRProject.Common.Models.Entities;

namespace AGSRProject.Extensions
{
    public static class BusinessLogicExtension
    {
        public static IServiceCollection ConfigureBusinessLogic(this IServiceCollection services) 
        {
            services.AddTransient<IService<Entity, ModelDto>, Service<Entity, ModelDto>>();
            services.AddTransient<IPatientService, PatientService>();

            return services; 
        }
    }
}
