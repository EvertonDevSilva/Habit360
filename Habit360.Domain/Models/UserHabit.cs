using Habit360.Domain.Models.Base;

namespace Habit360.Domain.Models
{
    public class UserHabit : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = new();

        public int HabitId { get; set; }
        public virtual Habit Habit { get; set; } = new();
    }
}
