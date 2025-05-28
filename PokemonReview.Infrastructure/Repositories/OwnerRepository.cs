using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Infrastructure.Repositories;
using PokemonReview.Infrastructure.Data;

namespace PokemonReview.Infrastructure.Repositories;

public class OwnerRepository(DataContext context) : RepositoryBase<Owner>(context), IOwnerRepository
{
    public async Task<ICollection<Owner>> GetOwnersOfAPokemon(int pokemonId, CancellationToken cancellationToken = default)
    {
        return await Context.PokemonOwners
            .Where(p => p.PokemonId == pokemonId)
            .Select(p => p.Owner)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<Pokemon>> GetPokemonByOwner(int ownerId, CancellationToken cancellationToken = default)
    {
        return await Context.PokemonOwners
            .Where(p => p.OwnerId == ownerId)
            .Select(p => p.Pokemon)
            .ToListAsync(cancellationToken);
    }
}
