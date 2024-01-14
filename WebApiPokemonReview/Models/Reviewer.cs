namespace WebApiPokemonReview.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public ICollection<Review> Reviews { get; set;}
    }
}
