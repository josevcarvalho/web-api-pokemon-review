namespace PokemonReview.Domain.Entities;

public class Reviewer : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<Review> Reviews { get; set;}
}
