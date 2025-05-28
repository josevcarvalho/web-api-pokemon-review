using PokemonReview.Domain.Entities;

namespace PokemonReview.Domain.Infrastructure.Repositories;

public interface IPokemonRepository: IRepositoryBase<Pokemon>
{
    Task<decimal> GetPokemonRating(int id, CancellationToken cancellationToken = default);
}
