namespace SAAP.Educational.Shared.Common;

public abstract class AggregateRoot<TKey> : Entity<TKey>
    where TKey : notnull
{
    protected AggregateRoot(TKey id)
        : base(id)
    {
    }
}
