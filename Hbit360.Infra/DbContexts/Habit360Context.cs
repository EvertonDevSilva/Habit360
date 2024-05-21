using Habit360.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Habit360.Infra.DbContexts
{
    public class Habit360Context(DbContextOptions<Habit360Context> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<UserHabit> UserHabits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Habit360.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserHabit>()
                .HasKey(uh => new { uh.UserId, uh.HabitId});

            modelBuilder.Entity<UserHabit>()
                .HasOne(uh => uh.User)
                .WithMany(u => u.UserHabits)
                .HasForeignKey(uh => uh.UserId);

            modelBuilder.Entity<UserHabit>()
                .HasOne(uh => uh.Habit)
                .WithMany(h => h.UserHabits)
                .HasForeignKey(uh => uh.HabitId);
        }
    }
}
