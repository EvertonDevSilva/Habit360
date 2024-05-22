using Habit360.Domain.Models;

namespace Habit360.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
