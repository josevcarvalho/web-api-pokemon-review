using PokemonReview.Domain.Entities;

namespace PokemonReview.Domain.Infrastructure.Repositories;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    Task<ICollection<Owner>> GetOwnersOfAPokemon(int pokemonId, CancellationToken cancellationToken = default);
    Task<ICollection<Pokemon>> GetPokemonByOwner(int ownerId, CancellationToken cancellationToken = default);
}
