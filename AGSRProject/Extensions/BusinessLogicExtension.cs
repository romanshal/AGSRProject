using AGSRProject.BusinessLogic.Services;
using AGSRProject.Common.Interfaces.Services;
using AGSRProject.DataAccess.Entities;

namespace AGSRProject.Extensions
{
    public static class BusinessLogicExtension
    {
        public static IServiceCollection ConfigureBusinessLogic(this IServiceCollection services) 
        {

            services.AddTransient<IService<Entity>, Service<Entity>>();
            return services; 
        }
    }
}
