namespace PokemonReview.Domain.Entities;

public class Reviewer : EntityBase
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<Review> Reviews { get; set;}
}
