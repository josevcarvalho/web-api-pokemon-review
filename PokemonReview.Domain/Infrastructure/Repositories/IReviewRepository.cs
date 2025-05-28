using PokemonReview.Domain.Entities;

namespace PokemonReview.Domain.Infrastructure.Repositories;

public interface IReviewRepository : IRepositoryBase<Review>
{
    Task<ICollection<Review>> GetReviewsOfAPokemon(int pokemonId, CancellationToken cancellationToken);
}
