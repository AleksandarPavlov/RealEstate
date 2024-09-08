
namespace RealEstate.Domain.Persistance
{
    public interface IEntityRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
