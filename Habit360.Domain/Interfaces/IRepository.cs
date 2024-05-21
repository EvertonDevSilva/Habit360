using System.Linq.Expressions;

namespace Habit360.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Create(TEntity entity);
        Task<TEntity> ReadById(int id);
        Task<List<TEntity>> Read();
        Task Update(TEntity input);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
