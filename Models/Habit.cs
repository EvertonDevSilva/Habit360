using Habit360.Models.Base;

namespace Habit360.Models
{
    public class Habit : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string HabitType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string Frequency { get; set; } = string.Empty;
    }
}
