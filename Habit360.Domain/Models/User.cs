using Habit360.Domain.Models.Base;

namespace Habit360.Domain.Models
{
    public class User : Entity
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public ICollection<UserHabit> UserHabits { get; set; } = [];
    }
}
