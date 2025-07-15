namespace Recipefy.Domain.Common;

public abstract class Entity<TId> where TId : struct
{
    public TId Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return false;
        
        return Id.Equals(other.Id);
    }

    public override int GetHashCode() => Id.GetHashCode();
    
    public static bool operator == (Entity<TId>? a, Entity<TId>? b) => a?.Equals(b) ?? b is null;

    public static bool operator != (Entity<TId>? a, Entity<TId>? b) => !(a == b);
}