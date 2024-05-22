using Habit360.Infra.DbContexts;
using Habit360.Infra.Repositories;
using Habit360.Domain.Interfaces;
using Habit360.Domain.Notifications;
using Habit360.Domain.Services;

namespace Habit360.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Habit360Context>();
            //Users
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            // Habits
            services.AddScoped<IHabitRepository, HabitRepository>();
            services.AddScoped<IHabitService, HabitService>();
            //Notificator
            services.AddScoped<INotificator, Notificator>();

            return services;
        }
    }
}
