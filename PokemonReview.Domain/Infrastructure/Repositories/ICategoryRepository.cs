using PokemonReview.Domain.Entities;

namespace PokemonReview.Domain.Infrastructure.Repositories;

public interface ICategoryRepository : IRepositoryBase<Category>
{
    Task<ICollection<Pokemon>> GetPokemonByCategory(int categoryId, CancellationToken cancellationToken = default);
}
