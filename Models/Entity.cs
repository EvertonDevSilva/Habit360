namespace Habit360.Models
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
