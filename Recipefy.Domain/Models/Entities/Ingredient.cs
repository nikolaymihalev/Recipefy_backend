using Recipefy.Domain.Common;

namespace Recipefy.Domain.Models.Entities;

public class Ingredient : Entity<int>, IAggregateRoot
{
    public int Id { get; set; }
    public int? ExternalId { get; set; }
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}