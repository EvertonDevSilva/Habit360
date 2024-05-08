using Habit360.DTOs;
using Habit360.Models;

namespace Habit360.Services
{
    public interface IHabitService
    {
        Task<Habit> Create(CreateHabitDto input);
        Task<List<Habit>> Read();
        Task<Habit> Update(UpdateHabitDto input);
        void Delete(int id);
    }
}
