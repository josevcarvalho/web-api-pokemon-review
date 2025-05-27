using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Repositories;
using PokemonReview.Infrastructure.Database;

namespace PokemonReview.Infrastructure.Repositories;

public class PokemonRepository(DataContext context) : IPokemonRepository
{
    private readonly DataContext _context = context;

    public async Task<decimal> GetPokemonRating(int id, CancellationToken cancellationToken)
    {
        var reviews = _context.Reviews.Where(p => p.Pokemon.Id == id);

        return await reviews.AnyAsync(cancellationToken) ? (decimal)reviews.Sum(r => r.Rating) / reviews.Count() : 0;
    }

    public async Task<ICollection<Pokemon>> GetPokemon(CancellationToken cancellationToken = default)
    {
        return await _context.Pokemon.OrderBy(p => p.Id).ToListAsync(cancellationToken);
    }

    public Task<bool> PokemonExists(int id, CancellationToken cancellationToken)
    {
        return _context.Pokemon.AnyAsync(p => p.Id == id, cancellationToken);
    }

    public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon, CancellationToken cancellationToken)
    {
        var pokemonOwner = new PokemonOwner()
        {
            OwnerId = ownerId,
            PokemonId = pokemon.Id,
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
