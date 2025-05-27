namespace PokemonReview.Domain.Entities;

public class Category : EntityBase
{
    public string Name { get; set; }
    public virtual ICollection<PokemonCategory> PokemonCategories { get; set; }
}
