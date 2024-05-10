using Habit360.DbContexts;
using Habit360.Interfaces;
using Habit360.Notifications;
using Habit360.Repositories;
using Habit360.Services;

namespace Habit360.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Habit360Context>();
            // Habits
            services.AddScoped<IHabitRepository, HabitRepository>();
            services.AddScoped<IHabitService, HabitService>();
            //Notificator
            services.AddScoped<INotificator, Notificator>();

            return services;
        }
    }
}
