using WebApiPokemonReview.Models;

namespace PokemonReview.WebApi.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
