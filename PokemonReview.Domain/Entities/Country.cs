namespace PokemonReview.Domain.Entities;

public class Country : EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Owner> Owners { get; set; }

}
