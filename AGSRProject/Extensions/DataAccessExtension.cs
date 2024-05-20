using AGSRProject.Common.Interfaces.Repositories;
using AGSRProject.Common.Models.Entities;
using AGSRProject.DataAccess.Contexts;
using AGSRProject.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AGSRProject.Extensions
{
    public static class DataAccessExtension
    {
        public static IServiceCollection ConfigureDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString));

            services.AddTransient<IRepository<Entity>, Repository<Entity>>();
            services.AddTransient<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
