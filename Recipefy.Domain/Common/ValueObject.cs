using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Recipefy.Domain.Common;

[Owned]
public abstract class ValueObject
{
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var props = GetPropertiesToCheck();
        foreach (var prop in props)
        {
            var thisValue  = prop.GetValue(this);
            var otherValue = prop.GetValue(obj);
            if (thisValue is null ^ otherValue is null)
                return false;

            if (thisValue != null && !thisValue.Equals(otherValue))
                return false;
        }

        return true;
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            foreach (var prop in GetPropertiesToCheck())
            {
                var value = prop.GetValue(this);
                hash = hash * 23 + (value?.GetHashCode() ?? 0);
            }
            return hash;
        }
    }
    
    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (ReferenceEquals(a, b)) 
            return true;
        
        if (a is null || b is null) 
            return false;
        
        return a.Equals(b);
    }

    public static bool operator !=(ValueObject? a, ValueObject? b) => !(a == b);
    
    private IEnumerable<PropertyInfo> GetPropertiesToCheck()
    {
        return GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.CanRead); 
    }
}