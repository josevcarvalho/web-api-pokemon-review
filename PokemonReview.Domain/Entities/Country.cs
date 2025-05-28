namespace PokemonReview.Domain.Entities;

public class Country : EntityBase
{
    public string Name { get; set; }

    public virtual ICollection<Owner> Owners { get; set; }
}
