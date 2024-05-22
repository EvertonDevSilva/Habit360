using Habit360.Domain.Interfaces;
using Habit360.Domain.Models;
using Habit360.Infra.DbContexts;

namespace Habit360.Infra.Repositories
{
    public class UserRepository(Habit360Context context) : Repository<User>(context), IUserRepository
    {
    }
}
