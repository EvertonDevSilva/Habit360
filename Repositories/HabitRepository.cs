using Habit360.DbContexts;
using Habit360.DTOs;
using Habit360.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Habit360.Repositories
{
    public class HabitRepository(Habit360Context dbContext) : IHabitRepository
    {
        private readonly Habit360Context _dbContext = dbContext;

        public async Task<Habit> Create(CreateHabitDto input)
        {
            var habitModel = new Habit
            {
                Name = input.Name,
                Description = input.Description,
                HabitType = input.HabitType,
                StartDate = input.StartDate,
                Frequency = input.Frequency
            };

            await _dbContext.Habits.AddAsync(habitModel);
            await _dbContext.SaveChangesAsync();
            return habitModel;
        }

        public async Task<List<Habit>> Read()
        {
            return await _dbContext.Habits.ToListAsync();
        }

        public async Task<Habit> Update(UpdateHabitDto input)
        {
            var habitModel = new Habit
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                HabitType = input.HabitType,
                StartDate = input.StartDate,
                Frequency = input.Frequency
            };

            _dbContext.Habits.Update(habitModel);
            await _dbContext.SaveChangesAsync();

            return habitModel;
        }

        public void Delete(int id)
        {
            var habitModel = _dbContext.Habits.First(h => h.Id == id);
            _dbContext.Habits.Remove(habitModel);
            _dbContext.SaveChanges();
        }
    }
}
