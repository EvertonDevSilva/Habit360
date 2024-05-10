namespace Habit360.Models
{
    public class Habit : Entity
    {
        public Habit() { }

        public Habit(string name,
                       string description,
                       string habitType,
                       DateTime startDate,
                       string frequency)
        {
            Name = name;
            Description = description;
            HabitType = habitType;
            StartDate = startDate;
            Frequency = frequency;
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string HabitType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string Frequency { get; set; } = string.Empty;

        public void UpdateHabit(string name, string description, string habitType, DateTime startDate, string frequency)
        {
            Name = name;
            Description = description;
            HabitType = habitType;
            StartDate = startDate;
            Frequency = frequency;
        }
    }
}

