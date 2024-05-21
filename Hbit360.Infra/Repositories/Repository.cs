using Habit360.Infra.DbContexts;
using Habit360.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Habit360.Domain.Models.Base;

namespace Habit360.Infra.Repositories
{
    public abstract class Repository<TEntity>(Habit360Context context) 
                          : IRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly Habit360Context Context = context;
        private readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

        public virtual async Task Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<TEntity> ReadById(int id) 
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<List<TEntity>> Read()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }


        public virtual async Task Delete(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }


        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
