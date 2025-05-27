using PokemonReview.WebApi.Models;

namespace PokemonReview.WebApi.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemon();
        Pokemon? GetPokemon(Func<Pokemon, bool> predicate);
        decimal GetPokemonRating(int id);
        bool PokemonExists(int id);
        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
        bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon);
        bool DeletePokemon(Pokemon pokemon);
        bool Save();
    }
}
