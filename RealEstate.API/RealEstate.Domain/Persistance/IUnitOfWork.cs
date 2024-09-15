
namespace RealEstate.Infrastructure.Persistance
{
    public interface IUnitOfWork
    {
        void Commit();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
