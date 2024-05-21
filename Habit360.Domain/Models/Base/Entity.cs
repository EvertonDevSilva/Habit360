namespace Habit360.Domain.Models.Base
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
