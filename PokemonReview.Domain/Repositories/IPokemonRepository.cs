using PokemonReview.Domain.Entities;

namespace PokemonReview.Domain.Repositories;

public interface IPokemonRepository: IRepositoryBase<Pokemon>
{
    Task<decimal> GetPokemonRating(int id, CancellationToken cancellationToken = default);
}
