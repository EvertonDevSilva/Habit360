﻿namespace Habit360.DTOs
{
    public class UpdateHabitDto
    {
        public  int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string HabitType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string Frequency { get; set; } = string.Empty;
    }
}
