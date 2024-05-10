using Habit360.DTOs;

namespace Habit360.Interfaces
{
    public interface IHabitService : IDisposable
    {
        Task Create(HabitDto input);
        Task Update(int id, HabitDto input);
        void Delete(int id);
    }
}
