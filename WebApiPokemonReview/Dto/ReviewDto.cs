namespace WebApiPokemonReview.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Text { get; set; }
        public int Rating { get; set; }
    }
}
