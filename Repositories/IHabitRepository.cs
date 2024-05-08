using Habit360.DTOs;
using Habit360.Models;

namespace Habit360.Repositories
{
    public interface IHabitRepository
    {
        Task<Habit> Create(CreateHabitDto input);
        Task<List<Habit>> Read();
        Task<Habit> Update(UpdateHabitDto input);
        void Delete(int id);
    }
}
