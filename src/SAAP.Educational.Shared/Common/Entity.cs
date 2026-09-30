namespace SAAP.Educational.Shared.Common;

public abstract class Entity<TKey> : IEquatable<Entity<TKey>>
    where TKey : notnull
{
    protected Entity(TKey id)
    {
        Id = id;
    }

    public TKey Id { get; protected init; }

    public bool Equals(Entity<TKey>? other)
    {
        return other is not null
            && GetType() == other.GetType()
            && EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TKey> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }
}
