using Recipefy.Domain.Common;

namespace Recipefy.Domain.Models.Entities;

public class Category : Entity<int>, IAggregateRoot
{
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
}