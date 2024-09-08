
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Persistance;

namespace RealEstate.Domain.Persistance
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public EntityRepository(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
