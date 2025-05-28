namespace PokemonReview.Domain.Entities;

public class Review : EntityBase
{
    public string Title { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
    public int ReviewerId { get; set; }
    public int PokemonId { get; set; }

    public virtual Reviewer Reviewer { get; set; }
    public virtual Pokemon Pokemon { get; set; }
}
