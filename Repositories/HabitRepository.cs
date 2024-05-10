using Habit360.DbContexts;
using Habit360.Interfaces;
using Habit360.Models;

namespace Habit360.Repositories
{
    public class HabitRepository(Habit360Context context) : Repository<Habit>(context), IHabitRepository
    {
    }
}
