using SAAP.Educational.Shared.Common;

namespace SAAP.Educational.Shared.Persistence;

public interface ICommandRepository<TEntity, in TKey>
    where TEntity : AggregateRoot<TKey>
    where TKey : notnull
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
