using DAL.Repositories.UserRepository;
using DAL.Services.UserService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
           /* services.AddTransient<StudentsSeeder>();*/
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
           /* services.AddScoped<IJwtUtils, IJwtUtils>();*/

            return services;
        }
    }
}
