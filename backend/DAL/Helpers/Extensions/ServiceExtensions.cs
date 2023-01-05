using DAL.Helpers.JwtUtils;
using DAL.Helpers.Seeders;
using DAL.Repositories.PictureRepository;
using DAL.Repositories.UserRepository;
using DAL.Services.PictureService;
using DAL.Services.UserService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            services.AddTransient<IPictureRepository, PictureRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPictureService, PictureService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            Debug.WriteLine("tony soprano");
            services.AddTransient<ProfilePictureSeeder>();
            services.AddTransient<UserSeeder>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            Debug.WriteLine("Am bagat utilitatile");
            services.AddTransient<IJwtUtils, JwtUtils.JwtUtils>();

            return services;
        }
    }
}
