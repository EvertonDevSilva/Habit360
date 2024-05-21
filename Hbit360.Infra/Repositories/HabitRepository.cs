using Habit360.Infra.DbContexts;
using Habit360.Domain.Interfaces;
using Habit360.Domain.Models;

namespace Habit360.Infra.Repositories
{
    public class HabitRepository(Habit360Context context) : Repository<Habit>(context), IHabitRepository
    {
    }
}
