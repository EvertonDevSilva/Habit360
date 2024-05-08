using Habit360.Models;
using Microsoft.EntityFrameworkCore;

namespace Habit360.DbContexts
{
    public class Habit360Context : DbContext
    {
        public Habit360Context(DbContextOptions<Habit360Context> options) : base(options)
        {
        }

        public DbSet<Habit> Habits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=localdatabase.db");
    }
}
