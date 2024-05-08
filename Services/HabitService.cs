using Habit360.Repositories;
using Habit360.Models;
using Habit360.DTOs;

namespace Habit360.Services
{
    public class HabitService(IHabitRepository habitRepository) : IHabitService
    {
        private readonly IHabitRepository _habitRepository = habitRepository;

        public async Task<Habit> Create(CreateHabitDto input)
        {
            return await _habitRepository.Create(input);
        }

        public async Task<List<Habit>> Read()
        {
            return await _habitRepository.Read();
        }

        public async Task<Habit> Update(UpdateHabitDto input)
        {
            return await _habitRepository.Update(input);
        }

        public void Delete(int id)
        {
            _habitRepository.Delete(id);
        }
    }
}
