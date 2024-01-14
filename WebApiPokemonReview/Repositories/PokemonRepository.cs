using WebApiPokemonReview.Data;
using WebApiPokemonReview.Interfaces;
using WebApiPokemonReview.Models;

namespace WebApiPokemonReview.Repositories
{
    public class PokemonRepository(DataContext context) : IPokemonRepository
    {
        private readonly DataContext _context = context;

        public Pokemon? GetPokemon(Func<Pokemon, bool> predicate)
        {
            return _context.Pokemon.Where(predicate).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == id);

            if (!review.Any())
            {
                return 0;
            }

            return (decimal)review.Sum(r => r.Rating) / review.Count();
        }

        public ICollection<Pokemon> GetPokemon()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(p => p.Id == id);
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwner = new PokemonOwner()
            {
                Owner = new OwnerRepository(_context).GetOwner(ownerId),
                Pokemon = pokemon
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = new CategoryRepository(_context).GetCategory(categoryId),
                Pokemon = pokemon
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }
    }
}
