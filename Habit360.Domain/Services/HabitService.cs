using Habit360.Domain.Models;
using Habit360.Domain.Interfaces;
using Habit360.Domain.Notifications;
using Habit360.Domain.Validations;

namespace Habit360.Domain.Services
{
    public class HabitService(IHabitRepository habitRepository, INotificator notificator) 
        : BaseService(notificator), IHabitService
    {
        private readonly IHabitRepository _habitRepository = habitRepository;

        public async Task Create(Habit habit)
        {
            if (!ValidatorExecute(new HabitValidator(), habit)) return;

            if (_habitRepository.Search(h => h.Name == habit.Name).Result.Any())
            {
                Notify("Habito já cadastrado!");
                return;
            }

            await _habitRepository.Create(habit);
        }

        public async Task<List<Habit>> Read()
        {
            return await _habitRepository.Read();
        }

        public async Task Update(Habit habit)
        {
            if (!ValidatorExecute(new HabitValidator(), habit)) return;

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
