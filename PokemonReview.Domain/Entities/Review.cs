namespace PokemonReview.Domain.Entities;

public class Review : EntityBase
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
    public virtual Reviewer Reviewer { get; set; }
    public virtual Pokemon Pokemon { get; set; }
}
