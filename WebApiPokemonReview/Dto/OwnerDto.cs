namespace PokemonReview.WebApi.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gym { get; set; }
    }
}
