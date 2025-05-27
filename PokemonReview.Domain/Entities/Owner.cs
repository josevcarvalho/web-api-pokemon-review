namespace PokemonReview.Domain.Entities;

public class Owner : EntityBase
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gym { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<PokemonOwner> PokemonOwners { get; set; }

}
