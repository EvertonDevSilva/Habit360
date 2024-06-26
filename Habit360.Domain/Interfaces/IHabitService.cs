﻿
using Habit360.Domain.Models;

namespace Habit360.Domain.Interfaces
{
    public interface IHabitService : IDisposable
    {
        Task Create(Habit input);
        Task Update(Habit input);
        void Delete(int id);
    }
}
