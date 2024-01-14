using WebApiPokemonReview.Models;

namespace WebApiPokemonReview.Dto
{
    public class ReviewerDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required ICollection<ReviewDto> Reviews { get; set; }
    }
}
