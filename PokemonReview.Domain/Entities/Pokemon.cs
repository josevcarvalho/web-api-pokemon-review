namespace PokemonReview.Domain.Entities;

public class Pokemon : EntityBase
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<PokemonOwner> PokemonOwners { get; set; }
    public virtual ICollection<PokemonCategory> PokemonCategories { get; set; }

}
