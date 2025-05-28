using Microsoft.EntityFrameworkCore;
using PokemonReview.Domain.Entities;
using PokemonReview.Domain.Infrastructure.Repositories;
using PokemonReview.Infrastructure.Data;

namespace PokemonReview.Infrastructure.Repositories
{
    public class ReviewRepository(DataContext context) : RepositoryBase<Review>(context), IReviewRepository
    {
        public async Task<ICollection<Review>> GetReviewsOfAPokemon(int pokemonId, CancellationToken cancellationToken = default)
        {
            return await Context.Reviews.Where(r => r.Pokemon.Id == pokemonId).ToListAsync(cancellationToken);
        }
    }
}
