namespace PokemonReview.Domain.Entities;

public class PokemonOwner : EntityBase
{
    public int PokemonId { get; set; }
    public int OwnerId { get; set; }

    public virtual Pokemon Pokemon { get; set; }
    public virtual Owner Owner { get; set; }
}
