
using Habit360.Repositories;
using Habit360.DbContexts;
using Habit360.Services;
using Microsoft.EntityFrameworkCore;

namespace Habit360
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Habit360Context>(options =>
                options.UseSqlite("Data Source=localdatabase.db"));

            builder.Services.AddScoped<IHabitRepository, HabitRepository>();
            builder.Services.AddScoped<IHabitService, HabitService>();

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
