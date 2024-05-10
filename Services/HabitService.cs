using Habit360.Models;
using Habit360.Interfaces;
using Habit360.Notifications;
using Habit360.DTOs;

namespace Habit360.Services
{
    public class HabitService(IHabitRepository habitRepository,
                              INotificator notificator) : BaseService(notificator), IHabitService
    {
        private readonly IHabitRepository _habitRepository = habitRepository;

        public async Task Create(HabitDto input)
        {
            if (_habitRepository.Search(h => h.Name == input.Name).Result.Any())
            {
                Notificar("Habito já cadastrado!");
                return;
            }

            var habit = new Habit(input.Name,
                                       input.Description,
                                       input.HabitType,
                                       input.StartDate,
                                       input.Frequency);

            await _habitRepository.Create(habit);
        }

        public async Task<List<Habit>> Read()
        {
            return await _habitRepository.Read();
        }

        public async Task Update(int id, HabitDto input)
        {
            var habit = await _habitRepository.ReadById(id);

            if (habit == null)
            {
                Notificar("Habito não encontrado!");
                return;
            }

            habit.UpdateHabit(input.Name, input.Description, input.HabitType, input.StartDate, input.Frequency);
            await _habitRepository.Update(habit);
        }

        public void Delete(int id)
        {
            _habitRepository.Delete(id);
        }

        public void Dispose()
        {
            _habitRepository?.Dispose();
        }
    }
}
