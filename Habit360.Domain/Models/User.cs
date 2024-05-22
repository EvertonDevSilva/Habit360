using Habit360.Domain.Models.Base;

namespace Habit360.Domain.Models
{
    public class User : Entity
    {
        public User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<UserHabit> UserHabits { get; set; } = [];

        public void UpdateUser(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
